using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNumberInputField : MonoBehaviour {
    private int _min = 0;
    private int _max = 100;
    private InputField _inputField;

	// Use this for initialization
	void Start () {
	    this._inputField = this.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setMax(int newMax)
    {
        _max=newMax;
    }


    public void UpdateNumber(string value)
    {
        if (_inputField != null) {
            int number = 1;

            Int32.TryParse(value, out number);

            number = Mathf.Max(this._min, number);
            number = Mathf.Min(this._max, number);
            this._inputField.text = number.ToString();
        }
    }

    public void UpdateNumberFromFloat(float value) {
        if (_inputField != null)
        {
            int number = (int)value;

            number = Mathf.Max(this._min, number);
            number = Mathf.Min(this._max, number);

            this._inputField.text = number.ToString();
        }
    }
}
