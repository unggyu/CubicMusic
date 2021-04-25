using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject[] stageArray = null;
    GameObject currentStage;
    Transform[] stagePlates;

    [SerializeField] float offsetY = -3;
    [SerializeField] float plateSpeed = 10;

    int stepCount = 0;
    int totalPlateCount = 0;

    public void RemoveStage()
    {
        if (currentStage != null)
        {
            Destroy(currentStage);
        }
    }

    public void SettingStage(int p_songNum)
    {
        stepCount = 0;
        currentStage = Instantiate(stageArray[p_songNum], Vector3.zero, Quaternion.identity);
        stagePlates = currentStage.GetComponent<Stage>().plates;
        totalPlateCount = stagePlates.Length;

        for (int i = 0; i < totalPlateCount; i++)
        {
            stagePlates[i].position = new Vector3(
                stagePlates[i].position.x,
                stagePlates[i].position.y + offsetY,
                stagePlates[i].position.z);
        }
    }

    public void ShowNextPlate()
    {
        if (stepCount < totalPlateCount)
        {
            StartCoroutine(MovePlateCo(stepCount++));
        }
    }

    IEnumerator MovePlateCo(int p_num)
    {
        stagePlates[p_num].gameObject.SetActive(true);
        var t_destPos = new Vector3(
            stagePlates[p_num].position.x,
            stagePlates[p_num].position.y - offsetY,
            stagePlates[p_num].position.z);

        while (Vector3.SqrMagnitude(stagePlates[p_num].position - t_destPos) >= 0.001f)
        {
            stagePlates[p_num].position = Vector3.Lerp(stagePlates[p_num].position, t_destPos, plateSpeed * Time.deltaTime);
            yield return null;
        }

        stagePlates[p_num].position = t_destPos;
    }
}
