using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }

    public TimeSpan RunningTime { get { return DateTime.UtcNow - _startedTime; } }

    public PlayerManager player;

    private DateTime _startedTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        Instance = this;
        _rigidbody = player.GetComponent<Rigidbody>();
        Assert.IsNotNull(player);
    }

    private void Start()
    {
        _startedTime = DateTime.UtcNow;
    }

    public void PlayerDeath()
    {
        CameraManager.Instance.currentCamera.transform.parent = null;
        Destroy(player.gameObject);
    }

    public void PlayerWin()
    {
        Vector3 newVelocity = _rigidbody.velocity;
        newVelocity.z = _rigidbody.velocity.z + 100f;
        _rigidbody.velocity = newVelocity;
        CameraManager.Instance.currentCamera.transform.parent = null;
    }
}
