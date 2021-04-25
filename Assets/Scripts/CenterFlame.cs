using UnityEngine;

public class CenterFlame : MonoBehaviour
{
    bool musicStart = false;

    public void ResetMusic()
    {
        musicStart = false;
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
