﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.SpeedIncrease(1000f, 1000f);
            player.Win();
            Destroy(this.gameObject);
        }
    }
}