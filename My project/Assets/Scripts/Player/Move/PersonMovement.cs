using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_InputField _speedInputField, _dashForceInputField, _dashCooldownInputField;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    private readonly string _runningBool = "IsRunning", _speedKey = "PlayerSpeed", _dashCooldownKey = "DashCooldown", _dashForceKey = "DashForce", _horizontal = "Horizontal";

    private float _speed, _dashCooldown, _dashForce;
    private bool _isFacingRight = true, _canDash = true;

    private void Start()
    {
        _speed = PlayerPrefs.GetFloat(_speedKey);
        _dashCooldown = PlayerPrefs.GetFloat(_dashCooldownKey);
        _dashForce = PlayerPrefs.GetFloat(_dashForceKey);

        _slider.maxValue = _dashCooldown;
        _slider.value = _dashCooldown;

        _speedInputField.text = _speed.ToString();
        _dashForceInputField.text = _dashForce.ToString();
        _dashCooldownInputField.text = _dashCooldown.ToString();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis(_horizontal);
        Move(horizontal);
    }

    private void Move(float horizontal)
    {
        SetSpeed(horizontal);

        if (Input.GetKey(KeyCode.LeftShift) && _canDash)
        {
            Dash();
            _canDash = false;
            _slider.value = 0;
        }

        Timer();
        SetAnimation(horizontal);
    }

    public void SaveSpeedSettings()
    {
        _speed = float.Parse(_speedInputField.text);
        _dashCooldown = float.Parse(_dashCooldownInputField.text);
        _dashForce = float.Parse(_dashForceInputField.text);

        _slider.maxValue = _dashCooldown;

        PlayerPrefs.SetFloat(_dashForceKey, _dashForce);
        PlayerPrefs.SetFloat(_dashCooldownKey, _dashCooldown);
        PlayerPrefs.SetFloat(_speedKey, _speed);
    }

    private void SetSpeed(float horizontal)
    {
        var horizontalOffset = Time.fixedDeltaTime * horizontal * _speed;
        var verticalOffset = _rigidbody.velocity.y;
        _rigidbody.velocity = new Vector2(horizontalOffset, verticalOffset);
    }

    private void Dash()
    {
        float dashDirection = _isFacingRight ? 1f : -1f;
        _rigidbody.velocity = new Vector2(dashDirection * _dashForce, _rigidbody.velocity.y);
    }

    private void Timer()
    {
        if (_slider.value < _slider.maxValue)
        {
            _slider.value += Time.deltaTime;
            if (_slider.value == _slider.maxValue)
            {
                _canDash = true;
            }
        }
    }

    private void SetAnimation(float horizontal)
    {
        bool isRunning = Mathf.Abs(horizontal) > 0;
        _animator.SetBool(_runningBool, isRunning);

        if (horizontal < 0 && _isFacingRight || horizontal > 0 && !_isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}