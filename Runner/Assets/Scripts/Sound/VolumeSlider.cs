using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��� ��� �������� ������� �������, ����� ������������� ������� � ��������� ���������, � �� ��� ��� ��������� �������� �� ���-������ ���� ������� � ��������
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
