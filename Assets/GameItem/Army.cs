using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public enum UnitType {SWORDSMAN,BOWMAN,HORSEMAN };
public class Army
{
    public int bowmanCount;
    public int swordsmanCount;
    public int horsemanCount;
    public bool moving;
    public int TotalUnit { get { return swordsmanCount + horsemanCount + bowmanCount; }}
    public Player player;

    void ConfrontArmy(Army otherArmy)
    {
        int tempbowman = bowmanCount;
        int tempswordsman = swordsmanCount;
        int temphorseman = horsemanCount;
        bowmanCount = Math.Max(0, bowmanCount - otherArmy.swordsmanCount);
        swordsmanCount = Math.Max(0, swordsmanCount - otherArmy.horsemanCount);
        horsemanCount = Math.Max(0, horsemanCount - otherArmy.bowmanCount);
        otherArmy.bowmanCount = Math.Max(0, bowmanCount - tempswordsman);
        otherArmy.swordsmanCount = Math.Max(0, swordsmanCount - temphorseman);
        otherArmy.horsemanCount = Math.Max(0, horsemanCount - tempbowman);
        int temptotal1 = TotalUnit;
        int temptotal2 = otherArmy.TotalUnit;
        if (temptotal1 != 0 && temptotal2 != 0)
        {
            int tempmin1 = Math.Min(temptotal1, otherArmy.swordsmanCount);
            int tempmin2 = Math.Min(temptotal2, swordsmanCount);
            temptotal1 -= tempmin2;
            swordsmanCount -= tempmin2;
            temptotal2 -= tempmin1;
            otherArmy.swordsmanCount -= tempmin1;
            if (temptotal1 != 0 && temptotal2 != 0)
            {
                tempmin1 = Math.Min(temptotal1, otherArmy.horsemanCount);
                tempmin2 = Math.Min(temptotal2, horsemanCount);
                temptotal1 -= tempmin2;
                horsemanCount -= tempmin2;
                temptotal2 -= tempmin1;
                otherArmy.horsemanCount -= tempmin1;
                if (temptotal1 != 0 && temptotal2 != 0)
                {
                    tempmin1 = Math.Min(temptotal1, otherArmy.bowmanCount);
                    tempmin2 = Math.Min(temptotal2, bowmanCount);
                    temptotal1 -= tempmin2;
                    bowmanCount -= tempmin2;
                    temptotal2 -= tempmin1;
                    otherArmy.bowmanCount -= tempmin1;
                }
            }
        }
        CheckDestruction();
        otherArmy.CheckDestruction();


    }
    void CheckDestruction()
    {
        if (TotalUnit == 0)
        {
            //Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
