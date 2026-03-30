using APBD_Cw1_s30760.Enums;

namespace APBD_Cw1_s30760.Models;

public abstract class User(string fName, string lName)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string FName { get; set; } = fName;
    public string LName { get; set; } = lName;

    public abstract int GetMaxActiveLoans();
    public abstract UserType GetUserType();
}