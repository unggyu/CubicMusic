using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class Login : MonoBehaviour
{
    [SerializeField] Text id = null;
    [SerializeField] Text pw = null;

    DatabaseManager theDatabase;

    // Start is called before the first frame update
    void Start()
    {
        theDatabase = FindObjectOfType<DatabaseManager>();
        Backend.InitializeAsync(true, InitializeCallback);
    }

    void InitializeCallback(BackendReturnObject bro)
    {
        if (Backend.IsInitialized)
        {
            Debug.Log(Backend.Utils.GetServerTime());
            Debug.Log(Backend.Utils.GetGoogleHash());
        }
        else
        {
            Debug.Log("�ʱ�ȭ ���� (���ͳ� ���� ���)");
        }
    }

    public void BtnRegist()
    {
        var t_id = id.text;
        var t_pw = pw.text;

        var bro = Backend.BMember.CustomSignUp(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("ȸ������ �Ϸ�");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("ȸ������ ����");
        }
    }

    public void BtnLogin()
    {
        var t_id = id.text;
        var t_pw = pw.text;

        var bro = Backend.BMember.CustomLogin(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("�α��� �Ϸ�");
            theDatabase.LoadScore();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�α��� ����");
        }
    }
}
