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

    [PunRPC]
    void SendMeTheColor(PhotonMessageInfo info)
    {
        if (photonView.IsMine)
        {
            float red = PlayerPrefs.GetFloat("red");

            float green = PlayerPrefs.GetFloat("green");

            float blue = PlayerPrefs.GetFloat("blue");

            Vector3 color = new Vector3(red, green, blue);

            photonView.RPC("SetTheColor", RpcTarget.All, color);
        }
    }

    [PunRPC]
    void SetTheColor(Vector3 color, PhotonMessageInfo info)
    {

        if (!photonView.IsMine)
        {

            for (int i = 0; i < renderers.Length; i++)
            {
                caught = false;

                float red = color[0];

                float green = color[1];

                float blue = color[2];

                Debug.Log("red float " + red);

                renderers[i].material.color = new Color(red, green, blue);
            }


        }
    }
}
