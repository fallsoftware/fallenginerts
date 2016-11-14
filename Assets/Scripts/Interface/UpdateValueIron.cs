using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of update of the iron displayed on the interface
/// </summary>
public class UpdateValueIron : MonoBehaviour {
    public Player player;
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = player.iron+ "(" + player.getNumberIron()+")";
	}
}
