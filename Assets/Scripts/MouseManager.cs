using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

/// <summary>
/// class needed to handle the UI with the mouse
/// </summary>
public class MouseManager : MonoBehaviour {
    public GameObject[] UIElements; // elements of the HUD
    public GameObject[] BuildingElements; // buildings handled by the manager
    [HideInInspector] public bool MouseOnObject; // used to know if the mouse
    // is currently on an object or not
    private UnitBuilding[] _unitBuildings;

    void Start () {
	    this.MouseOnObject = false;
        List<UnitBuilding> unitBuildingList = new List<UnitBuilding>();

        foreach (GameObject buildingElement in this.BuildingElements) {
            unitBuildingList.Add(
                buildingElement.GetComponent<UnitBuilding>());
        }

        this._unitBuildings = unitBuildingList.ToArray();

    }
	
	void Update () {
	
	}

    void OnMouseUp() {
        if (!this.MouseOnObject 
            && !EventSystem.current.IsPointerOverGameObject()) {
            this.ShutAllPanels();
            this.ResetSpriteRenderers();
        }
    }

    public void ShutAllPanels() {
        foreach (GameObject UIElement in this.UIElements) {
            UIElement.SetActive(false);
        }
    }

    public void ResetSpriteRenderers() {
        foreach (UnitBuilding unitBuilding in this._unitBuildings) {
            unitBuilding.SetDefaultColorState();
        }
    }
}
