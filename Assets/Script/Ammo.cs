using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    public void OnTriggerEnter(Collider collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
        //    player.PickUpAmmo();
            Destroy(this.gameObject);
        }
    }
}
