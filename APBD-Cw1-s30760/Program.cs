using APBD_Cw1_s30760.Models;
using APBD_Cw1_s30760.Services;


var equipmentService = new EquipmentService();
var loanService = new LoanService();

var users = new List<User>();
var equipmentList = new List<Equipment>();



var user1 = new Student("Jan", "Kowalski", "s11111");
var user2 = new Student("Adam", "Nowak", "s22222");
var user3 = new Employee("Anna", "Wisniewska", "IT");

users.Add(user1);
users.Add(user2);
users.Add(user3);



var laptop1 = new Laptop("Dell", "Dell", 16, "Windows");
var laptop2 = new Laptop("Apple", "Apple", 8, "MacOS");
var projector1 = new Projector("Epson", "Epson", 3000, true);
var camera1 = new Camera("Canon", "Canon", 24, true);

equipmentService.AddEquipment(laptop1);
equipmentService.AddEquipment(laptop2);
equipmentService.AddEquipment(projector1);
equipmentService.AddEquipment(camera1);

equipmentList.Add(laptop1);
equipmentList.Add(laptop2);
equipmentList.Add(projector1);
equipmentList.Add(camera1);



Console.WriteLine("ALL EQUIPMENT");
foreach (var e in equipmentService.GetAll())
{
    Console.WriteLine($"{e.Id} {e.Name} {e.Status}");
}

equipmentService.SetUnavailable(projector1.Id);

try
{
    loanService.BorrowEquipment(user1, laptop1, DateTime.Now, 5);
    Console.WriteLine("Borrow OK");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    loanService.BorrowEquipment(user1, projector1, DateTime.Now, 3);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

try
{
    loanService.BorrowEquipment(user1, laptop2, DateTime.Now, 5);
    loanService.BorrowEquipment(user1, camera1, DateTime.Now, 5);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("\nACTIVE:");
foreach (var l in loanService.GetActiveUserLoans(user1))
{
    Console.WriteLine($"{l.Id} {l.Equipment.Name}");
}

loanService.PrintSummaryReport(users, equipmentList);