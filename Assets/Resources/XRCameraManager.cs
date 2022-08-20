using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using WasaaMP;

public class XRCameraManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {

            // récupération du proxy de l'OVRCameraRig, qu'il faut désactiver

            OVRCameraRig theCameraRig = (OVRCameraRig)GameObject.FindObjectOfType(typeof(OVRCameraRig));

            // récupération des outils qui eux doivent continuer à être représentés

            CursorTool ct = (CursorTool)theCameraRig.GetComponentInChildren<CursorTool>();

            // replacement des outils dans une partie active du graphe de scène

            ct.transform.SetParent(theCameraRig.transform.parent);

            // désactivation du proxy de l'OVRCameraRig

            theCameraRig.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
