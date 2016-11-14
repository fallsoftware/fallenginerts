using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script of gestion of the text for the number of units
/// </summary>
public class UnitNumber : MonoBehaviour {
    private int _minUnitNumber;
    private int _maxUnitNumber;
    private Text _text;
    /// <summary>
    /// Initializing at 0/100
    /// </summary>

    void Start () {
        this._minUnitNumber = 0;
        this._maxUnitNumber = 100;

        this._text = this.GetComponent<Text>();
    }
	
    /// <summary>
    /// update the numbers displayed at the desired amount
    /// </summary>
    /// <param name="number"></param>
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
