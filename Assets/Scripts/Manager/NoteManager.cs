using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0d;

    [SerializeField] Transform tfNoteAppear = null;

    TimingManager theTimingManager;
    EffectManager theEffectManager;

    private void Start()
    {
        theTimingManager = GetComponent<TimingManager>();
        theEffectManager = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            var t_note = ObjectPool.instance.noteQueue.Dequeue();
            t_note.transform.position = tfNoteAppear.position;
            t_note.SetActive(true);
            theTimingManager.boxNoteList.Add(t_note);
            currentTime -= 60d / bpm;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                theEffectManager.JudgementEffect(4);
            }

            theTimingManager.boxNoteList.Remove(collision.gameObject);
            ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
