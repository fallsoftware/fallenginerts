using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// Script of the assignation of minions by the interface
/// </summary>
public class AssignMinions : MonoBehaviour {
    public Player player;
    public Slider woodSlider;
    public Slider ironSlider;
    public Slider foodSlider;
    public UpdateNumberInputField woodInput;
    public UpdateNumberInputField ironInput;
    public UpdateNumberInputField foodInput;
    /// <summary>
    /// On enable and on update, updatings of the values in the interface
    /// </summary>
	void OnEnable()
    {
        setMaxValue();
        woodSlider.value = player.getNumberWood();
        foodSlider.value = player.getNumberFood();
        ironSlider.value = player.getNumberIron();
    }
    /// <summary>
    /// On enable and on update, updatings of the values in the interface
    /// </summary>
    void Update () {
        setMaxValue();
    }
    /// <summary>
    /// Setting of the maxvalues in the interface
    /// </summary>
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
    public void SetWood()
    {
        player.setMinionWood((int)woodSlider.value);
    }
    public void SetIron()
    {
        player.setMinionIron((int)ironSlider.value);

    }
    public void SetFood()
    {
        player.setMinionFood((int)foodSlider.value);

    }
}
