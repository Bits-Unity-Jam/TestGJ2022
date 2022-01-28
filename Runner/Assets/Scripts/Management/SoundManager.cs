
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� �����, �� ���� ������� � ��� ���������� ��� ������� � ���� ����������� ���-�����
//�� ����� ������� ��������������� ��������� ������ ������� � ��������� � ����������� �� ���� �����, ��� ���������� ������� �� ����������.
public class SoundManager : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    [SerializeField]
    float volume;

    [SerializeField]
    string key = "SoundManager/Volume";

    [SerializeField]
    AudioClip buttonSound;

    [SerializeField]
    AudioSource source;

    static SoundManager instance;
    public event EventHandler<float> OnVolumeChanged;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public float Volume
    {
        get => volume;
        set
        {
            volume = value;
            PlayerPrefs.SetFloat(key, volume);
            OnVolumeChanged?.Invoke(this, volume); 
        }
    }

    public static SoundManager Instance { get => instance; private set => instance = value; }

    private void Awake()
    {
        Instance = this;
        Volume = PlayerPrefs.GetFloat(key, 1);
    }

    public void PlayButtonSound()
    {
        source.PlayOneShot(buttonSound);
    }
    public void PlayPickUpSound()
    {
        //audioSource.PlayOneShot(impact, 0.7F);
    }
}

