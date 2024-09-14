using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPositionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P)){
            var children = GetChildren(gameObject.transform);
            for (var i = 0; i < children.Length; i++)
            {
                Debug.Log(children[i].name);
                children[i].transform.Rotate(new Vector3(0, 180f, 0));
            }
        }
    }

    private Transform[] GetChildren(Transform parent)
    {
        var children = new Transform[parent.childCount];

        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }
}
