using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider, _soundEffectsSlider;
    [SerializeField] private Transform _player, _mist, _mistStartPoint, _playerSpawnPoint;
    [SerializeField] private GameObject _menuCanvas, _hudGameObject;
    [SerializeField] private AudioSource _musicAudio;
    [SerializeField] private AudioSource[] _soundEffectsAudio;

    private static readonly string _musicPref = "MusicPref", _soundEffectsPref = "Sound EffectsPref";

    private void Awake()
    {
        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var canvasState = _menuCanvas.activeSelf;
            if (canvasState == true)
            {
                _menuCanvas.SetActive(!canvasState);
                _hudGameObject.SetActive(true);
                Resume();
            }
            if (canvasState == false)
            {
                _menuCanvas.SetActive(!canvasState);
                _hudGameObject.SetActive(false);
                Pause();
            }
        }
    }

    public void StartNewGame()
    {
        _mist.position = _mistStartPoint.position;
        _player.position = _playerSpawnPoint.position;
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(_musicPref, _musicSlider.value);
        PlayerPrefs.SetFloat(_soundEffectsPref, _soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        _musicAudio.volume = _musicSlider.value;

        for (int i = 0; i < _soundEffectsAudio.Length; i++)
        {
            _soundEffectsAudio[i].volume = _soundEffectsSlider.value;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
