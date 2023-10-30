using UnityEngine;

public class MistTrigger : MonoBehaviour
{
    [SerializeField] private Transform _mistStartPos, _mistTransform, _playerSpawnPos;
    [SerializeField] private CutSceneCP _cutSceneControlPoint;

    private readonly string _playerTag = "Player", _doorTag = "Door";

    private GameObject _door;

    private void Start()
    {
        _cutSceneControlPoint.GetComponent<CutSceneCP>();

        _door = GameObject.FindWithTag(_doorTag);
        _mistTransform.position = _mistStartPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            if (_cutSceneControlPoint.CheckInputEntered() == true)
            {
                _cutSceneControlPoint.ReturnToPoint();
            }
            else
            {
                collision.TryGetComponent(out Key key);

                key.BreakKey();
                _door.SetActive(true);

                _mistTransform.position = _mistStartPos.position;
                key.transform.position = _playerSpawnPos.position;
            }

        }
    }
}