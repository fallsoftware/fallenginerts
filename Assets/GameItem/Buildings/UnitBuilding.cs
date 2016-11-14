using UnityEngine;
using System.Collections;
//Script of the UnitBuilding for the interface (color)
public class UnitBuilding : MonoBehaviour {
    public GameObject Battleground;
    public Color SelectedColor;
    [HideInInspector] public Color DefaultColor;
    [HideInInspector] public MouseManager MouseManager;
    [HideInInspector] public SpriteRenderer SpriteRenderer;

    void Start() {
        this.InitializeFields(); // will initialize the fields needed
    }

    void Update() {

    }

    /// <summary>
    /// set the sprite's color to the selected color, when the building's been
    /// selected
    /// </summary>
    public void SetSelectedColorState() {
        this.SpriteRenderer.color = this.SelectedColor;
    }

    /// <summary>
    /// set the sprite's default color, when the building's not selected
    /// anymore
    /// </summary>
    public void SetDefaultColorState() {
        this.SpriteRenderer.color = this.DefaultColor;
    }

    /// <summary>
    /// function needed to initialize the correct fields
    /// </summary>
    public void InitializeFields() {
        // Mouse manager needed to make the UI work
        this.MouseManager = this.Battleground.GetComponent<MouseManager>();
        this.SpriteRenderer = this.GetComponent<SpriteRenderer>();
        this.DefaultColor = this.SpriteRenderer.color;
        this.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    }

}