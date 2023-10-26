// Program to implement Double circulation in Human Body,
// The process which is responsible for Blood purification in Human Body
// (considering 4 chambered Human Heart)

using System;

public abstract class Organs
{
    private string OrganName;

    public Organs(string OrganName)
    {
        this.OrganName = OrganName;
    }

    public string Organ
    {
        get { return OrganName; }
    }

    public abstract void Functionality();
}
/// <summary>
/// 
/// </summary>
public class Heart : Organs
{
    public Heart() : base("Heart")
    {
    }

    public override void Functionality()
    {
        Console.WriteLine($"Human {Organ} has 4 chambers, LA, LV, RA, RV " +
            $"and responsibe for pumping blood to the body. \n");
    }
}

// Inherited class to demonstrate Inheritance
public class Lungs : Organs
{
    public Lungs() : base("Lungs")
    {
    }

    public override void Functionality()
    {
        Console.WriteLine($"{Organ} are the ones, which are responsible for " +
            $"oxigenating blood (Purification) \n");
    }
}

public class Veins : Organs
{
    public Veins() : base("Veins")
    {
    }

    public override void Functionality()
    {
        Console.WriteLine($"{Organ} are the ones, which are responsible for " +
            $"carrying deoxigenated blood from body to heart, it pumps back goes to Lungs " +
            $"for oxigenation and then the oxigenated blood is circulated to whole body by blood \n");
    }

    public void Functionality(string VC, string PA, string PV, string DA)
    {
        Console.WriteLine($"{VC} are the ones, which are responsible for " +
            $"carrying deoxigenated blood from body to heart, Heart pumps the flow " +
            $"and {PA} carries it to Lungs, After Purification {PV} carries oxygenated " +
            $"blood to Heart and through {DA} oxigenated blood is circulated to whole body.");
    }
}

public class Program
{
    static void Main()
    {
        Organs heart = new Heart();
        Organs lung = new Lungs();
        Veins veins = new Veins();

        heart.Functionality();
        lung.Functionality();
        veins.Functionality();
        veins.Functionality("Superior and Inferior Veina Cava", "Pulmonary Artery",
            "Pulmonary Vein", "Dorsal Aorta");
    }
}