using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of update of the food displayed on the interface
/// </summary>
public class UpdateValueFood : MonoBehaviour {
    public Player player;
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = player.food.ToString() + "(" + player.getNumberFood() + ")";
	}
}
