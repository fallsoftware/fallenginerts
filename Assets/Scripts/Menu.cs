using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	void Start () {
	}
	
	void Update () {
	
	}

    public void HandleMenu() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}