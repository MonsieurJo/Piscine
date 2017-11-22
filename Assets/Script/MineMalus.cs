using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMalus : Bonus {

    public float damage = 10f;

    public override void ApplyBonus (PlayerManager player)
    {
        player.TakeDamage(damage, gameObject);
        //Destroy(gameObject);
    }
}
