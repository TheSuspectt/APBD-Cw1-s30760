using APBD_Cw1_s30760.Enums;

namespace APBD_Cw1_s30760.Models;

public abstract class Equipment(string name, string brand)
{
    private static int _nextId = 1;

    public int Id { get; } = _nextId++;
    public string Name { get; set; } = name;
    public string Brand { get; set; } = brand;
    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
}