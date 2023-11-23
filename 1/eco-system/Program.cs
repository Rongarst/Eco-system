using System;
using System.Collections.Generic;

class LivingOrganism
{
    public int Energy { get; set; }
    public int Age { get; set; }
    public int Size { get; set; }
}

interface IReproducible
{
    void Reproduce();
}

interface IPredator
{
    void Hunt(LivingOrganism prey);
}

class Animal : LivingOrganism, IReproducible, IPredator
{
    public string? Species { get; set; }
    public int Speed { get; set; }
    public Animal()
    {
        Species = null;
    }
    public void Reproduce()
    {
        Console.WriteLine($"{Species} розмножується.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine($"{Species} полює на {prey.GetType().Name}.");
    }
}

class Plant : LivingOrganism, IReproducible
{
    public string? Type { get; set; }
    public Plant()
    {
        Type = null;
    }
    public void Reproduce()
    {
        Console.WriteLine($"{Type} розмножується.");
    }
}

class Microorganism : LivingOrganism, IReproducible, IPredator
{
    public string? Type { get; set; }
    public Microorganism()
    {
        Type = null;
    }
    public void Reproduce()
    {
        Console.WriteLine($"{Type} розмножується.");
    }

    public void Hunt(LivingOrganism prey)
    {
        Console.WriteLine($"{Type} полює на {prey.GetType().Name}.");
    }
}

class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateInteraction()
    {
        foreach (var organism in organisms)
        {
            if (organism is IPredator predator)
            {
                foreach (var otherOrganism in organisms)
                {
                    if (otherOrganism != organism)
                    {
                        predator.Hunt(otherOrganism);
                    }
                }
            }

            if (organism is IReproducible reproducible)
            {
                reproducible.Reproduce();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal лев = new Animal { Species = "Лев", Energy = 100, Age = 5, Size = 10, Speed = 50 };
        Animal олень = new Animal { Species = "Олень", Energy = 80, Age = 3, Size = 8, Speed = 40 };
        Plant трава = new Plant { Type = "Трава", Energy = 20, Age = 1, Size = 2 };
        Microorganism бактерія = new Microorganism { Type = "Бактерія", Energy = 10, Age = 1, Size = 1 };

        ecosystem.AddOrganism(лев);
        ecosystem.AddOrganism(олень);
        ecosystem.AddOrganism(трава);
        ecosystem.AddOrganism(бактерія);

        ecosystem.SimulateInteraction();
    }
}
