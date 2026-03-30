namespace APBD_Cw1_s30760.Models;

public class Laptop(string name, string brand, int ramGb, string operatingSystem) : Equipment(name, brand)
{
    public int RamGb { get; set; } = ramGb;
    public string OperatingSystem { get; set; } = operatingSystem;
}