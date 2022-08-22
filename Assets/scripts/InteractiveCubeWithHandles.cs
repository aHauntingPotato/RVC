using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InteractiveCubeWithHandles : MonoBehaviourPun
{

    public GameObject leftHandle;
    public GameObject rightHandle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (leftHandle.transform.position + rightHandle.transform.position) / 2;
    }
}
