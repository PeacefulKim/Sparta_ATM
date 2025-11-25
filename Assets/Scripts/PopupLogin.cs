using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopupLogin : MonoBehaviour
{
    [Header("로그인")]

    [SerializeField] private InputField loginidInput;
    [SerializeField] private InputField loginpwInput;

    [Header("회원가입")]
    [SerializeField] private InputField idInput;
    [SerializeField] private InputField nameInput;
    [SerializeField] private InputField pwInput;
    [SerializeField] private InputField confirmpwInput;
    [SerializeField] private Text errorTxt;

    [Header("오류 문구")]
    string isBlank = " 을/를 확인해주세요.";

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

        UserData userData = new UserData(idInput.text, nameInput.text, pwInput.text);
        string json = JsonConvert.SerializeObject(userData);
        File.WriteAllText(GameManager.Instance.path, json);
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
}
