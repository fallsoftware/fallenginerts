using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/// <summary>
/// Main building of the player
/// </summary>
public class PlayerMainBuilding : UnitBuilding {
    public GameObject MinionBuildingPanel;
    public GameObject MinionAssignPanel;

    void Start () {
        this.InitializeFields();
        InvokeRepeating("UpdateCollider", 0, 0.5f);
    }

    void UpdateCollider() {
        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        Destroy(collider);
        BoxCollider2D newCollider = this.gameObject.AddComponent<BoxCollider2D>();
        newCollider.isTrigger = true;
    }


    //On click we activate the interface of the main building
    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.MinionBuildingPanel.activeSelf
            || !this.MinionAssignPanel.activeSelf) {
            this.MouseManager.MouseOnObject = true;
        }
    }

    void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!this.MinionBuildingPanel.activeSelf) {
            if (!this.MinionAssignPanel.activeSelf) {
                this.MouseManager.ShutAllPanels();
                this.MouseManager.ResetSpriteRenderers();
                this.MinionBuildingPanel.SetActive(true);
                this.SetSelectedColorState();
            }
        }

        this.MouseManager.MouseOnObject = false;
    }
}