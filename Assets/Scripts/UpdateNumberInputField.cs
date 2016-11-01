using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateNumberInputField : MonoBehaviour {
    private int _min = 1;
    private int _max = 100;
    private InputField _inputField;

	// Use this for initialization
	void Start () {
	    this._inputField = this.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void UpdateNumber(string value) {
        int number = 1;

        Int32.TryParse(value, out number);

        number = Mathf.Max(this._min, number);
        number = Mathf.Min(this._max, number);

        this._inputField.text = number.ToString();
    }

    public void UpdateNumberFromFloat(float value) {
        int number = (int) value;

        number = Mathf.Max(this._min, number);
        number = Mathf.Min(this._max, number);

        this._inputField.text = number.ToString();
    }
}
