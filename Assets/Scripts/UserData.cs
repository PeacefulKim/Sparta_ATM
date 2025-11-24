[System.Serializable]

public class UserData
{
    public string name;
    public int cash;
    public int balance;

    public UserData()
    {
        name = "ȫ�浿";
        cash = 0;
        balance = 0;
    }

    public UserData(string _name, int _cash, int _balance)
    {
        name = _name;
        cash = _cash;   
        balance = _balance;
    }
}
