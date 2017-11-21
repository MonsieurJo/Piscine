using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Projectile : MonoBehaviour {

    public float damage = 100f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Assert.IsNotNull(_rigidbody);
    }

    public void Fire(Vector3 initialVelocity)
    {
        _rigidbody.velocity = initialVelocity;
    }

    public void OnCollisionEnter(Collision collision)
    {
        ITakeDamage damageable = collision.gameObject.GetComponentInParent<ITakeDamage>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage, this.gameObject);
        }

        Destroy(this.gameObject);
    }
}
