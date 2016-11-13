using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// A moving army is an army moving toward the other player (in this game we use 1 prefab for each player)
/// </summary>
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
    /// <summary>
    /// At start is set the moving of the army
    /// </summary>
    public AudioClip Boom1;
    public AudioClip Boom2;
    void Start()
    {
        InvokeRepeating("Move", 0, refreshingRate);
    }
    /// <summary>
    /// the army moves in the direction of the enemy (left or right)
    /// </summary>
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
    /// <summary>
    /// Update of the moving army with the current population of the army
    /// </summary>
    void Update(){

        swordText.text = army.swordsmanCount.ToString();
        bowText.text = army.bowmanCount.ToString();
        horseText.text = army.horsemanCount.ToString();
        

    }
    /// <summary>
    /// Trigger for fighting something (building or another moving army)
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        //if it's a production building the building is hurt by the population of the army
        UnitBuildingLife unit = other.GetComponent<UnitBuildingLife>();

        if (unit != null)
        {
            int life = unit.life;
            unit.HurtBuilding(this.army.TotalUnit);
            this.army.RemoveUnits(life);
            SoundManager.instance.RandomizeSfx(this.Boom2);
        }
        else
        {
            //if it's touching another moving army then we are resoluting the fight
            MovingArmy _army = other.GetComponent<MovingArmy>();
            if (_army != null)

            {
                this.army.ConfrontArmy(_army.army);            

                if (this.Boom1 != null && this.Boom2 != null) {
                    SoundManager.instance.RandomizeSfx(this.Boom1);
                }

                _army.CheckDestroy();
            }
            else
            {
                //if it's touching the main building then we fight the reserve army
                MainBuilding mainBuilding = other.GetComponent<MainBuilding>();
                if (mainBuilding != null)
                {
                    this.army.ConfrontArmy(mainBuilding.player.reserveArmy);
                    mainBuilding.CheckDestoy();
                }
            }
        }
        this.CheckDestroy();
    }
    /// <summary>
    /// Check the destruction of the moving army
    /// </summary>
    public void CheckDestroy() {
        if (this.army.TotalUnit <= 0) {
            Destroy(this.gameObject);
        }
    }
}