using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    private readonly string _playerTag = "Player";

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            collision.TryGetComponent(out Key key);

            if (key.Use())
            {
                if (Input.GetKey(KeyCode.E))
                {
                    _door.SetActive(false);
                }
            }
        }
    }
}