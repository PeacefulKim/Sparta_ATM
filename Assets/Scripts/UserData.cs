[System.Serializable]

public class UserData
{
    public string id;
    public string password;

    public string name;
    public int cash;
    public int balance;

    public UserData()
    {
        id = "aaa";
        password = "aaa";
        name = "ȫ�浿";
        cash = 0;
        balance = 0;
    }

    public UserData(string _id, string _password, string _name)
    {
        id = _id;
        password = _password;

        name = _name;
        cash = 100000;   
        balance = 50000;
    }
}
