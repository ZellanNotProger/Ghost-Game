using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectTimer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_InputField _effectTimeInputField;
    [SerializeField] private Key _key;
    [SerializeField] private TMP_Text _text;

    private readonly string _effectTimeKey = "EffectTime", _recoveringShardKey = "RecoveringShard";

    private GameObject _recoveringShard;
    private float _effectTime;
    private bool _isStarted;

    void Start()
    {
        _recoveringShard = GameObject.FindWithTag(_recoveringShardKey);

        _slider.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);

        _effectTime = PlayerPrefs.GetFloat(_effectTimeKey);

        _slider.maxValue = _effectTime;
        _slider.value = _effectTime;

        _effectTimeInputField.text = _effectTime.ToString();
    }

    void FixedUpdate()
    {
        Timer();
    }

    public void StartEffectTimer(string description)
    {
        ResetEffectTimer();
        _key.BreakKey();

        _text.text = description;

        _slider.value = _slider.maxValue;

        _text.gameObject.SetActive(true);
        _slider.gameObject.SetActive(true);

        _isStarted = true;
    }

    private void Timer()
    {
        if (_isStarted)
        {
            if (_slider.value != 0)
            {
                _slider.value -= Time.deltaTime;
            }
            else
            {
                ResetEffectTimer();
            }
        }
    }

    public void ResetEffectTimer()
    {
        _isStarted = false;
        _slider.value = 0;
        _recoveringShard.SetActive(true);
        _text.gameObject.SetActive(false);
        _slider.gameObject.SetActive(false);
    }

    public void SaveEffectTime()
    {
        _effectTime = float.Parse(_effectTimeInputField.text);
        _slider.value = _effectTime;
        _slider.maxValue = _effectTime;

        PlayerPrefs.SetFloat(_effectTimeKey, _effectTime);
    }
}