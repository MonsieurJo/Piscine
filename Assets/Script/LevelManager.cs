using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }

    public TimeSpan RunningTime { get { return DateTime.UtcNow - _startedTime; } }

    public PlayerManager player;
    public GameObject audioDeath;

    private DateTime _startedTime;
    private Rigidbody _rigidbody;
    private AudioSource _audioSourceDeath;

    private void Awake()
    {
        Instance = this;
        _rigidbody = player.GetComponent<Rigidbody>();
        _audioSourceDeath = audioDeath.GetComponent<AudioSource>();
        Assert.IsNotNull(player);
    }

    private void Start()
    {
        _startedTime = DateTime.UtcNow;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PlayerDeath()
    {
        CameraManager.Instance.currentCamera.transform.parent = null;
        _audioSourceDeath.Play();
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
