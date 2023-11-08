using UnityEngine;
using TMPro;

public class GhostTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _visualTrigger;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private TMP_InputField _moveSpeedInputField, _circleColliderInputField;
    [SerializeField] private Transform targetPoint;

    private readonly string playerTag = "Player", _moveSpeedKey = "GhostSpeed", _circleColliderRadiusKey = "CircleColliderRadius";

    private float _moveSpeed, _circleColliderRadius;
    private Transform _player;
    private bool playerInSight = false;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(playerTag).transform;

        _circleColliderInputField.text = PlayerPrefs.GetFloat(_circleColliderRadiusKey).ToString();
        _moveSpeedInputField.text = PlayerPrefs.GetFloat(_moveSpeedKey).ToString();

        SaveSpeedGhostSettings();
    }

    public void SaveSpeedGhostSettings()
    {
        _moveSpeed = float.Parse(_moveSpeedInputField.text);
        _circleColliderRadius = float.Parse(_circleColliderInputField.text);

        _circleCollider.radius = _circleColliderRadius;

        float rad = _circleColliderRadius * 6.03f;

        _visualTrigger.localScale = new Vector3(rad, rad, 0f);

        PlayerPrefs.SetFloat(_moveSpeedKey, _moveSpeed);
        PlayerPrefs.SetFloat(_circleColliderRadiusKey, _circleColliderRadius);
    }

    private void Update()
    {
        if (!playerInSight && targetPoint != null)
        {
            Vector2 moveDirection = new Vector2(targetPoint.position.x - transform.position.x, 0);
            _rigidbody.velocity = moveDirection * Time.deltaTime * _moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            _rigidbody.velocity = Vector2.zero;
            playerInSight = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            Vector2 moveDirection = new Vector2((_player.position.x - transform.position.x), 0);
            _rigidbody.velocity = moveDirection * Time.deltaTime  * _moveSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerInSight = false;
        }
    }
}