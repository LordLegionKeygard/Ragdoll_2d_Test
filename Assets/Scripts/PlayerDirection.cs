using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField] private bool _currentDirectionIsRight;
    public bool IsRight => _currentDirectionIsRight;
    private PlayerView _playerView;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView>();
    }
    public void ChangeDirection(bool isRight)
    {
        if (isRight == _currentDirectionIsRight) return;

        _currentDirectionIsRight = isRight;
        _playerView.UpdateView();
        CustomEvents.FirePlayerChangeDirection();
    }
}
