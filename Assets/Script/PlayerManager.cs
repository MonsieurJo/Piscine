using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerManager : MonoBehaviour {

    public Projectile projectilePrefab;

    public HUDHandler UiHandler;

    public GameObject spawnPosition;

    public float maxHealth = 100f;
    public int ammo = 3;
    public float maxSpeed = 100f;
	public float forwardAcceleration = 20f;
    public int score { get; private set; }

    public float straffMaxSpeed = 100f;
    public float straffTime = 0.1f;


	private Rigidbody _rigidbody;
    private Transform _spawnPosition;
	private float _smoothXVelocity;
	private float _smoothYVelocity;
    public float currentHealth;

    private float _boostAcceleration = 0f;
    private float _boostDuration = 0f;
    private float _boostTimer = 0f;
    private float _velocityBoost = 0f;
    //private float _playerRotation = 0f;
    //private int _currentAmmo;

	private void Awake(){
		_rigidbody = GetComponent<Rigidbody>();
        _spawnPosition = spawnPosition.transform;
        // _currentAmmo = maxAmmo;
        currentHealth = maxHealth;
        Assert.IsNotNull(_rigidbody);
        Assert.IsNotNull(_spawnPosition);
        Assert.IsNotNull(projectilePrefab);
        Assert.IsNotNull(UiHandler);
    }

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            SpawnProjectile();
            //_currentAmmo--;
        }

        if (_velocityBoost > 0)
        {
            if(_boostTimer >= _boostDuration)
            {
                _velocityBoost = 0f;
                _boostTimer = 0f;
                _boostDuration = 0f;
                _boostAcceleration = 0f;
            }
            _boostTimer += Time.deltaTime;
            
        }
    }

    private void SpawnProjectile()
    {
        ammo--;
        Projectile projectile = (Projectile)Instantiate(projectilePrefab, _spawnPosition.position, Quaternion.identity);
        Vector3 initialVelocity = _rigidbody.velocity;
        initialVelocity.x = 0f;
        initialVelocity.y = 0f;
        projectile.Fire(initialVelocity);
    }

    private void FixedUpdate()
    {
		Vector3 newVelocity = _rigidbody.velocity;
		if (newVelocity.z > maxSpeed + _velocityBoost)
        {
			newVelocity.z = maxSpeed + _velocityBoost;
		}
        
		else
        {
			newVelocity.z += (forwardAcceleration + _boostAcceleration) * Time.fixedDeltaTime;
		}

        float targetXVelocity = Input.GetAxis("Horizontal") * straffMaxSpeed;
        float targetYVelocity = Input.GetAxis("Vertical") * straffMaxSpeed;

        newVelocity.x = Mathf.SmoothDamp(newVelocity.x, targetXVelocity, ref _smoothXVelocity, straffTime);
        newVelocity.y = Mathf.SmoothDamp(newVelocity.y, targetYVelocity, ref _smoothYVelocity, straffTime);

        if (newVelocity.z < 0)
        {
            newVelocity.z = 0;
            newVelocity.x = 0;
        }

        _rigidbody.velocity = newVelocity;
	}
	
	// Update is called once per frame
	private void LateUpdate ()
    {
		//Debug.Log(_rigidbody.velocity.z);
        //Debug.Log(LevelManager.Instance.RunningTime);
	}

    public void Kill()
    {
        currentHealth = 0;
        LevelManager.Instance.PlayerDeath();
    }

    public void Win()
    {
        LevelManager.Instance.PlayerWin();
    }

    //public void PickUpAmmo()
    //{
    //    if (_currentAmmo < maxAmmo)
    //    {
    //        _currentAmmo++;
    //    }
    //}

    public void TakeDamage(float damage, GameObject instigator)
    {
        if (currentHealth - damage > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            currentHealth = 0f;
            Kill();
        }
        UiHandler.TakeDamage();
    }

    public void BoostSpeed(float velocity, float duration, float acceleration)
    {
        _velocityBoost = velocity;
        _boostDuration = duration;
        _boostAcceleration = acceleration;
    }

    public void AddScore (int scoreValue)
    {
        score += scoreValue;
    }
}
