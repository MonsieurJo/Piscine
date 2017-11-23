using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class InstaKill : MonoBehaviour {

    public Transform playerTransform;
    public HUDHandler uiHandler;

    private float _dist;
    private int _distInInt;

    public void Awake()
    {
        Assert.IsNotNull(playerTransform);
    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerManager player = collision.gameObject.GetComponentInParent<PlayerManager>();
        if (player)
        {
            player.Kill();
        }
    }

    public void Update()
    {
        _dist = Vector3.Distance(playerTransform.position, transform.position);
        if(_dist <= 100f)
        {
            uiHandler.SetTransparency(1f-(_dist/100f));
        }
        //Debug.Log(_dist);
    }
}
