using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject popupLogin;
    [SerializeField] private GameObject popupBank;
    void Start()
    {
        popupLogin.SetActive(true);
        popupBank.SetActive(false);
    }

    void Update()
    {
        
    }
}
