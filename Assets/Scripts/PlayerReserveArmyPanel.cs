using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerReserveArmyPanel : MonoBehaviour {
    public Player player;
    public Text bowData;
    public Text swordsData;
    public Text horseData;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bowData.text=player.reserveArmy.bowmanCount.ToString();
        swordsData.text=player.reserveArmy.swordsmanCount.ToString();
        horseData.text=player.reserveArmy.horsemanCount.ToString();
    }
}
