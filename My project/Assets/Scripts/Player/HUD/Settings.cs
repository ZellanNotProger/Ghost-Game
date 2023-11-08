using UnityEngine;

public class Settings : MonoBehaviour
{
    private readonly string _fullscreenPref = "FullscreenPreference";

    private void Start()
    {
        LoadSettings();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt(_fullscreenPref, System.Convert.ToInt32(Screen.fullScreen));
    }

    private void LoadSettings()
    {
        if (PlayerPrefs.HasKey(_fullscreenPref))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt(_fullscreenPref));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
