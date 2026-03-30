namespace APBD_Cw1_s30760.Models;

public class Camera(string name, string brand, int megapixels, bool hasMicrophone) : Equipment(name, brand)
{
    public int Megapixels { get; set; } = megapixels;
    public bool HasMicrophone { get; set; } = hasMicrophone;
}