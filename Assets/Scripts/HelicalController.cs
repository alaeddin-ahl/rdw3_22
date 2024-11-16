using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicalController : MonoBehaviour
{
    public HelicalStairs helicalStairs;
    public HelicalRotation hilecalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // This is the regular Start method
        Debug.Log("Start called");
        
        // Start the LateStart coroutine
        StartCoroutine(LateStart());
    }

    


    IEnumerator LateStart()
    {
        // Wait for the end of the frame to ensure all Start methods have been called
        yield return new WaitForEndOfFrame();
        
        // This code will run after all Start methods in the scene
        Debug.Log("LateStart called");

        UpdateSetting4();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateSetting1();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UpdateSetting4();
        }
    }

    void UpdateSetting1()
    {
        hilecalRotation.transform.position = new Vector3(0, 0, 0);

        hilecalRotation.height = 0.0f;
        helicalStairs.height = 0.0f;
        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        hilecalRotation.ResetChairPosition();
    }

    void UpdateSetting4()
    {
        hilecalRotation.transform.position = new Vector3(0, 0, 0);

        hilecalRotation.height = 4.0f;
        helicalStairs.height = 4.0f;
        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        hilecalRotation.ResetChairPosition();
    }
}


