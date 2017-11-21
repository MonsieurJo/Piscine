using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Bonus : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        PlayerManager player = other.gameObject.GetComponentInParent<PlayerManager>();
        if (player != null)
        {
            ApplyBonus(player);
        }
    }

    public virtual void ApplyBonus( PlayerManager player)
    {

    }
}
