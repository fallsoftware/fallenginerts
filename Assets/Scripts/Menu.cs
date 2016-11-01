using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    private float _timeScale;
	void Start () {
	    this._timeScale = Time.timeScale;
	}
	
	void Update () {
	
	}

    public void HandleMenu() {
        this.gameObject.SetActive(!this.gameObject.activeSelf);

        if (this.gameObject.activeSelf) {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = this._timeScale;
        }
    }
}