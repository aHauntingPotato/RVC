using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class XRCameraManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {

            GameObject theCameraRig = GameObject.FindGameObjectWithTag("XR");

            theCameraRig.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
