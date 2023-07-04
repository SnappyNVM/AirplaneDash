using UnityEngine;

public class BombExploder : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _scaleModifer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        { 
            var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            explosion.transform.localScale = player.transform.localScale * _scaleModifer;
            Destroy(gameObject);
        }
    }
}
