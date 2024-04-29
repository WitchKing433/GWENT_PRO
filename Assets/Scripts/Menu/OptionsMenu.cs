using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void ScreenMode(bool bFullScreen)
    {
        Screen.fullScreen = bFullScreen;
    }

    public void ChangeMusicVol(float fMusicVol)
    {
        audioMixer.SetFloat("MusicVol", fMusicVol);
    }

    public void Quality(int iQuality)
    {
        QualitySettings.SetQualityLevel(iQuality);
    }
}
