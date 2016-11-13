using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of creation of minions by the interface
/// </summary>
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
	/// <summary>
    /// At start, set the selected ressource to wood
    /// </summary>
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
    /// <summary>
    /// At each update, updating of the interface with the maximum buyable minions
    /// </summary>
    void Update () {
        connectedSlider.maxValue = player.maxBuyableUnit(new Minion());
        inputfield.setMax((int)connectedSlider.maxValue);
        int number = (int)connectedSlider.value;
        connectedCostPanel.UpdateCost(number * (int)Minion.foodcost,
            number * (int)Minion.ironcost,
            number * (int)Minion.woodcost,
            number * (int)Minion.populationcost);
    }
    /// <summary>
    /// at the push of the button we buy minions that are put in correspondant list of the player
    /// </summary>
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
