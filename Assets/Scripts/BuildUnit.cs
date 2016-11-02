using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    // Use this for initialization
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
    // Update is called once per frame
    void Update()
    {
        int woodprice = 0;
        int foodprice = 0;
        int ironprice = 0;
        int populationprice = 0;
        int maxunit=0;
        switch (selectedUnit)
        {
            case UnitType.SWORDSMAN:
                {
                    maxunit = player.maxBuyableSwordsman();
                    woodprice =(int) Swordsman.PRICE.WOOD;
                    foodprice = (int)Swordsman.PRICE.FOOD;
                    ironprice = (int)Swordsman.PRICE.IRON;
                    populationprice = (int)Swordsman.PRICE.POPULATION;
                    break;
                }
            case UnitType.HORSEMAN:
                {
                    maxunit = player.maxBuyableHorseman();
                    woodprice = (int)Horseman.PRICE.WOOD;
                    foodprice = (int)Horseman.PRICE.FOOD;
                    ironprice = (int)Horseman.PRICE.IRON;
                    populationprice = (int)Horseman.PRICE.POPULATION;
                    break;
                }
            case UnitType.BOWMAN:
                {
                    maxunit = player.maxBuyableBowman();
                    woodprice = (int)Bowman.PRICE.WOOD;
                    foodprice = (int)Bowman.PRICE.FOOD;
                    ironprice = (int)Bowman.PRICE.IRON;
                    populationprice = (int)Bowman.PRICE.POPULATION;
                    break;
                }
        }
        connectedSlider.maxValue = maxunit;
        inputfield.setMax(maxunit);
        int number = (int)connectedSlider.value;
        connectedCostPanel.UpdateCost(number * foodprice,
            number * ironprice,
            number * woodprice,
            number * populationprice);
    }
    public void BuyUnit()
    {
        switch (selectedUnit)
        {
            case UnitType.SWORDSMAN:
                {
                    player.BuySwordsman((int)connectedSlider.value);
                    break;
                }
            case UnitType.HORSEMAN:
                {
                    player.BuyHorseman((int)connectedSlider.value);
                    break;
                }
            case UnitType.BOWMAN:
                {
                    player.BuyBowman((int)connectedSlider.value);
                    break;
                }
        }
    }
}
