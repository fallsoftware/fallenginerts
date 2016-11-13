using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateValueIron : MonoBehaviour {
    public Player player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = player.iron+ "(" + player.getNumberIron()+")";
	}
}
