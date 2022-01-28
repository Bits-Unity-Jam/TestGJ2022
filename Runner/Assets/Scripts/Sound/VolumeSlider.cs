using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ось так робиться слайдер гучності, якому виставляється гучність з звукового менеджера, і він при зміні положення ползунка по юніті-івенту міняє гучність в менеджері
public class VolumeSlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    private void Start()
    {
        slider.value = SoundManager.Instance.Volume;
        slider.onValueChanged.AddListener(ValueChanged);
    }

    public void ValueChanged(float value)
    {
        SoundManager.Instance.Volume = value;
    }
}
