using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {
    public GameObject[] UIElements;
    [HideInInspector] public bool MouseOnObject;

	void Start () {
	    this.MouseOnObject = false;
	}
	
	void Update () {
	
	}

    void OnMouseUp() {
        if (!this.MouseOnObject 
            && !EventSystem.current.IsPointerOverGameObject()) {
            this.ShutAllPanels();
        }
    }

    public void ShutAllPanels() {
        foreach (GameObject UIElement in this.UIElements) {
            UIElement.SetActive(false);
        }
    }
}
