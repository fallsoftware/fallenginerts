using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script for the building of units by the interface
/// </summary>
public class BuildUnit : MonoBehaviour
{

    private UnitType selectedUnit;
    public Player player;
    public Slider connectedSlider;
    public Image connectedImage;
    public Sprite bowSprite;
    public Sprite swordSprite;
    public Sprite horseSprite;
    public CostPanel connectedCostPanel;
    public UpdateNumberInputField inputfield;
    /// <summary>
    /// Set the selected unit to sword at start
    /// </summary>
    void Start()
    {
        SetUnitToSwordsman();
    }
    public void SetUnitToSwordsman()
    {
        this.selectedUnit = UnitType.SWORDSMAN;
        connectedImage.sprite = swordSprite;
    }

    public void SetUnitToHorseman()
    {
        this.selectedUnit = UnitType.HORSEMAN;
        connectedImage.sprite = horseSprite;

    }
    public void SetUnitToBowman()
    {
        this.selectedUnit = UnitType.BOWMAN;
        connectedImage.sprite = bowSprite;
    }
    /// <summary>
    /// At update, update the cost of the units selected
    /// </summary>
    void Update()
    {
       
        switch (selectedUnit)
        {
            case UnitType.SWORDSMAN:
                {
                    printUnitCost(new Swordsman());
                    break;
                }
            case UnitType.HORSEMAN:
                {
                    printUnitCost(new Horseman());
                    break;
                }
            case UnitType.BOWMAN:
                {
                    printUnitCost(new Bowman());
                    break;
                }
        }
        
    }
    /// <summary>
    /// Calculation and printing of the price of the units selected
    /// </summary>
    /// <param name="unit"></param>
    private void printUnitCost(Unit unit)
    {
        int woodprice = unit.GetWoodCost();
        int foodprice = unit.GetFoodCost();
        int ironprice = unit.GetIronCost();
        int populationprice = unit.GetPopulationCost();
        int maxunit = 0;
        maxunit = player.maxBuyableUnit(unit);
        connectedSlider.maxValue = maxunit;
        inputfield.setMax(maxunit);
        int number = (int)connectedSlider.value;
        connectedCostPanel.UpdateCost(number * foodprice,
            number * ironprice,
            number * woodprice,
            number * populationprice);
    }
    /// <summary>
    /// On push on the button we buy what is selected
    /// </summary>
    public void BuyUnit()
    {
        switch (selectedUnit)
        {
            case UnitType.SWORDSMAN:
                {
                    player.BuyUnit((int)connectedSlider.value,new Swordsman());
                    break;
                }
            case UnitType.HORSEMAN:
                {
                    player.BuyUnit((int)connectedSlider.value, new Horseman());
                    break;
                }
            case UnitType.BOWMAN:
                {
                    player.BuyUnit((int)connectedSlider.value, new Bowman());
                    break;
                }
        }
    }
}
