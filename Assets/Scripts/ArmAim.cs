using UnityEngine;

public class ArmAim : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _aimTrans;
    private int _speed = 10;
    private Rigidbody2D _rb;
    private bool _isAim;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CustomEvents.OnAimToggle += IsAim;
    }

    private void IsAim(bool state) => _isAim = state;

    private void FixedUpdate()
    {
        if (!_isAim) return;
        
        Vector3 difference = _aimTrans.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;

        _rb.MoveRotation(Mathf.LerpAngle(_rb.rotation, rotationZ, _speed * Time.fixedDeltaTime));
    }

    private void OnDestroy()
    {
        CustomEvents.OnAimToggle -= IsAim;
    }
}
