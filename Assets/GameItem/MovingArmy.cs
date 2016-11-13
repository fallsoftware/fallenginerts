using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MovingArmy : MonoBehaviour 
{
    public enum Direction{RIGHT,LEFT};
    public static int speed=1;
    public static float refreshingRate = 0.2f;
    public Player player;
    public TextMesh swordText;
    public TextMesh bowText;
    public TextMesh horseText;
    public Direction direction=Direction.RIGHT;
    public Army army;
    void Start()
    {
        InvokeRepeating("Move", 0, refreshingRate);
    }
    void Move()
    {
        switch (direction)
        {
            case Direction.RIGHT:
                {
                    this.gameObject.transform.position += new Vector3(speed, 0);
                    break;
                }
            case Direction.LEFT:
                {
                    this.gameObject.transform.position -= new Vector3(speed, 0);
                    break;
                }
        }
    }
    void Update(){

        swordText.text = army.swordsmanCount.ToString();
        bowText.text = army.bowmanCount.ToString();
        horseText.text = army.horsemanCount.ToString();
        

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        UnitBuildingLife unit = other.GetComponent<UnitBuildingLife>();

        if (unit != null)
        {
            int life = unit.life;
            unit.HurtBuilding(this.army.TotalUnit);
            this.army.RemoveUnits(life);
        }
        else
        {
            MovingArmy army = other.GetComponent<MovingArmy>();
            if (army != null)

            {
                this.army.ConfrontArmy(army.army);
                army.CheckDestroy();
            }
            else
            {
                MainBuilding mainBuilding = other.GetComponent<MainBuilding>();
                if (mainBuilding != null)
                {
                    this.army.ConfrontArmy(mainBuilding.player.reserveArmy);
                }
            }
        }
        this.CheckDestroy();
    }
    public void CheckDestroy()
    {
        if (this.army.TotalUnit <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}