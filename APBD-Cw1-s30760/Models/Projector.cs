namespace APBD_Cw1_s30760.Models;

public class Projector(string name, string brand, int lumens, bool hasHdmi) : Equipment(name, brand)
{
    public int Lumens { get; set; } = lumens;
    public bool HasHdmi { get; set; } = hasHdmi;
}