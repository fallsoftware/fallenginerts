using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuildMinion : MonoBehaviour {

    private RessourceType selectedRessource;
    public Player player;
    public Slider connectedSlider;
    public Image connectedImage;
    public Sprite woodSprite;
    public Sprite ironSprite;
    public Sprite foodSprite;
    public CostPanel connectedCostPanel;
    public UpdateNumberInputField inputfield;
	// Use this for initialization
	void Start () {
        SetRessourceToWood();
    }
	public void SetRessourceToIron()
    {
        this.selectedRessource = RessourceType.IRON;
        connectedImage.sprite = ironSprite;
    }

    public void SetRessourceToFood()
    {
        this.selectedRessource = RessourceType.FOOD;
        connectedImage.sprite = foodSprite;

    }
    public void SetRessourceToWood()
    {
        this.selectedRessource = RessourceType.WOOD;
        connectedImage.sprite = woodSprite;
    }
    // Update is called once per frame
    void Update () {
        connectedSlider.maxValue = player.maxBuyableUnit(new Minion());
        inputfield.setMax((int)connectedSlider.maxValue);
        int number = (int)connectedSlider.value;
        connectedCostPanel.UpdateCost(number * (int)Minion.foodcost,
            number * (int)Minion.ironcost,
            number * (int)Minion.woodcost,
            number * (int)Minion.populationcost);
    }
    public void BuyMinion()
    {
        switch(selectedRessource){
            case RessourceType.WOOD:
                {
                    player.BuyMinionWood((int)connectedSlider.value);
                    break;
                }
            case RessourceType.FOOD:
                {
                    player.BuyMinionFood((int)connectedSlider.value);
                    break;
                }
            case RessourceType.IRON:
                {
                    player.BuyMinionIron((int)connectedSlider.value);
                    break;
                }
        }
    }
}
