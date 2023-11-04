using UnityEngine;

public class RagdollBalance : MonoBehaviour
{
    [SerializeField] private float _targetRotation;
    [SerializeField] private float _force;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.MoveRotation(Mathf.LerpAngle(_rb.rotation, _targetRotation, _force * Time.fixedDeltaTime));
    }

}
