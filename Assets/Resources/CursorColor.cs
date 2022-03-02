using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CursorColor : MonoBehaviourPunCallbacks
{
    private Renderer[] renderers;

    bool caught;


    // Start is called before the first frame update
    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();

        if (photonView.IsMine)
        {

            for (int i = 0; i < renderers.Length; i ++)
            {
                caught = false;

                float red = PlayerPrefs.GetFloat("red");

                float green = PlayerPrefs.GetFloat("green");

                float blue = PlayerPrefs.GetFloat("blue");

                Debug.Log("red float " + red);

                renderers[i].material.color = new Color(red, green, blue);
            }
            

        }
        else
        {

            photonView.RPC("SendMeTheColor", RpcTarget.Others);

            PhotonNetwork.SendAllOutgoingCommands();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
