using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    [Header("로그인")]
    [SerializeField] private InputField loginIdInput;
    [SerializeField] private InputField loginPwInput;
    [SerializeField] private Text loginErrorTxt;

    [Header("회원가입")]
    [SerializeField] private InputField idInput;
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField pwInput;
    [SerializeField] private InputField confirmpwInput;
    [SerializeField] private Text errorTxt;

    [Header("팝업")]
    [SerializeField] private GameObject popupLogin;
    [SerializeField] private GameObject popupBank;

    readonly string isBlank = " 을/를 확인해주세요.";
    readonly string blank = "";
    readonly public string path = Application.dataPath + "/Data/";

    private void Start()
    {
        popupLogin.SetActive(true);
        popupBank.SetActive(false);
    }

    public void Login()
    {
        UserData inputData;
        try
        {
            Debug.Log(path + loginIdInput.text + ".json");
            string database = File.ReadAllText(path + loginIdInput.text + ".json");
            inputData = JsonConvert.DeserializeObject<UserData>(database);
            GameManager.Instance.userData = inputData;
        }
        catch (FileNotFoundException)
        {
            loginErrorTxt.text = "ID" + isBlank;
            return;
        }
        if (string.IsNullOrWhiteSpace(loginPwInput.text) || inputData.password != loginPwInput.text)
        {
            loginErrorTxt.text = "PW" + isBlank;
            return;
        }

        popupLogin.SetActive(false);
        popupBank.SetActive(true);
    }
    public void SignUp()
    {
        if (IsError(idInput, "ID")) return;
        if (IsError(nameInput, "Name")) return;
        if (IsError(pwInput, "Password")) return;
        if (IsError(confirmpwInput, "Password")) return;
        if(pwInput.text != confirmpwInput.text)
        {
            errorTxt.text = "패스워드가 일치하지 않습니다.";
            return;
        }

        UserData userData = new UserData(idInput.text, pwInput.text, nameInput.text);
        string json = JsonConvert.SerializeObject(userData);
        Debug.Log(path+" 경로");
        File.WriteAllText(path + userData.id + ".json", json);

        MakeBlank(idInput);
        MakeBlank(nameInput);
        MakeBlank(pwInput);
        MakeBlank(confirmpwInput);
        errorTxt.text = "가입이 완료되었습니다.";
    }

    private bool IsError(InputField field, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(field.text))
        {
            errorTxt.text = fieldName + isBlank;
            return true;
        }
        return false;
    }

    private void MakeBlank(InputField field)
    {
        field.text = blank;
    }
}
