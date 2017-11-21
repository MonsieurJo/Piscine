using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBonus : Bonus
{
    public int amount = 1;

	public override void ApplyBonus(PlayerManager player)
    {
        player.ammo += amount;
        Destroy(gameObject);
    }
}
