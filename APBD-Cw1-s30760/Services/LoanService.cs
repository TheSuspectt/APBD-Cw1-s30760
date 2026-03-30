using APBD_Cw1_s30760.Enums;
using APBD_Cw1_s30760.Models;

namespace APBD_Cw1_s30760.Services;

public class LoanService
{
    private readonly List<Loan> _loans = [];
    private const decimal PenaltyPerDay = 10m;

    public void BorrowEquipment(User user, Equipment equipment, DateTime borrowedAt, int days)
    {
        if (equipment.Status != EquipmentStatus.Available)
        {
            throw new Exception($"Equipment with id {equipment.Id} is not available.");
        }

        int activeLoansCount = 0;

        foreach (var loan in _loans)
        {
            if (loan.User == user && !loan.IsReturned)
            {
                activeLoansCount++;
            }
        }

        if (activeLoansCount >= user.GetMaxActiveLoans())
        {
            throw new Exception($"User with id {user.Id} reached the active loans limit.");
        }

        var newLoan = new Loan(user, equipment, borrowedAt, days);
        _loans.Add(newLoan);
        equipment.Status = EquipmentStatus.Borrowed;
    }

    public decimal ReturnEquipment(int loanId, DateTime returnDate)
    {
        Loan? found = null;

        foreach (var l in _loans)
        {
            if (l.Id == loanId)
            {
                found = l;
                break;
            }
        }

        if (found == null)
        {
            throw new Exception($"Loan with id {loanId} not found.");
        }

        if (found.IsReturned)
        {
            throw new Exception($"Loan with id {loanId} was already returned.");
        }

        found.ReturnEquipment(returnDate, PenaltyPerDay);
        found.Equipment.Status = EquipmentStatus.Available;

        return found.Penalty;
    }

    public List<Loan> GetAll()
    {
        return _loans;
    }

    public List<Loan> GetActiveUserLoans(User user)
    {
        var result = new List<Loan>();

        foreach (var loan in _loans)
        {
            if (loan.User == user && !loan.IsReturned)
            {
                result.Add(loan);
            }
        }

        return result;
    }

    public List<Loan> GetOverdueLoans(DateTime today)
    {
        var result = new List<Loan>();

        foreach (var loan in _loans)
        {
            if (loan.IsOverdue(today))
            {
                result.Add(loan);
            }
        }

        return result;
    }

    public void PrintSummaryReport(List<User> users, List<Equipment> equipment)
    {
        int available = 0;
        int borrowed = 0;
        int unavailable = 0;

        foreach (var e in equipment)
        {
            if (e.Status == EquipmentStatus.Available) available++;
            else if (e.Status == EquipmentStatus.Borrowed) borrowed++;
            else if (e.Status == EquipmentStatus.Unavailable) unavailable++;
        }

        int active = 0;
        int returned = 0;
        int overdue = 0;
        decimal penalties = 0;

        foreach (var loan in _loans)
        {
            if (!loan.IsReturned) active++;
            else returned++;

            if (loan.IsOverdue(DateTime.Now)) overdue++;

            penalties += loan.Penalty;
        }

        Console.WriteLine("\nRENTAL SUMMARY REPORT:");
        Console.WriteLine($"Users: {users.Count}");
        Console.WriteLine($"Equipment: {equipment.Count}");
        Console.WriteLine($"Available: {available}");
        Console.WriteLine($"Borrowed: {borrowed}");
        Console.WriteLine($"Unavailable: {unavailable}");
        Console.WriteLine($"All loans: {_loans.Count}");
        Console.WriteLine($"Active loans: {active}");
        Console.WriteLine($"Returned loans: {returned}");
        Console.WriteLine($"Overdue loans: {overdue}");
        Console.WriteLine($"Total penalties: {penalties}");
    }
}