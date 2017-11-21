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

    private void Awake()
    {
        Instance = this;
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
        CameraManager.Instance.currentCamera.transform.parent = null;
    }
}
