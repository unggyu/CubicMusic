using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    [SerializeField] GameObject goComboImage = null;
    [SerializeField] Text txtCombo = null;

    int currentCombo = 0;

    Animator myAnim;
    readonly string animComboUp = "ComboUp";

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }

    public void IncreaseCombo(int p_num = 1)
    {
        currentCombo += p_num;
        txtCombo.text = string.Format("{0:#,##0}", currentCombo);

        if (currentCombo > 2)
        {
            txtCombo.gameObject.SetActive(true);
            goComboImage.SetActive(true);

            myAnim.SetTrigger(animComboUp);
        }
    }

    public int GetCurrentCombo()
    {
        return currentCombo;
    }

    public void ResetCombo()
    {
        currentCombo = 0;
        txtCombo.text = "0";
        txtCombo.gameObject.SetActive(false);
        goComboImage.SetActive(false);
    }
}
