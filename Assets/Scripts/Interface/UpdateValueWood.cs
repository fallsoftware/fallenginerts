using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of update of the wood displayed on the interface
/// </summary>
public class UpdateValueWood : MonoBehaviour {
    public Player player;

	void Update () {
        this.gameObject.GetComponent<Text>().text = player.wood.ToString() + "(" + player.getNumberWood() + ")";
	}
}
