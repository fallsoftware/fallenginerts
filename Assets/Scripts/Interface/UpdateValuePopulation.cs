using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of update of the population displayed on the interface
/// </summary>
public class UpdateValuePopulation : MonoBehaviour {
    public Player player;

	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = player.population + "/" + Player.maxpopulation;
	}
}
