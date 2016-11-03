using UnityEngine;
using System.Collections;

public class MouseInfo : MonoBehaviour {
    public GameObject Info;

	void Start() {
	
	}
	
	void Update() {
	
	}

    void OnMouseOver() {
        this.Info.SetActive(true);
    }

    void OnMouseExit() {
        this.Info.SetActive(false);
    }
}
