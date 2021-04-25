using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    bool musicStart = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart && collision.CompareTag("Note"))
        {
            AudioManager.instance.PlayBgm("BGM0");
            musicStart = true;
        }
    }
}
