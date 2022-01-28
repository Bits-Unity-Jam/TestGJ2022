using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//—крипт висить на кожному ≥сточн≥ку звуку, в≥н ≥н≥ц≥ал≥зуЇ гучн≥сть сурса ≥ оновлюЇ його при ≥вент≥
public class VolumeController : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    private void Start()
    {
        UpdateVolume();
        SoundManager.Instance.OnVolumeChanged += Instance_OnVolumeChanged;
    }

    private void UpdateVolume()
    {
        audioSource.volume = SoundManager.Instance.Volume;
    }

    private void Instance_OnVolumeChanged(object sender, float e)
    {
        UpdateVolume();
    }

    private void OnDestroy()
    {
        SoundManager.Instance.OnVolumeChanged -= Instance_OnVolumeChanged;
    }
}
