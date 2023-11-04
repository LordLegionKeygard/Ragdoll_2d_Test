using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMove : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _aimTrans;
    [SerializeField] private Transform _body;

    private void Update()
    {
        Vector2 deltaValue = _joystick.Direction;
        deltaValue *= 20 * Time.deltaTime;

        Vector2 currentPosition = _aimTrans.position;
        Vector2 newPosition = currentPosition + deltaValue;

        newPosition.x = Mathf.Clamp(newPosition.x, _body.position.x - 8, _body.position.x + 8);
        newPosition.y = Mathf.Clamp(newPosition.y, _body.position.y - 5, _body.position.y + 5);

        _aimTrans.position = new Vector2(newPosition.x, newPosition.y);
    }
}
