using APBD_Cw1_s30760.Enums;

namespace APBD_Cw1_s30760.Models;

public class Student(string fName, string lName, string studentNumber) : User(fName, lName)
{
    public string StudentNumber { get; set; } = studentNumber;

    public override int GetMaxActiveLoans() => 2;
    public override UserType GetUserType() => UserType.Student;
}