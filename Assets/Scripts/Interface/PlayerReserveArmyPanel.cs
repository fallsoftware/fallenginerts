using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Script of gestion of the reserve army panel
/// </summary>
public class PlayerReserveArmyPanel : MonoBehaviour {
    public Player player;
    public Text bowData;
    public Text swordsData;
    public Text horseData;
	/// <summary>
    /// update of the values of the army
    /// </summary>
	void Update () {
        bowData.text=player.reserveArmy.bowmanCount.ToString();
        swordsData.text=player.reserveArmy.swordsmanCount.ToString();
        horseData.text=player.reserveArmy.horsemanCount.ToString();
    }
}
