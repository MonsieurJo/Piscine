using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeedIncrease : MonoBehaviour {

    [Header("Player Acceleration")]
    public float addSpeed = 50.0f;
    public float addAcceleration = 10.0f;

    [Header("Wave Acceleration")]
    public float addSpeedWave = 50.0f;
    public float addAccelerationWave = 10.0f;

    public void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.SpeedIncrease(addSpeed, addAcceleration);
            //Destroy(this.gameObject);
        }

        InstaKill wave = collision.gameObject.GetComponent<InstaKill>();
        if (wave)
        {
            wave.SpeedIncrease(addSpeedWave, addAccelerationWave);
        }
    }
}
