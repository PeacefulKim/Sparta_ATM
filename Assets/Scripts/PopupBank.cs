using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [Header("은행 팝업")]
    [SerializeField] private GameObject atmPopup;
    [SerializeField] private GameObject depositPopup;
    [SerializeField] private GameObject withdrawPopup;
    [SerializeField] private GameObject noMoneyPopup;
    [SerializeField] private GameObject sendPopup;
    [SerializeField] private Text errorTxt;

    [Header("인풋")]
    [SerializeField] private InputField depositInput;
    [SerializeField] private InputField withdrawInput;
    [SerializeField] private InputField receiverInput;
    [SerializeField] private InputField sendInput;


    private void Start()
    {
    }

    public void OnClickDeposit()
    {
        atmPopup.SetActive(false);
        depositPopup.SetActive(true);
    }
    public void OnClickWithdraw()
    {
        atmPopup.SetActive(false);
        withdrawPopup.SetActive(true);
    }
    public void OnClickSend()
    {
        atmPopup.SetActive(false);
        sendPopup.SetActive(true);
    }
    public void OnClickBack()
    {
        depositPopup.SetActive(false);
        withdrawPopup.SetActive(false);
        sendPopup.SetActive(false);
        atmPopup.SetActive(true);
    }

    public void Deposit(int money)
    {
        UserData userData = GameManager.Instance.userData;
        if (userData.cash < money)
        {
            noMoneyPopup.SetActive(true);
            return;
        }
            userData.balance += money;
            userData.cash -= money;
    }
    public void Withdraw(int money)
    {
        UserData userData = GameManager.Instance.userData;
        if (userData.balance < money)
        {
            noMoneyPopup.SetActive(true);
            return;
        }
        userData.balance -= money;
        userData.cash += money;
    }
    public void Send()
    {
        if (receiverInput.text == null || sendInput.text == null)
        {
            errorTxt.text = "입력 정보를 확인해주세요.";
            return;
        }

        UserData userData = GameManager.Instance.userData;
        int.TryParse(sendInput.text, out int _money);
        if(_money > userData.balance)
        {
            errorTxt.text = "잔액이 부족합니다.";
            return;
        }
        try
        {
            string path = Application.dataPath + "/Data/" + receiverInput.text + ".json";
            string database = File.ReadAllText(path);
            Debug.Log(database);
            UserData receiver = JsonConvert.DeserializeObject<UserData>(database);

            receiver.balance += _money;
            userData.balance -= _money;

            string json = JsonConvert.SerializeObject(receiver);
            File.WriteAllText(path, json);
        }
        catch (FileNotFoundException)
        {
            errorTxt.text = "유효하지 않은 대상입니다.";
            return;
        }


    }

    public void DepositOnInput()
    {
        int.TryParse(depositInput.text, out int _money);
        Deposit(_money);
    }
    public void WithdrawOnInput()
    {
        int.TryParse(withdrawInput.text, out int _money);
        Withdraw(_money);
    }
}
