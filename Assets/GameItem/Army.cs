using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
/// <summary>
/// Enumeration for the types of units in the army
/// </summary>
public enum UnitType {SWORDSMAN,BOWMAN,HORSEMAN };
/// <summary>
/// An Army (groups of units), an army is owned by a player
/// </summary>
public class Army
{
    public int bowmanCount=0;
    public int swordsmanCount=0;
    public int horsemanCount=0;
    public int TotalUnit { get { return swordsmanCount + horsemanCount + bowmanCount; }}
    public Player player;
    /// <summary>
    /// Constructor of a army with the player owning the army
    /// </summary>
    /// <param name="_player">player owning the army</param>
    public Army(Player _player)
    {
        this.player = _player;
    }
    /// <summary>
    /// Confrontation of this army with another one owned by another player only one army can have remaining units at the end
    /// </summary>
    /// <param name="otherArmy"></param>
    public void ConfrontArmy(Army otherArmy)
    {
        //Verification of the player owning the other army
        if (otherArmy.player != player)
        {
            //Calcul of the winner: first destruction of units by the rock paper scissors (a swordsman will destroy freely a bowman)
            //then will be removed number of units lefts in the other army
            int temptotalbegin1 = this.TotalUnit;
            int temptotalbegin2 = otherArmy.TotalUnit;
            int tempbowman = bowmanCount;
            int tempswordsman = swordsmanCount;
            int temphorseman = horsemanCount;
            bowmanCount = Math.Max(0, bowmanCount - otherArmy.swordsmanCount);
            swordsmanCount = Math.Max(0, swordsmanCount - otherArmy.horsemanCount);
            horsemanCount = Math.Max(0, horsemanCount - otherArmy.bowmanCount);
            otherArmy.bowmanCount = Math.Max(0, otherArmy.bowmanCount - tempswordsman);
            otherArmy.swordsmanCount = Math.Max(0, otherArmy.swordsmanCount - temphorseman);
            otherArmy.horsemanCount = Math.Max(0, otherArmy.horsemanCount - tempbowman);
            player.population -= (temptotalbegin1 - TotalUnit);
            otherArmy.player.population -= (temptotalbegin2 - otherArmy.TotalUnit);
            int ToRemove = Math.Min(this.TotalUnit, otherArmy.TotalUnit);
            RemoveUnits(ToRemove);
            otherArmy.RemoveUnits(ToRemove);
        }
        
    }
    /// <summary>
    /// Removing of a certain number of units in the army in this order: swordsman,horseman,bowman
    /// </summary>
    /// <param name="ToRemoveUnit">number of units to destroy</param>
    public void RemoveUnits(int ToRemoveUnit)
    {
        int temp = Math.Min(ToRemoveUnit,TotalUnit);
        player.population -= temp;
        if (temp != 0)
        {
            int tempmin = Math.Min(temp, swordsmanCount);
            temp -= tempmin;
            swordsmanCount -= tempmin;
            if (temp!= 0)
            {
                tempmin = Math.Min(temp,horsemanCount);
                horsemanCount -= tempmin;
                temp -= tempmin;
                if (temp!= 0)
                {
                    tempmin = Math.Min(temp,bowmanCount);
                    temp -= tempmin;
                    bowmanCount -= tempmin;
                }
            }
        }

    }

    /// <summary>
    /// Add certain number of units of a certain type in the army
    /// </summary>
    /// <param name="number"></param>
    /// <param name="unit"></param>
    internal void AddUnit(int number, Unit unit)
    {
        if(unit is Bowman)
        {
            bowmanCount += number;
        }
        else if (unit is Horseman)
        {
            horsemanCount += number;
        }
        else if (unit is Swordsman)
        {
            swordsmanCount += number;
        }
    }
}
