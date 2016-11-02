using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AssignArmy : MonoBehaviour {
    public Player player;
    public Slider swordsmanSlider;
    public Slider bowmanSlider;
    public Slider horsemanSlider;
    public GameObject army;
    public UpdateNumberInputField swordsmanInput;
    public UpdateNumberInputField bowmanInput;
    public UpdateNumberInputField horsemanInput;
    // Use this for initialization
    void Start () {
        
    }
	void OnEnable()
    {
        setMaxValue();
    }
    // Update is called once per frame
    void Update () {
        setMaxValue();
    }
    void setMaxValue()
    {
        int idleminion = player.getNumberIdle();

        bowmanInput.setMax(player.reserveArmy.bowmanCount);
        bowmanSlider.maxValue = player.reserveArmy.bowmanCount;
        horsemanInput.setMax(player.reserveArmy.horsemanCount);
        horsemanSlider.maxValue = player.reserveArmy.horsemanCount;
        swordsmanInput.setMax(player.reserveArmy.swordsmanCount);
        swordsmanSlider.maxValue = player.reserveArmy.swordsmanCount;
    }
    void SendArmy()
    {
        Army currentArmy=Instantiate(army).GetComponent<Army>();
        currentArmy.swordsmanCount = (int)swordsmanSlider.value;
        currentArmy.horsemanCount = (int)horsemanSlider.value;
        currentArmy.bowmanCount = (int)bowmanSlider.value;
        currentArmy.player = player;
    }

}
