using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    private int totalminion;
    public int number;
    public int wood;
    public int iron;
    public int food;
    public int population;
    public int maxpopulation=200;
    public Text minionCount;
    private List<Minion> minionIdle;
    private List<Minion> minionWood;
    private List<Minion> minionIron;
    private List<Minion> minionFood;
    private Army reserveArmy;

    // Use this for initialization
    void Start () {
        number = 1;
        totalminion = 0;
        minionIdle = new List<Minion>();
        minionWood = new List<Minion>();
        minionIron = new List<Minion>();
        minionFood = new List<Minion>();
        reserveArmy = new global::Army();
        InvokeRepeating("UpdatePlayer", 0, 1.0f);

    }

    void UpdatePlayer()
    {
        wood += minionWood.Count * 10;
        food += minionFood.Count * 10;
        iron += minionIron.Count * 10;
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
            minions.Remove(item);
        }
    }

    public bool CanBuyMinion() {
        if (population + number < maxpopulation 
            && wood > number * Minion.woodcost
            && food > number * Minion.foodcost
            && food > number * Minion.ironcost)
        {
            return true;
        }
        return false;
    }
    public void BuyMinion()
    {
        if (CanBuyMinion())
        {
            wood -= number * Minion.woodcost;
            food -= number * Minion.foodcost;
            food -= number * Minion.ironcost;
            totalminion += number;
            minionIdle.Add(new Minion());
            population -= number;
            minionCount.text = totalminion.ToString();
        }
    }


    public bool CanBuyArcher()
    {
        if (population + number < maxpopulation
            && wood > number * Archer.woodcost
            && food > number * Archer.foodcost
            && food > number * Archer.ironcost)
        {
            return true;
        }
        return false;
    }

    public void BuyArcher()
    {
        if (CanBuyArcher())
        {
            wood -= number * Archer.woodcost;
            food -= number * Archer.foodcost;
            food -= number * Archer.ironcost;
            reserveArmy.archerCount += number;
            population -= number;
        }
    }
    public bool CanBuyHorseman()
    {
        if (population + number < maxpopulation
            && wood > number * Horseman.woodcost
            && food > number * Horseman.foodcost
            && food > number * Horseman.ironcost)
        {
            return true;
        }
        return false;
    }
    public void BuyHorseman()
    {
        if (CanBuyHorseman())
        {
            wood -= number * Horseman.woodcost;
            food -= number * Horseman.foodcost;
            food -= number * Horseman.ironcost;
            reserveArmy.horsemanCount += number;
            population -= number;
        }
    }
    public bool CanBuySwordsman()
    {
        if (population + number < maxpopulation
            && wood > number * Swordsman.woodcost
            && food > number * Swordsman.foodcost
            && food > number * Swordsman.ironcost)
        {
            return true;
        }
        return false;
    }
    public void BuySwordsman()
    {
        if (CanBuyMinion())
        {
            wood -= number * Swordsman.woodcost;
            food -= number * Swordsman.foodcost;
            food -= number * Swordsman.ironcost;
            reserveArmy.swordsmanCount += number;
            population -= number;
        }
    }
    int getNumberIdle()
    {
        return minionIdle.Count;
    }
    int getNumberWood()
    {
        return minionWood.Count;

    }
    int getNumberIron()
    {
        return minionIron.Count;
    }
    int getNumberFood()
    {
        return minionFood.Count;
    }

    void  setMinionWood(int number)
    {
        setMinionList(minionWood, number);
    }
    void setMinionFood(int number)
    {
        setMinionList(minionFood, number);
    }
    void setMinionIron(int number)
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

    int maxBuyableMinion()
    {
        return (int)Math.Floor((double) Math.Min(food/Minion.foodcost,Math.Min(wood / Minion.woodcost, iron / Minion.ironcost)));
    }
    int maxBuyableArcher()
    {
        return (int)Math.Floor((double)Math.Min(food / Archer.foodcost, Math.Min(wood / Archer.woodcost, iron / Archer.ironcost)));
    }
    int maxBuyableHorseman()
    {
        return (int)Math.Floor((double)Math.Min(food / Horseman.foodcost, Math.Min(wood / Horseman.woodcost, iron / Horseman.ironcost)));
    }
    int maxBuyableSwordsman()
    {
        return (int)Math.Floor((double)Math.Min(food / Swordsman.foodcost, Math.Min(wood / Swordsman.woodcost, iron / Swordsman.ironcost)));
    }
    // Update is called once per frame
    void Update () {
	    
	}
}
