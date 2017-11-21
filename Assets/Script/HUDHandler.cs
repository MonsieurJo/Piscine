using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions;

public class HUDHandler : MonoBehaviour {

    [Header("Game")]
    public PlayerManager player;

    [Header("Interface")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBar;

    private void Awake()
    {
        Assert.IsNotNull(player);
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(ammoText);
        Assert.IsNotNull(healthBar);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null)
        {
            ammoText.text = "x " + player.ammo;
        }
	}
}
