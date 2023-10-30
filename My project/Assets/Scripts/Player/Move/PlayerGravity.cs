using TMPro;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    private readonly string _gravityKey = "GravityForce";

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = PlayerPrefs.GetFloat(_gravityKey);
        _inputField.text = _rigidbody.gravityScale.ToString();
    }

    public void SaveGravitySettings()
    {
        _rigidbody.gravityScale = float.Parse(_inputField.text);
        PlayerPrefs.SetFloat(_gravityKey, _rigidbody.gravityScale);
    }
}