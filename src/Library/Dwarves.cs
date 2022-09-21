using System;

namespace Characters;

public class Dwarves : ICharacter
{
    string Description { get; }
    //public string Name { get ; set; } --> despues poner lineas en el Program.cs
    public ItemsStore items { get; } // instancia "items" de la clase ItemsStore 
    //public HealthPoints healthPoints { get; } --> instancia "healthPoints" de la clase HealthPoints (todavia no creada)     
    public Dwarves()
    {
        //this.Name = name;
        this.Description= "Son seres temperamentales que se destacan en el combate, su gran resistencia y lealtad.";

    }
}
