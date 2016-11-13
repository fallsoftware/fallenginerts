using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

    public int wood=0;
    public int iron=0;
    public int food=0;
    public int population=0;
    public static int maxpopulation=200;
    public static int baseregen = 15;
    public static int collectbyminion=10;
    public List<Minion> minionIdle = new List<Minion>();
    public List<Minion> minionWood = new List<Minion>();
    public List<Minion> minionIron = new List<Minion>();
    public List<Minion> minionFood = new List<Minion>();
    public Army reserveArmy;
    public AudioClip BuildUnitSound;

    /// <summary>
    /// Start of the update of the player each seconds
    /// </summary>
    void Start () {
        reserveArmy = new global::Army(this);
        InvokeRepeating("UpdatePlayer", 0, 1.0f);

    }
    /// <summary>
    /// Update of the ressource of the player and of the minions
    /// </summary>
    private void UpdatePlayer()
    {
        wood += (minionWood.Count) * collectbyminion+baseregen;
        food += (minionFood.Count) * collectbyminion + baseregen;
        iron += (minionIron.Count) * collectbyminion + baseregen;
        CheckDeath(minionWood);
        CheckDeath(minionIdle);
        CheckDeath(minionFood);
        CheckDeath(minionIron);
        

    }
    /// <summary>
    /// Check of the deaths in a list of minions as they have a limited lifespan
    /// </summary>
    /// <param name="minions"></param>
    private void CheckDeath(List<Minion> minions)
    {
        List<Minion> todie = new List<Minion>();
        foreach (Minion item in minions)
        {
            if (item.Update())
            {
                todie.Add(item);
            }
        }
        foreach (Minion item in todie)
        {
            population--;
            minions.Remove(item);
        }
    }

    public void BuyMinionWood(int number)
    {
        BuyMinion(number, minionWood);
    }
    public void BuyMinionIron(int number)
    {
        BuyMinion(number, minionIron);
    }
    public void BuyMinionFood(int number)
    {
        BuyMinion(number, minionFood);
    }
    /// <summary>
    /// the player will buy minions
    /// </summary>
    /// <param name="number">number of minions to buy</param>
    /// <param name="minions">List of minions in which to add the minions</param>
    private void BuyMinion(int number, List<Minion> minions)
    {
        if (CanBuyUnit(number,new Minion()))
        {
            wood -= number * Minion.woodcost;
            food -= number * Minion.foodcost;
            iron -= number * Minion.ironcost;
            for(int i = 0; i < number; i++)
            {
                minions.Add(new Minion());
            }
            population += number;
            SoundManager.instance.RandomizeSfx(this.BuildUnitSound);
        }
    }
    /// <summary>
    /// The player will buy units
    /// </summary>
    /// <param name="number">number of units to buy</param>
    /// <param name="unit">type of units to buy</param>
    public void BuyUnit(int number,Unit unit)
    {
        if(!(unit is Minion)) {
            if (CanBuyUnit(number, unit))
            {
                wood -= number * unit.GetWoodCost();
                food -= number * unit.GetFoodCost();
                iron -= number * unit.GetIronCost();
                population += number * unit.GetPopulationCost();
                reserveArmy.AddUnit(number, unit);
                SoundManager.instance.RandomizeSfx(this.BuildUnitSound);
            }
        }
    }
    /// <summary>
    /// Verification if you can buy units
    /// </summary>
    /// <param name="number">number of unit to verify</param>
    /// <param name="unit">type of unit to verify</param>
    /// <returns></returns>
    public bool CanBuyUnit(int number,Unit unit)
    {
        if (population + number <= maxpopulation
            && wood > number * unit.GetWoodCost()
            && food > number * unit.GetFoodCost()
            && iron > number * unit.GetIronCost()
            && number >0 )
        {
            return true;
        }
        return false;
    }
    public int getNumberIdle()
    {
        return minionIdle.Count;
    }
    public int getNumberWood()
    {
        return minionWood.Count;
    }
    public int getNumberIron()
    {
        return minionIron.Count;
    }
    public int getNumberFood()
    {
        return minionFood.Count;
    }

    public void  setMinionWood(int number)
    {
        setMinionList(minionWood, number);
    }
    public void setMinionFood(int number)
    {
        setMinionList(minionFood, number);
    }
    public void setMinionIron(int number)
    {
        setMinionList(minionIron, number);
    }
    /// <summary>
    /// Setting of a list of minion to the number needed by picking in the idle pool or by putting it in it
    /// </summary>
    /// <param name="list">List to work with</param>
    /// <param name="number">number to reach in the list</param>
    void setMinionList(List<Minion> list,int number)
    {
        int difference = number - list.Count;
        if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                Minion tempMinion = minionIdle[0];
                list.Add(tempMinion);
                minionIdle.Remove(tempMinion);
            }
        }
        else if (difference < 0)
        {
            for (int i = 0; i > difference; i--)
            {
                Minion tempMinion = list[0];
                minionIdle.Add(tempMinion);
                list.Remove(tempMinion);
            }
        }
    }
    /// <summary>
    /// Calculation of the max buyable units of a type
    /// </summary>
    /// <param name="unit">type of the unit to buy</param>
    /// <returns></returns>
    public int maxBuyableUnit(Unit unit)
    {
        return (int)Math.Floor((double)Math.Min(Math.Min(food / unit.GetFoodCost(), Math.Min(wood / unit.GetWoodCost(), iron / unit.GetIronCost())), maxpopulation - population));
    }
}
