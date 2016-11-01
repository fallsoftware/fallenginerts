using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateValueWood : MonoBehaviour {
    public Player player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = player.wood.ToString() + "(" + player.getNumberWood() + ")";
	}
}
