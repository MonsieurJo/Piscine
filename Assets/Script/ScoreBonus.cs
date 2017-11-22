using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : Bonus
{

    public int score = 50;

    public override void ApplyBonus (PlayerManager player)
    {
        player.AddScore(score);
        _animator.SetTrigger("Pickup");
    }
}
