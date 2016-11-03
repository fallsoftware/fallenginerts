using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Config : MonoBehaviour
{
    public int speed = 1;
    public float refreshingRate = 0.2f;
    public int minionCostWood = 20;
    public int minionCostIron = 20;
    public int minionCostFood = 20;
    public int minionCostPopulation = 1;
    public int minionLifeTime = 100;
    public int swordsmanCostWood = 10;
    public int swordsmanCostIron = 50;
    public int swordsmanCostFood = 30;
    public int swordsmanCostPopulation = 1;
    public int horsemanCostWood = 30;
    public int horsemanCostIron = 10;
    public int horsemanCostFood = 50;
    public int horsemanCostPopulation = 1;
    public int bowmanCostWood = 50;
    public int bowmanCostIron = 30;
    public int bowmanCostFood = 10;
    public int bowmanCostPopulation = 1;
    public int PlayermaxPopulation = 200;
    public int PlayerRegen = 10;
    public int UnitBuildingLife = 100;
    public int UnitBuildingRespawnTime=200;
    void Start()
    {
        MovingArmy.speed = speed;
        MovingArmy.refreshingRate = refreshingRate;
        Minion.woodcost=minionCostWood;
        Minion.ironcost=minionCostIron;
        Minion.foodcost = minionCostFood;
        Minion.populationcost = minionCostPopulation;
        Minion.lifetime = minionLifeTime;

        Swordsman.woodcost = swordsmanCostWood;
        Swordsman.ironcost = swordsmanCostIron;
        Swordsman.foodcost = swordsmanCostFood;
        Swordsman.populationcost = swordsmanCostPopulation;

        Horseman.woodcost = horsemanCostWood;
        Horseman.ironcost = horsemanCostIron;
        Horseman.foodcost = horsemanCostFood;
        Horseman.populationcost = horsemanCostPopulation;

        Bowman.woodcost = bowmanCostWood;
        Bowman.ironcost = bowmanCostIron;
        Bowman.foodcost = bowmanCostFood;
        Bowman.populationcost = bowmanCostPopulation;

        Player.baseregen = PlayerRegen;

   /* public int maxPopulation = 200;
    public int UnitBuildingLife = 100;
    public int UnitBuildingRespawnTime = 200;*/
}
}
