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
            Debug.Log("초기화 실패 (인터넷 문제 등등)");
        }
    }

    public void BtnRegist()
    {
        var t_id = id.text;
        var t_pw = pw.text;

        var bro = Backend.BMember.CustomSignUp(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("회원가입 완료");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("회원가입 실패");
        }
    }

    public void BtnLogin()
    {
        var t_id = id.text;
        var t_pw = pw.text;

        var bro = Backend.BMember.CustomLogin(t_id, t_pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인 완료");
            theDatabase.LoadScore();
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("로그인 실패");
        }
    }
}
