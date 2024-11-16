using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicalController : MonoBehaviour
{
    public HelicalStairs helicalStairs;
    public HilecalRotation hilecalRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hilecalRotation.transform.position = new Vector3(0, 0, 0);

            hilecalRotation.height = 1.0f;
            helicalStairs.height = 1.0f;
            helicalStairs.DeleteChildren();
            helicalStairs.GenerateHelicalStairs();

            hilecalRotation.ResetChairPosition();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            var p = hilecalRotation.transform.position;
            hilecalRotation.transform.position = new Vector3(0, 0, 0);

            hilecalRotation.height = 4.0f;
            helicalStairs.height = 4.0f;
            helicalStairs.DeleteChildren();
            helicalStairs.GenerateHelicalStairs();

            hilecalRotation.ResetChairPosition();
        }
    }
}
