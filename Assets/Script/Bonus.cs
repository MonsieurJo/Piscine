using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public abstract class Bonus : MonoBehaviour
{
    protected Animator _animator;
    protected AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerManager player = other.gameObject.GetComponentInParent<PlayerManager>();
            if (player != null)
            {
                //_audioSource.pitch = Random.Range(-2f, 2f);
                _audioSource.Play();
                ApplyBonus(player);
            }
        }
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public virtual void ApplyBonus( PlayerManager player)
    {

    }
}
