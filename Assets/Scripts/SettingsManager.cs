using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; // Needed for handling volume
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;
    private AudioSource[] audioSources;

    private Resolution[] resolutions;

    void Start()
    {
        // Populate the resolution dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Get all AudioSources in the scene
        audioSources = FindObjectsOfType<AudioSource>();

        // Load saved volume
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        // Load saved settings
        fullscreenToggle.isOn = Screen.fullScreen;
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);
        
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume)
    {
        // Update the volume of all AudioSources
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        // Save volume settings
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
}
