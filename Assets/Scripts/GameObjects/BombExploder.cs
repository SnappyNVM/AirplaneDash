using UnityEngine;

public class BombExploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        { 
            _explosion.transform.localScale = player.transform.localScale;
            var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            explosion.transform.SetParent(transform);
        }
    }
}
