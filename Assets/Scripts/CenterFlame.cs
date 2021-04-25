using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    bool musicStart = false;

    public string bgmName = "";

    public void ResetMusic()
    {
        musicStart = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart && collision.CompareTag("Note"))
        {
            AudioManager.instance.PlayBgm(bgmName);
            musicStart = true;
        }
    }
}
