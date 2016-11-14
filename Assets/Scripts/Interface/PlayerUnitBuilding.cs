using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// Script of gestion of the player building
/// </summary>
public class PlayerUnitBuilding : UnitBuilding {
    public GameObject UnitBuildingPanel;
    [HideInInspector] public bool isDestroyed = false;

    void Start() {
        this.InitializeFields();
        InvokeRepeating("UpdateCollider", 0, 0.5f);
    }

    void UpdateCollider() {
        if (this.isDestroyed) return;

        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        Destroy(collider);
        BoxCollider2D newCollider = this.gameObject.AddComponent<BoxCollider2D>();
        newCollider.isTrigger = true;
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