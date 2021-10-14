


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


public class Vehicle<T> where T : GearBox {
    public T Transmission {get; init;}

    public virtual GearBox GetTransmission() {
        return Transmission;
    }
}

public class Suv : Vehicle<FourSpeed> {

    public override FourSpeed GetTransmission()
    {
        return base.Transmission;
    }

}

public class Truck : Suv {
    public override FourSpeed GetTransmission()
    {
        return base.Transmission;
    }
}

public abstract class GearBox {

    public abstract void ShiftGear();
}

public class FourSpeed : GearBox {

    public override void ShiftGear() {
        Console.WriteLine("4 Speed Shifting");
    }
}

public class SixSpeed : GearBox
{
    public override void ShiftGear()
    {
         Console.WriteLine("4 Speed Shifting");
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