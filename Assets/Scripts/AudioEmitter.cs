using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEmitter : MonoBehaviour
{
    public GameObject directionManageObj = null;
    private DirectionController dc = null;

    // Start is called before the first frame update
    void Start()
    {
        dc = directionManageObj.GetComponent<DirectionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dc.currentDirection == DirectionController.DirectionType.Outward)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        other.GetComponentInChildren<AudioSource>().Play();
        other.GetComponentInChildren<Animation>().Play();
        other.GetComponentInChildren<ParticleSystem>().Play();
    }
}
