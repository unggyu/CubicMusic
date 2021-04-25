using UnityEngine;

public class StageMenu : MonoBehaviour
{
    [SerializeField] GameObject TitleMenu = null;

    public void BtnBack()
    {
        TitleMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BtnPlay()
    {
        GameManager.instance.GameStart();
        gameObject.SetActive(false);
    }
}
