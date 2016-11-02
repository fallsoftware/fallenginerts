using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerMainBuilding : MonoBehaviour {
    public GameObject MinionBuildingPanel;
    public GameObject MinionAssignPanel;
    public GameObject Battleground;
    private MouseManager _mouseManager;

	void Start () {
	    this._mouseManager = this.Battleground.GetComponent<MouseManager>();
	}
	
	void Update () {
	
	}

    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.MinionBuildingPanel.activeSelf
            || !this.MinionAssignPanel.activeSelf) {
            this._mouseManager.MouseOnObject = true;
        }
    }

    void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.MinionBuildingPanel.activeSelf) {
            if (!this.MinionAssignPanel.activeSelf) {
                this.MinionBuildingPanel.SetActive(true);
            }
        }

        this._mouseManager.MouseOnObject = false;
    }
}