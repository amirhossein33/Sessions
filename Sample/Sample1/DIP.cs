namespace SOLID.Sample1
{
    //False
    public class Tank
    {
        public void Move()
        {
            Console.WriteLine("Tank is moving.");
        }

        public void Fire()
        {
            Console.WriteLine("Tank is firing.");
        }
    }

    public class Airplane
    {
        public void Move()
        {
            Console.WriteLine("Airplane is flying.");
        }

        public void Fire()
        {
            Console.WriteLine("Airplane is firing.");
        }
    }

    public class Ship
    {
        public void Move()
        {
            Console.WriteLine("Ship is sailing.");
        }

        public void Fire()
        {
            Console.WriteLine("Ship is firing.");
        }
    }

    public class MilitaryOperations
    {
        private Tank tank;
        private Airplane airplane;
        private Ship ship;

        public MilitaryOperations()
        {
            tank = new Tank();
            airplane = new Airplane();
            ship = new Ship();
        }

        public void StartOperation()
        {
            tank.Move();
            airplane.Move();
            ship.Move();
        }

        public void Attack()
        {
            tank.Fire();
            airplane.Fire();
            ship.Fire();
        }
    }

}
//True
public interface IMilitaryUnit
{
    void Move();
    void Fire();
}

public class Tank : IMilitaryUnit
{
    public void Move()
    {
        Console.WriteLine("Tank is moving.");
    }

    public void Fire()
    {
        Console.WriteLine("Tank is firing.");
    }
}

public class Airplane : IMilitaryUnit
{
    public void Move()
    {
        Console.WriteLine("Airplane is flying.");
    }

    public void Fire()
    {
        Console.WriteLine("Airplane is firing.");
    }
}

public class Ship : IMilitaryUnit
{
    public void Move()
    {
        Console.WriteLine("Ship is sailing.");
    }

    public void Fire()
    {
        Console.WriteLine("Ship is firing.");
    }
}

public class MilitaryOperations
{
    private List<IMilitaryUnit> militaryUnits;

    public MilitaryOperations(List<IMilitaryUnit> militaryUnits)
    {
        this.militaryUnits = militaryUnits;
    }

    public void StartOperation()
    {
        foreach (var unit in militaryUnits)
        {
            unit.Move();
        }
    }

    public void Attack()
    {
        foreach (var unit in militaryUnits)
        {
            unit.Fire();
        }
    }
}

