using System;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSlider : MonoBehaviour {
    private Slider _unitNumberSlider;

    void Start() {
        this._unitNumberSlider = this.GetComponent<Slider>();
    }

    void Update() {}

    public void UpdateNumber(string value) {
        int number = 1;

        Int32.TryParse(value, out number);
        this._unitNumberSlider.value = number;
    }
}