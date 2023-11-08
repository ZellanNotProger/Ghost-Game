using UnityEngine;

public class CutSceneCP : MonoBehaviour
{
    [SerializeField] private Transform _player, _mist, _mistStartPoint, _playerSpawnPoint;

    private readonly string _playerTag = "Player";

    private bool _isEnterControlPoint;

    public bool CheckInputEntered()
    {
        return _isEnterControlPoint;
    }

    public void ReturnToPoint()
    {
        _mist.position = _mistStartPoint.position;
        _player.position = _playerSpawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            _isEnterControlPoint = true;
        }
    }
}