using UnityEngine;
using System.Collections;
/// <summary>
/// Script for displaying contextual infos
/// </summary>
public class MouseInfo : MonoBehaviour {
    public GameObject Info;

    void OnMouseOver() {
        this.Info.SetActive(true);
    }

    void OnMouseExit() {
        this.Info.SetActive(false);
    }
}
