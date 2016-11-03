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
    void Create()
    {
        
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
}