using TMPro;
using UnityEngine;

public class MistMovement : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    private readonly string _speedKey = "MistSpeed";

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Start()
    {
        _speed = PlayerPrefs.GetFloat(_speedKey);
        _inputField.text = _speed.ToString();


        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var horizontalOffset = Time.fixedDeltaTime * _speed;

        _rigidbody.velocity = new Vector2(horizontalOffset, 0);
    }

    public void SaveSpeedSettigs()
    {
        _speed = float.Parse(_inputField.text);
        PlayerPrefs.SetFloat(_speedKey, _speed);
    }
}
