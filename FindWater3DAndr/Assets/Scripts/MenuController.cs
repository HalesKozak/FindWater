using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;

    public AudioMixerGroup mixerGroup;
    public AudioSource clickAudioSource;

    public GameObject[] layoutGroups;

    private SaveOptions saveOptions = new SaveOptions();

    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        _SFXSlider.onValueChanged.AddListener(delegate { ChangeSFXVolume(); });

        if (PlayerPrefs.HasKey("Settings"))
        {
            saveOptions = JsonUtility.FromJson<SaveOptions>(PlayerPrefs.GetString("Settings"));

            _musicSlider.value = saveOptions.musicValue;
            _SFXSlider.value = saveOptions.SFXValue;
        }
        else
        {
            DefaultSettings();
        }
    }

    private void Start()
    {
        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    private void DefaultSettings()
    {
        _musicSlider.value = 0.60f;
        _SFXSlider.value = 0.60f;

        ChangeMusicVolume();
        ChangeSFXVolume();
    }

    private void ChangeMusicVolume()
    {
        mixerGroup.audioMixer.SetFloat("Music", Mathf.Lerp(-70, 5, _musicSlider.value));
    }

    private void ChangeSFXVolume()
    {
        mixerGroup.audioMixer.SetFloat("SFX", Mathf.Lerp(-70, 5, _SFXSlider.value));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickAudio()
    {
        clickAudioSource.Play();
    }

    public void NewGameMenu()
    {
        for (int i = 0; i < 2; i++)
        {
            layoutGroups[i].SetActive(!layoutGroups[i].activeSelf);
        } 
    }

    public void SettingsMenu()
    {
        for (int i = 0; i < 3; i = i+2)
        {
            layoutGroups[i].SetActive(!layoutGroups[i].activeSelf);
        }
    }
    public void SaveSettings()
    {
        saveOptions.musicValue = _musicSlider.value;
        saveOptions.SFXValue = _SFXSlider.value;

        PlayerPrefs.SetString("Settings", JsonUtility.ToJson(saveOptions));
    }

    public void ComeBackMenu(int indexGroup)
    {
        layoutGroups[0].SetActive(!layoutGroups[0].activeSelf);
        layoutGroups[indexGroup].SetActive(!layoutGroups[indexGroup].activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
[Serializable]
public class SaveOptions
{
    public float musicValue;
    public float SFXValue;
}
