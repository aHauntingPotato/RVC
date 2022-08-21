using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WasaaMP;

public class GeneralManager : MonoBehaviour
{
    [SerializeField]
    public GameObject xrRig;
    [SerializeField]
    public Navigation playerPrefab;

    GameObject manager;

    // Start is called before the first frame update
    void Start()
    {

        manager = this.gameObject;
        Component gameManagerQuest = new Component();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
