using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InstaKill : MonoBehaviour {

    [Header("Requirements")]
    public Transform playerTransform;
    public HUDHandler uiHandler;

    [Header("Parameters")]
    public float acceleration = 10f;
    public float maxSpeed = 20f;


    private float _dist;
    private int _distInInt;
    private Rigidbody _rigidbody;
    private float _speedToAdd;
    private float _accelerationToAdd;

    public void Awake()
    {
        _speedToAdd = 0f;
        _accelerationToAdd = 0f;
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(playerTransform);
        Assert.IsNotNull(uiHandler);
    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.Kill();
        }
    }

    public void Update()
    {
        if (playerTransform)
        {
            _dist = Vector3.Distance(playerTransform.position, transform.position);
            if (_dist <= 100f)
            {
                uiHandler.SetTransparency(1f - (_dist / 100f));
            }
            //Debug.Log(_dist);
        }

    }

    public void FixedUpdate()
    {
        Vector3 newVelocity = _rigidbody.velocity;
        if (newVelocity.z > maxSpeed + _speedToAdd)
        {
            newVelocity.z = maxSpeed + _speedToAdd;
        }

        else
        {
            newVelocity.z += (acceleration + _accelerationToAdd) * Time.fixedDeltaTime;
        }

        _rigidbody.velocity = newVelocity;
        //Debug.Log(_rigidbody.velocity);
    }

    public void SpeedIncrease(float addSpeed, float addAcceleration)
    {
        _speedToAdd += addSpeed;
        _accelerationToAdd += addAcceleration;
    }
}
