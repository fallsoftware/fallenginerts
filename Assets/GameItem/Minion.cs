using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Minion
{
    private const int lifetime=1000;
    public int time;
    public static int woodcost = 20;
    public static int ironcost = 20;
    public static int foodcost = 20;
    public static int populationcost = 1;

    /// <summary>
    /// update the minion so it lived 1 unit more
    /// </summary>
    /// <returns> return 1 if the minion is dead after the update, 0 else</returns>
    public bool Update()
    {
        time++;
        if (time > lifetime)
        {
            return true;
        }
        else return false;
    }
    /// <summary>
    /// return the percentage of life remaining
    /// </summary>
    /// <returns></returns>
    public int LifeRemaining()
    {
        if (time == 0)
        {
            return 0;
        }
        return (time/lifetime*100);
    }
}
