using APBD_Cw1_s30760.Enums;
using APBD_Cw1_s30760.Models;

namespace APBD_Cw1_s30760.Services;

public class EquipmentService
{
    private readonly List<Equipment> _equipment = [];

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        Equipment? found = null;

        foreach (var e in _equipment)
        {
            if (e.Id == equipmentId)
            {
                found = e;
                break;
            }
        }

        if (found == null)
        {
            throw new Exception($"Equipment with id {equipmentId} not found.");
        }

        return found;
    }

    public List<Equipment> GetAll()
    {
        return _equipment;
    }

    public List<Equipment> GetAvailable()
    {
        var result = new List<Equipment>();

        foreach (var e in _equipment)
        {
            if (e.Status == EquipmentStatus.Available)
            {
                result.Add(e);
            }
        }

        return result;
    }

    public void SetUnavailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Unavailable;
    }

    public void SetAvailable(int equipmentId)
    {
        GetEquipmentById(equipmentId).Status = EquipmentStatus.Available;
    }
}