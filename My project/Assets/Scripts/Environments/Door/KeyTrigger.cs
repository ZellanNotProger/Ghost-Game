using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    private readonly string _playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            this.gameObject.SetActive(false);
            collision.TryGetComponent(out Key key);
            key.PickUp();
        }
    }
}