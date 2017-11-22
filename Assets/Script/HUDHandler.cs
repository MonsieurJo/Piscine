using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions;


[RequireComponent(typeof(Animator))]
public class HUDHandler : MonoBehaviour {

    [Header("Game")]
    public PlayerManager player;

    [Header("Interface")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBar;

    [Header("Settings")]
    public float scoreFrameIncrement = 100f;

    private Animator _animator;
    private int _currentScore;

    private void Awake()
    {
        Assert.IsNotNull(player);
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(ammoText);
        Assert.IsNotNull(healthBar);
        _currentScore = 0;

        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            ammoText.text = "x " + player.ammo;
            healthBar.fillAmount = Mathf.Max(0, player.currentHealth / player.maxHealth);
            if(healthBar.fillAmount >= 0.8f)
            {
                healthBar.color = new Color(0, 255, 0);
            }
            else if(healthBar.fillAmount >= 0.4f)
            {
                healthBar.color = new Color(255f, 120f, 0f);
            }
            else
            {
                healthBar.color = new Color(255, 0, 0);
            }

            if(player.score > _currentScore)
            {
                _currentScore += Mathf.RoundToInt(Time.deltaTime * scoreFrameIncrement);
                if(_currentScore > player.score)
                {
                    _currentScore = player.score;
                }
            }
            else if(player.score < _currentScore)
            {
                _currentScore -= Mathf.RoundToInt(Time.deltaTime * scoreFrameIncrement);
                if (_currentScore < player.score)
                {
                    _currentScore = player.score;
                }
            }
            scoreText.text = "" + _currentScore.ToString();
        }
	}

    public void TakeDamage()
    {
        _animator.SetTrigger("TakeDamage");
    }
}
