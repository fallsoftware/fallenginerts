using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// Enumeration for the types of units in the army
/// </summary>
public enum UnitType { SWORDSMAN, BOWMAN, HORSEMAN };
/// <summary>
/// Enumeration for the types of ressources
/// </summary>
public enum RessourceType { WOOD, IRON, FOOD };
/// <summary>
/// General Configuration of the application by the static field of the classes, Gestion by the editor of unity
/// </summary>
class Config : MonoBehaviour
{
    //Speed of a moving army
    public int speed = 1;
    //refreshing rate of the moving army
    public float refreshingRate = 0.2f;
    //costs and lifetime of a minion
    public int minionCostWood = 20;
    public int minionCostIron = 20;
    public int minionCostFood = 20;
    public int minionCostPopulation = 1;
    public int minionLifeTime = 100;
    //costs of military units
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
    //max population of players
    public int PlayermaxPopulation = 200;
    //basic Ressource regen of units
    public int PlayerRegen = 10;
    //base Production Buildings Life
    public int UnitBuildingMaxLife = 100;
    //RespawnTime of Production buildings
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
        Player.maxpopulation = PlayermaxPopulation;
        UnitBuildingLife.maxlife = UnitBuildingMaxLife;
        UnitBuildingLife.RespawnCooldown = UnitBuildingRespawnTime;
}
}
