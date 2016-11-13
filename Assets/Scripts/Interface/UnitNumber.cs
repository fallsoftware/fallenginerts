using UnityEngine;
using UnityEngine.UI;

public class UnitNumber : MonoBehaviour {
    private int _minUnitNumber;
    private int _maxUnitNumber;
    private Text _text;

    void Start () {
        this._minUnitNumber = 0;
        this._maxUnitNumber = 100;

        this._text = this.GetComponent<Text>();
    }
	
	void Update () {
	
	}

    public void UpdateUnitNumber(float number) {
        if (_text != null)
        {
            int intNumber = (int)number;
            intNumber = Mathf.Max(this._minUnitNumber, intNumber);
            intNumber = Mathf.Min(this._maxUnitNumber, intNumber);
            string units;

            if (intNumber > 1)
            {
                units = "units";
            }
            else
            {
                units = "unit";
            }

            this._text.text = units;
        }
    }
}
