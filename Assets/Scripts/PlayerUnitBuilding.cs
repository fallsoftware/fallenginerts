using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerUnitBuilding : MonoBehaviour {
    public GameObject UnitBuildingPanel;
    public GameObject Battleground;
    private MouseManager _mouseManager;

    void Start() {
        this._mouseManager = this.Battleground.GetComponent<MouseManager>();
    }

    void Update() {

    }

    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.UnitBuildingPanel.activeSelf) {
            this._mouseManager.MouseOnObject = true;
        }
    }

    void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.UnitBuildingPanel.activeSelf) {
            this._mouseManager.ShutAllPanels();
            this.UnitBuildingPanel.SetActive(true);
        }

        this._mouseManager.MouseOnObject = false;
    }
}