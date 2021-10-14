Console.WriteLine("Hello, World to Covariant Property Return Types!");

var hondaCrv = new Suv(new FourSpeed());
hondaCrv.GoForward();

public class Vehicle<T> where T : GearBox
{

    /// <summary>
    /// This is necessary because C# 10 was not able to include "required" parameters.
    /// Required properites were unfortunately not added to C# 10. See https://github.com/dotnet/csharplang/issues/3630
    /// </summary>
    /// <param name="transmission"></param>
    public Vehicle(T transmission)
    {
        Transmission = transmission;
    }

    protected T Transmission { get; init; }

    /// <summary>
    /// Engage the
    /// </summary>
    public virtual T GoForward()
    {
        Transmission.Engage();

        return Transmission;
    }
}

public class Suv : Vehicle<FourSpeed>
{
    public Suv(FourSpeed transmission) : base(transmission)
    {

    }

    public override FourSpeed GoForward()
    {
        var transmission = base.GoForward();
        transmission.DisengageClutch();
        return transmission;
    }
}

public class Truck : Vehicle<SixSpeed>
{
    public Truck(SixSpeed transmission) : base(transmission)
    {

    }

    public override SixSpeed GoForward()
    {
        var transmission = base.GoForward();
        transmission.Enable4WheelDrive();
        return transmission;
    }
}

public abstract class GearBox
{

    public abstract void Engage();
}

public class FourSpeed : GearBox
{

    public override void Engage()
    {
        Console.WriteLine("4 Speed Engaged");
    }

    public void DisengageClutch()
    {
        Console.WriteLine("Disengaging 4 speed clutch.");
    }
}

/// <summary>
/// IGearBox is to get around the transmission returns. Add this type to the GearBox definition
/// </summary>
public interface IGearBox
{

    void ShiftGear();
}

public class SixSpeed : FourSpeed
{
    public override void Engage()
    {
        Console.WriteLine("6 Speed Engaged");
    }

    public void Enable4WheelDrive()
    {
        Console.WriteLine("6 Speed Engaged");
    }
}

public class Person
{
    private int Id { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    public Person()
    { }
    public Person(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
    public virtual Person GetPerson()
    {
        return new Person();
    }
}


public class Employee : Person
{
    private string Department { get; set; }
    public Employee()
    { }
    public Employee(int id, string firstName, string lastName,
    string department) : base(id, firstName, lastName)
    {
        Department = department;
    }
    public override Employee GetPerson()
    {
        return new Employee();
    }
}