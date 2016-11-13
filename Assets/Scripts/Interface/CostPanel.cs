using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CostPanel : MonoBehaviour {
    public Text woodText;
    public Text ironText;
    public Text foodText;
    public Text populationText;
	// Use this for initialization
	void Start () {
	
	}
    public void UpdateCost(int wood,int iron,int food,int population)
    {
        woodText.text = wood.ToString();
        ironText.text = iron.ToString();
        foodText.text = food.ToString();
        populationText.text = population.ToString();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
