using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public UserData userData;

    public string path;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }

    private static void SetupInstance()
    {
        instance = FindAnyObjectByType<GameManager>();
        if(instance == null)
        {
            instance = new GameObject(typeof(GameManager).Name).AddComponent<GameManager>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }


    }

    private void Start()
    {
    }
    public void MakeUserInfoPath()
    {
        Debug.Log(userData.id);
        path = Path.Combine(Application.dataPath + "/Data/", userData.id + ".json");
    }

    public void MakeUserData()
    {
        userData = new UserData("chamber", "123123", "È²ÁØ¿µ");
        MakeUserInfoPath();
    }
    public void SaveUserData()
    {
        string json = JsonConvert.SerializeObject(userData);
        File.WriteAllText(path, json);
    }
    public void LoadUserData(string _id)
    {
        string path = Application.dataPath + _id + ".json";
        Debug.Log(path);
        string database = File.ReadAllText(path);
        userData = JsonConvert.DeserializeObject<UserData>(database);
    }
}
