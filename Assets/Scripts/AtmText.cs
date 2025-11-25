using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmText : MonoBehaviour
{
    [SerializeField] private Text nameTxt;
    [SerializeField] private Text cashTxt;
    [SerializeField] private Text balanceTxt;

    UserData userData;

    void Start()
    {
        userData = GameManager.Instance.userData;
        if (userData == null)
        {
            GameManager.Instance.MakeUserData();
        }
        else
        {
            GameManager.Instance.MakeUserInfoPath();
        }

            Refresh();
    }

    public void Refresh()
    {
        Debug.Log(userData.name);
        nameTxt.text = userData.name;
        cashTxt.text = string.Format("{0:N0}", userData.cash);
        balanceTxt.text = string.Format("{0:N0}", userData.balance);

        GameManager.Instance.SaveUserData();
    }
}
