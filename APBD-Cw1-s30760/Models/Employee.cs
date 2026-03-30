using APBD_Cw1_s30760.Enums;

namespace APBD_Cw1_s30760.Models;

public class Employee(string fName, string lName, string department) : User(fName, lName)
{
    public string Department { get; set; } = department;

    public override int GetMaxActiveLoans() => 5;
    public override UserType GetUserType() => UserType.Employee;
}