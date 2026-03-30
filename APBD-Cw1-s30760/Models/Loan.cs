namespace APBD_Cw1_s30760.Models;

public class Loan(User user, Equipment equipment, DateTime borrowedAt, int days)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public User User { get; set; } = user;
    public Equipment Equipment { get; set; } = equipment;
    public DateTime BorrowedAt { get; set; } = borrowedAt;
    public int Days { get; set; } = days > 0 ? days : throw new ArgumentException("Days must be greater than 0.");
    public DateTime DueDate { get; set; } = borrowedAt.AddDays(days);
    public DateTime? ReturnedAt { get; private set; }
    public decimal Penalty { get; private set; } = 0;

    public bool IsReturned => ReturnedAt is not null;

    public bool IsOverdue(DateTime today)
    {
        return !IsReturned && today.Date > DueDate.Date;
    }

    public void ReturnEquipment(DateTime returnDate, decimal penaltyPerDay)
    {
        ReturnedAt = returnDate;

        if (returnDate.Date > DueDate.Date)
        {
            int daysLate = (returnDate.Date - DueDate.Date).Days;
            Penalty = daysLate * penaltyPerDay;
        }
    }
}