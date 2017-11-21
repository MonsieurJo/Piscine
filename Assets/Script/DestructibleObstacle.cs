using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour, ITakeDamage {

    public float maxHealth = 100f;

    private float _currentHealth;

	// Use this for initialization
	void Start () {
        _currentHealth = maxHealth;
	}
	
	public void TakeDamage(float damage, GameObject instigator)
    {
        if (this.enabled)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0f)
            {
                Kill();
            }
        }
        
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
