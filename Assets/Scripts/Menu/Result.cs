using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject goUI = null;

    [SerializeField] Text[] txtCount = null;
    [SerializeField] Text txtCoin = null;
    [SerializeField] Text txtScore = null;
    [SerializeField] Text txtMaxCombo = null;

    ScoreManager theScore;
    ComboManager theCombo;
    TimingManager theTiming;

    // Start is called before the first frame update
    void Start()
    {
        theScore = FindObjectOfType<ScoreManager>();
        theCombo = FindObjectOfType<ComboManager>();
        theTiming = FindObjectOfType<TimingManager>();
    }

    public void ShowResult()
    {
        FindObjectOfType<CenterFlame>().ResetMusic();

        AudioManager.instance.StopBgm();

        goUI.SetActive(true);

        for (int i = 0; i < txtCount.Length; i++)
        {
            txtCount[i].text = "0";
        }

        txtCoin.text = "0";
        txtScore.text = "0";
        txtMaxCombo.text = "0";

        var t_judgement = theTiming.GetJudgementRecord();
        var t_currentScore = theScore.GetCurrentScore();
        var t_maxCombo = theCombo.GetMaxCombo();
        var t_coin = t_currentScore / 50;

        for (int i = 0; i < t_judgement.Length; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtMaxCombo.text = string.Format("{0:#,##0}", t_maxCombo);
        txtCoin.text = string.Format("{0:#,##0}", t_coin);
    }

    public void BtnMainMenu()
    {
        goUI.SetActive(false);
        GameManager.instance.MainMenu();
        theCombo.ResetCombo();
    }
}
