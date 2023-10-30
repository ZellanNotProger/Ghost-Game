using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    [SerializeField] private Transform _controlPoint, _mistStartPos;

    private readonly string _playerTag = "Player", _mistTag = "Mist";

    private Transform _player, _mist;

    private void Start()
    {
        _player = GameObject.FindWithTag(_playerTag).transform;
        _mist = GameObject.FindWithTag(_mistTag).transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            _player.position = _controlPoint.position;
            _mist.position = _mistStartPos.position;
        }
    }
}
