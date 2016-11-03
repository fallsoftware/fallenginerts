using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {
    public GameObject[] UIElements;
    public GameObject[] BuildingElements;
    [HideInInspector] public bool MouseOnObject;
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
