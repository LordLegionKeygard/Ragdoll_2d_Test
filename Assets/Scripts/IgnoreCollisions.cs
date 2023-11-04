using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    [SerializeField] private Collider2D[] _colliders;

    private void Awake()
    {
        Ignore();
    }

    private void Ignore()
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            for (int l = i + 1; l < _colliders.Length; l++)
            {
                Physics2D.IgnoreCollision(_colliders[i], _colliders[l]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(WorldGameInfo.PlayerTag))
        {
            Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }
}
