using UnityEngine;
using System.Collections;

public class LifeUpdate : MonoBehaviour {
    public TextMesh life;
    public Player player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        life.text = player.reserveArmy.TotalUnit.ToString();
	}
}
