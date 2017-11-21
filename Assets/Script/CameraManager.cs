using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraManager : MonoBehaviour {

    public static CameraManager Instance { get; private set; }

    public GameObject cameraTPS;
    public GameObject cameraShoulder;
    public GameObject cameraFPS;
    public GameObject player;

    public GameObject currentCamera;

    private int _cameraUsed = 1;
    private GameObject _player;

    private void Awake()
    {
        Instance = this;
        _player = player;
        Assert.IsNotNull(_player);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("c") && _cameraUsed <=3)
        {
            if (_cameraUsed == 3)
            {
                _cameraUsed = 1;
            }
            else
            {
                _cameraUsed++;
            }
        }
        if (_player)
        {
            switch (_cameraUsed)
            {
                case 1:
                    cameraTPS.SetActive(true);
                    currentCamera = cameraTPS;
                    cameraFPS.SetActive(false);
                    break;
                case 2:
                    cameraShoulder.SetActive(true);
                    currentCamera = cameraShoulder;
                    cameraTPS.SetActive(false);
                    break;
                case 3:
                    cameraFPS.SetActive(true);
                    currentCamera = cameraFPS;
                    cameraShoulder.SetActive(false);
                    break;
                default:
                    Debug.Log("Erreur Camera");
                    break;
            }
        }
    }
}
