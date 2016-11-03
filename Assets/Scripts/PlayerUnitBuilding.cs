using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerUnitBuilding : UnitBuilding {
    public GameObject UnitBuildingPanel;

    void Start() {
        this.InitializeFields();
    }

    void Update() {

    }

    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.UnitBuildingPanel.activeSelf) {
            this.MouseManager.MouseOnObject = true;
        }
    }

    void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        this.MouseManager.ResetSpriteRenderers();

        if (!this.UnitBuildingPanel.activeSelf) {
            this.MouseManager.ShutAllPanels();
            this.UnitBuildingPanel.SetActive(true);
        }

        this.SetSelectedColorState();
        this.MouseManager.MouseOnObject = false;
    }
}