using UnityEngine;
using UnityEngine.Audio;

public class SettingVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    public void SetLevel (float sliderValue) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
