using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D[] _legs;
    [SerializeField] private FixedJoystick _joystick;
    private PlayerAnimator _playerAnimator;
    private PlayerDirection _playerDirection;
    private Vector2 _direction = new Vector2(1, 1);

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerAnimator>();
        _playerDirection = GetComponent<PlayerDirection>();
    }

    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        var direction = _joystick.Horizontal;
        _playerDirection.ChangeDirection(direction < 0);
        if (direction != 0)
        {
            if (direction > 0)
            {
                _playerAnimator.PlayAnimation(WorldGameInfo.WalkRight);
                StartCoroutine(Move(0, 1, _direction));
            }
            else
            {
                _playerAnimator.PlayAnimation(WorldGameInfo.WalkLeft);
                StartCoroutine(Move(1, 0, -_direction));
            }
        }
        else
        {
            _playerAnimator.PlayAnimation(WorldGameInfo.Idle);
        }
    }

    private IEnumerator Move(int firstLeg, int secondLeg, Vector2 vector)
    {
        var direction = vector * _force * Time.fixedDeltaTime;
        _legs[firstLeg].AddForce(direction);
        yield return new WaitForSeconds(0.5f);
        _legs[secondLeg].AddForce(direction);
    }
}
