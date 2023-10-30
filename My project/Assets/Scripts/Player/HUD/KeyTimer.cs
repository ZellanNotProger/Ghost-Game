using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyTimer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_InputField _linchpinActionTimeInputField;

    private readonly string _linchpinActionTimeKey = "KeyTime", _linchpinGameObjectKey = "Key";

    private GameObject _linchpinGameObject;
    private float _linchpinActionTime;
    private bool _isStarted;

    void Start()
    {
        _linchpinGameObject = GameObject.FindWithTag(_linchpinGameObjectKey);

        _linchpinActionTime = PlayerPrefs.GetFloat(_linchpinActionTimeKey);

        _slider.maxValue = _linchpinActionTime;
        _slider.value = _linchpinActionTime;

        _linchpinActionTimeInputField.text = _linchpinActionTime.ToString();
    }

    void FixedUpdate()
    {
        Timer();
    }

    public void StartKeyTimer(bool isStarted)
    {
        _isStarted = isStarted;
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
                Key key = GetComponent<Key>();

                key.BreakKey();

                _linchpinGameObject.SetActive(true);
            }
        }
    }

    public void SaveKeyActionTime()
    {
        _linchpinActionTime = float.Parse(_linchpinActionTimeInputField.text);
        _slider.value = _linchpinActionTime;
        _slider.maxValue = _linchpinActionTime;

        PlayerPrefs.SetFloat(_linchpinActionTimeKey, _linchpinActionTime);
    }
}
