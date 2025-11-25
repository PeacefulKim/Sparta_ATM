using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public UserData userData;

    private string path;

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

        path = Path.Combine(Application.dataPath + "/Datas/", "database.json");
        LoadUserData();
    }

    private void Start()
    {
    }

    public void MakeUserData()
    {
        userData = new UserData("chamber", "123123", "È²ÁØ¿µ", 100000, 50000);
    }
    public void SaveUserData()
    {
        string json = JsonConvert.SerializeObject(userData);
        File.WriteAllText(path, json);
    }
    public void LoadUserData()
    {
        string database = File.ReadAllText(path);
        userData = JsonConvert.DeserializeObject<UserData>(database);
    }
}
