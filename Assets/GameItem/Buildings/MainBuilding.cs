using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class MainBuilding : MonoBehaviour 
{
    public Player player;
    public void CheckDestoy()
    {
        if (this.player.reserveArmy.TotalUnit <= 0)
        {
            //LOSING;
        } 
    }

}
