using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeAudioEmitterColor : MonoBehaviour
{
    private MeshRenderer mr = null;
    public Color col = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mr.material.color = col;
    }
}
