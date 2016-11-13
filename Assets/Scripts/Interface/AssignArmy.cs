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
    public Transform Lane1;
    public Transform Lane2;
    public Transform Lane3;
    public Dropdown Chooser;
    public AudioClip LaunchArmySound;
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
    public void SendArmy()
    {
        MovingArmy currentArmy = Instantiate(army).GetComponent<MovingArmy>();
        currentArmy.player = player;
        currentArmy.army = new Army(player);
        Army currentRealArmy = currentArmy.army;
        currentRealArmy.swordsmanCount = (int)swordsmanSlider.value;
        currentRealArmy.horsemanCount = (int)horsemanSlider.value;
        currentRealArmy.bowmanCount = (int)bowmanSlider.value;
        if (currentRealArmy.TotalUnit > 0){
            switch (Chooser.value)
            {
                case 0:
                    {
                        currentArmy.transform.position = Lane1.position;
                        break;
                    }
                case 1:
                    {
                        currentArmy.transform.position = Lane2.position;
                        break;
                    }
                case 2:
                    {
                        currentArmy.transform.position = Lane3.position;
                        break;
                    }
            }
        }
        player.reserveArmy.swordsmanCount -= currentRealArmy.swordsmanCount;
        player.reserveArmy.bowmanCount -= currentRealArmy.bowmanCount;
        player.reserveArmy.horsemanCount -= currentRealArmy.horsemanCount;
        SoundManager.instance.RandomizeSfx(this.LaunchArmySound);
    }

}
