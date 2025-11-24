using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField] private GameObject atmPopup;
    [SerializeField] private GameObject depositPopup;
    [SerializeField] private GameObject withdrawPopup;

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
}
