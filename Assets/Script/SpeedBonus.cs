using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : Bonus {

    public float velocity = 100f;
    public float duration = 2.5f;
    public float acceleration = 50f;

    public override void ApplyBonus (PlayerManager player)
    {
        player.BoostSpeed(velocity, duration, acceleration);
        Destroy(gameObject);
    }
}
