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
        this.InitializeFields();
    }

    void Update() {

    }

    public void SetSelectedColorState() {
        this.SpriteRenderer.color = this.SelectedColor;
    }

    public void SetDefaultColorState() {
        this.SpriteRenderer.color = this.DefaultColor;
    }

    public void InitializeFields() {
        this.MouseManager = this.Battleground.GetComponent<MouseManager>();
        this.SpriteRenderer = this.GetComponent<SpriteRenderer>();
        this.DefaultColor = this.SpriteRenderer.color;
        this.gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    }

}