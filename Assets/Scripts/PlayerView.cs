using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _headSprite;
    [SerializeField] private HingeJoint2D[] _hingeJoints;
    private PlayerDirection _playerDirection;

    private void Awake()
    {
        _playerDirection = GetComponent<PlayerDirection>();
    }

    public void UpdateView()
    {
        _headSprite.flipX = _playerDirection.IsRight;
        var vec = (_playerDirection.IsRight) ? new Vector2(0.1f, 0.15f) : new Vector2(-0.1f, 0.15f);
        _hingeJoints[0].anchor = vec;
        _hingeJoints[1].anchor = vec;
    }
}
