using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject atmPopup;
    [SerializeField] private GameObject depositPopup;
    [SerializeField] private GameObject withdrawPopup;
    [SerializeField] private GameObject noMoneyPopup;

    [SerializeField] private InputField depositInput;
    [SerializeField] private InputField withdrawInput;

    private void Start()
    {
        atmPopup.SetActive(true);
        depositPopup.SetActive(false);
        withdrawPopup.SetActive(false);
        noMoneyPopup.SetActive(false);
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
    public void OnClickBack()
    {
        depositPopup.SetActive(false);
        withdrawPopup.SetActive(false);
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
