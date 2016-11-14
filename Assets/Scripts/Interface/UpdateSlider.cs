using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// script of gestion of the slider
/// </summary>
public class UpdateSlider : MonoBehaviour {
    private Slider _unitNumberSlider;

    void Start() {
        this._unitNumberSlider = this.GetComponent<Slider>();
    }

    /// <summary>
    /// Update of the slider with a number
    /// </summary>
    /// <param name="value"></param>
    public void UpdateNumber(string value) {
        int number = 1;

        Int32.TryParse(value, out number);
        this._unitNumberSlider.value = number;
    }
}