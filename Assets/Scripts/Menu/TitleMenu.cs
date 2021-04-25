using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    [SerializeField] GameObject goStageUI = null;

    public void BtnPlay()
    {
        goStageUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
