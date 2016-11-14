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
        this.InitializeFields(); // calling the parent function to initialize
        // the right fields
        InvokeRepeating("UpdateCollider", 0, 0.5f);
    }

    /// <summary>
    /// this function is pretty UGLY. It's a small fix to make the game
    /// playable. OnMouseDown and OnMouseUp are bugguy on Unity and we
    /// needed to reset the collider often to make it work
    /// </summary>
    void UpdateCollider() {
        BoxCollider2D collider = this.GetComponent<BoxCollider2D>();
        Destroy(collider);
        BoxCollider2D newCollider 
            = this.gameObject.AddComponent<BoxCollider2D>();
        newCollider.isTrigger = true;
        newCollider.size = new Vector3(6, 30, 1);
    }

    /// <summary>
    /// activating the interface of the building
    /// </summary>
    void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return; // prevent
        // interacting with anything else

        if (!this.MinionBuildingPanel.activeSelf
            || !this.MinionAssignPanel.activeSelf) {
            this.MouseManager.MouseOnObject = true; // telling the MouseManager
            // that the mouse hit an object
        }
    }

    /// <summary>
    /// when the button's been pressed on
    /// </summary>
    void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return; // prevent
        // interacting with anything else

        if (!this.MinionBuildingPanel.activeSelf) {
            if (!this.MinionAssignPanel.activeSelf) {
                this.MouseManager.ShutAllPanels();
                this.MouseManager.ResetSpriteRenderers(); // make the green
                // cursors disappear
                this.MinionBuildingPanel.SetActive(true);
                this.SetSelectedColorState();
            }
        }

        this.MouseManager.MouseOnObject = false;
    }
}