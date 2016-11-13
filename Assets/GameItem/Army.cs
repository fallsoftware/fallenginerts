using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public enum UnitType {SWORDSMAN,BOWMAN,HORSEMAN };
public class Army
{
    public int bowmanCount=0;
    public int swordsmanCount=0;
    public int horsemanCount=0;
    public int TotalUnit { get { return swordsmanCount + horsemanCount + bowmanCount; }}
    public Player player;
    public Army(Player _player)
    {
        this.player = _player;
    }
    public void ConfrontArmy(Army otherArmy)
    {
        if (otherArmy.player != player)
        {
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
