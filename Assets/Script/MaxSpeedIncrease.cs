using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxSpeedIncrease : MonoBehaviour {

    public float addSpeed = 50.0f;
    public float addAcceleration = 10.0f;

    public void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.SpeedIncrease(addSpeed, addAcceleration);
            //Destroy(this.gameObject);
        }
    }
}
