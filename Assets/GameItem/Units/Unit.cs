using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Generic class of Unit for the inheritence
/// </summary>
public abstract class Unit
{
    public abstract void SetIronCost(int i);
    public abstract void SetWoodCost(int i);
    public abstract void SetFoodCost(int i);
    public abstract void SetPopulationCost(int i);
    public abstract int GetIronCost();
    public abstract int GetFoodCost();
    public abstract int GetWoodCost();
    public abstract int GetPopulationCost();
}
