using System;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]
public class PlayerSpeedChanger : MonoBehaviour
{
    [SerializeField] private bool _isSpeedShouldIncreasing;
    [SerializeField] private float _startForwardSpeed;
    [SerializeField] private float _speedIncreaseStartDelay;
    [SerializeField] private float _speedIncreaseRepeatDelay;
    [SerializeField] private float _speedIncreaseModifer;
    [SerializeField] private float _maxSpeed;

    public static PlayerSpeedChanger Instance { get; private set; }

    public float ForwardMovementSpeed { 
        get { return Player.Instance.PlayersMovement.ForwardMovementSpeed; }
        set { Player.Instance.PlayersMovement.ForwardMovementSpeed = value; }
    }


    private void Start()
    {
        if (Instance == null)
        {
            Instance = GetComponent<PlayerSpeedChanger>();
            ForwardMovementSpeed = _startForwardSpeed;
            if (_isSpeedShouldIncreasing)
                InvokeRepeating(nameof(IncreaseSpeed), _speedIncreaseStartDelay, _speedIncreaseRepeatDelay);
            else
                Destroy(this);
        }
        else
        {
            Debug.Log("PlayerSpeedChanger script has more then one realizations, all except one deleted.");
            Destroy(this);
        }
    }

    private void IncreaseSpeed()
    {
        if (ForwardMovementSpeed + _speedIncreaseModifer >= _maxSpeed)
            ForwardMovementSpeed = _maxSpeed;
        else
            ForwardMovementSpeed += _speedIncreaseModifer;
    }
}
