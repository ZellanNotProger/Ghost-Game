using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _keyDescriptionText;

    private readonly string _keyTag = "Key";

    private GameObject _key;
    private bool _isPickedUp;

    private void Start()
    {
        _key = GameObject.FindWithTag(_keyTag);

        _slider.gameObject.SetActive(false);
        _keyDescriptionText.gameObject.SetActive(false);
    }

    public void PickUp()
    {
        if (!_slider.gameObject.activeSelf)
        {
            _slider.value = _slider.maxValue;

            _slider.gameObject.SetActive(true);
            _keyDescriptionText.gameObject.SetActive(true);

            var keyTimer = GetComponent<KeyTimer>();
            keyTimer.StartKeyTimer(true);
        }
    }

    public bool Use()
    {
        return _isPickedUp == true;

        if (_isPickedUp)
        {
            _isPickedUp = false;
        }
    }

    public void BreakKey()
    {
        _isPickedUp = false;

        _key.SetActive(true);
        _slider.gameObject.SetActive(false);
        _keyDescriptionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_keyTag))
        {
            _isPickedUp = true;
        }
    }
}