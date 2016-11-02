using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public enum RessourceType { WOOD, IRON, FOOD };

public class Player : MonoBehaviour {

    public int wood=0;
    public int iron=0;
    public int food=0;
    public int population=0;
    public int maxpopulation=200;
    public HudManager minionCount;
    private List<Minion> minionIdle = new List<Minion>();
    private List<Minion> minionWood = new List<Minion>();
    private List<Minion> minionIron = new List<Minion>();
    private List<Minion> minionFood = new List<Minion>();
    public Army reserveArmy;

    // Use this for initialization
    void Start () {
        reserveArmy = new global::Army();
        InvokeRepeating("UpdatePlayer", 0, 1.0f);

    }

    private void UpdatePlayer()
    {
        wood += (minionWood.Count + 1) * 10;
        food += (minionFood.Count + 1) * 10;
        iron += (minionIron.Count + 1) * 10;
        CheckDeath(minionWood);
        CheckDeath(minionIdle);
        CheckDeath(minionFood);
        CheckDeath(minionIron);
        

    }
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

    public bool CanBuyMinion(int number) {
        if (population + number <= maxpopulation 
            && wood > number * Minion.woodcost
            && food > number * Minion.foodcost
            && food > number * Minion.ironcost)
        {
            return true;
        }
        return false;
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
    private void BuyMinion(int number, List<Minion> minions)
    {
        if (CanBuyMinion(number))
        {
            wood -= number * Minion.woodcost;
            food -= number * Minion.foodcost;
            iron -= number * Minion.ironcost;
            for(int i = 0; i < number; i++)
            {
                minions.Add(new Minion());
            }
            population += number;
        }
    }
    public bool CanBuyBowman(int number)
    {
        if (population + number <= maxpopulation
            && wood > number * Bowman.woodcost
            && food > number * Bowman.foodcost
            && food > number * Bowman.ironcost)
        {
            return true;
        }
        return false;
    }

    public void BuyBowman(int number)
    {
        if (CanBuyBowman(number))
        {
            wood -= number * Bowman.woodcost;
            food -= number * Bowman.foodcost;
            food -= number * Bowman.ironcost;
            reserveArmy.bowmanCount += number;
            population += number;
        }
    }
    public bool CanBuyHorseman(int number)
    {
        if (population + number <= maxpopulation
            && wood > number * Horseman.woodcost
            && food > number * Horseman.foodcost
            && food > number * Horseman.ironcost)
        {
            return true;
        }
        return false;
    }
    public void BuyHorseman(int number)
    {
        if (CanBuyHorseman(number))
        {
            wood -= number * Horseman.woodcost;
            food -= number * Horseman.foodcost;
            food -= number * Horseman.ironcost;
            reserveArmy.horsemanCount += number;
            population += number;
        }
    }
    public bool CanBuySwordsman(int number)
    {
        if (population + number <= maxpopulation
            && wood > number * Swordsman.woodcost
            && food > number * Swordsman.foodcost
            && food > number * Swordsman.ironcost)
        {
            return true;
        }
        return false;
    }
    public void BuySwordsman(int number)
    {
        if (CanBuyMinion(number))
        {
            wood -= number * Swordsman.woodcost;
            food -= number * Swordsman.foodcost;
            food -= number * Swordsman.ironcost;
            reserveArmy.swordsmanCount += number;
            population += number;
        }
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

    public int maxBuyableMinion()
    {
        return (int)Math.Floor((double)Math.Min(Math.Min(food/Minion.foodcost,Math.Min(wood / Minion.woodcost, iron / Minion.ironcost)), maxpopulation - population));
    }
    public int maxBuyableBowman()
    {
        return (int)Math.Floor((double)Math.Min(Math.Min(food / Bowman.foodcost, Math.Min(wood / Bowman.woodcost, iron / Bowman.ironcost)), maxpopulation - population));
    }
    public int maxBuyableHorseman()
    {
        return (int)Math.Floor((double)Math.Min(Math.Min(food / Horseman.foodcost, Math.Min(wood / Horseman.woodcost, iron / Horseman.ironcost)), maxpopulation - population));
    }
    public int maxBuyableSwordsman()
    {
        return (int)Math.Floor((double)Math.Min(Math.Min(food / Swordsman.foodcost, Math.Min(wood / Swordsman.woodcost, iron / Swordsman.ironcost)),maxpopulation-population));
    }
    // Update is called once per frame
    void Update () {
	    
	}
}
