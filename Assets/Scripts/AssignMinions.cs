using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AssignMinions : MonoBehaviour {
    public Player player;
    public Slider woodSlider;
    public Slider ironSlider;
    public Slider foodSlider;
    public UpdateNumberInputField woodInput;
    public UpdateNumberInputField ironInput;
    public UpdateNumberInputField foodInput;
    // Use this for initialization
    void Start () {
        
    }
	void OnEnable()
    {
        setMaxValue();
        woodSlider.value = player.getNumberWood();
        foodSlider.value = player.getNumberFood();
        ironSlider.value = player.getNumberIron();
    }
    // Update is called once per frame
    void Update () {
        setMaxValue();
    }
    void setMaxValue()
    {
        int idleminion = player.getNumberIdle();

        woodInput.setMax(player.getNumberWood() + idleminion);
        foodInput.setMax(player.getNumberFood() + idleminion);
        ironInput.setMax(player.getNumberIron() + idleminion);
        woodSlider.maxValue = player.getNumberWood() + idleminion;
        foodSlider.maxValue = player.getNumberFood() + idleminion;
        ironSlider.maxValue = player.getNumberIron() + idleminion;
    }
    void SetWood()
    {
        player.setMinionWood((int)woodSlider.value);
    }
    void SetIron()
    {
        player.setMinionIron((int)ironSlider.value);

    }
    void SetFood()
    {
        player.setMinionFood((int)foodSlider.value);

    }
}
