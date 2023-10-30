using TMPro;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private TMP_InputField _firstJumpForceInputField, _secondJumpForceInputField, _maxJumpsInputField;

    private float _firstJumpForce, _secondJumpForce;
    private int _maxJumps, _jumpsRemaining;

    private readonly string _groundTag = "Ground", _firstJumpForceKey = "FirstJumpForce", _secondJumpForceKey = "SecondJumpForce", _maxJumpsKey = "MaxAmountOfJumps";

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _firstJumpForce = PlayerPrefs.GetFloat(_firstJumpForceKey);
        _secondJumpForce = PlayerPrefs.GetFloat(_secondJumpForceKey);
        _jumpsRemaining = PlayerPrefs.GetInt(_maxJumpsKey);

        _firstJumpForceInputField.text = _firstJumpForce.ToString();
        _secondJumpForceInputField.text = _secondJumpForce.ToString();
        _maxJumpsInputField.text = _jumpsRemaining.ToString();

        SaveJumpSettings();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumpsRemaining > 0)
        {
            if (_jumpsRemaining == _maxJumps)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _firstJumpForce);
            }
            else
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _secondJumpForce);
            }

            _jumpsRemaining--;
        }
    }

    public void SaveJumpSettings()
    {
        _firstJumpForce = float.Parse(_firstJumpForceInputField.text);
        _secondJumpForce = float.Parse(_secondJumpForceInputField.text);
        _maxJumps = int.Parse(_maxJumpsInputField.text);

        _jumpsRemaining = _maxJumps;

        PlayerPrefs.SetFloat(_firstJumpForceKey, _firstJumpForce);
        PlayerPrefs.SetFloat(_secondJumpForceKey, _secondJumpForce);
        PlayerPrefs.SetInt(_maxJumpsKey, _maxJumps);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_groundTag))
        {
            _jumpsRemaining = _maxJumps;
        }
    }
}