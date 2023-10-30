using UnityEngine;

public class ItemPickUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private string _effectDescription;

    private readonly string _playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out EffectTimer effectTimer);

        if (collision.CompareTag(_playerTag))
        {
            _gameObject.SetActive(false);

            effectTimer.StartEffectTimer(_effectDescription);
        }
    }
}
