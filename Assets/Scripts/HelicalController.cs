using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelicalController : MonoBehaviour
{

    public enum HelicalSetting
    {
        Setting1,
        Setting4
    }

    public HelicalSetting helicalSetting = HelicalSetting.Setting1;
    private HelicalSetting previousHelicalSetting;

    public HelicalStairs helicalStairs;
    public HelicalRotation helicalRotation;

    public TextMeshProUGUI gainText;

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
            this.helicalSetting = HelicalSetting.Setting1;
            this.ApplyHelicalSetting();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {     
            this.helicalSetting = HelicalSetting.Setting4;
            this.ApplyHelicalSetting();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleHelicalSetting();
        }

        if (previousHelicalSetting!=helicalSetting)
        {
            ApplyHelicalSetting();
        }
    }

    public void ToggleHelicalSetting()
    {
        if (helicalSetting == HelicalSetting.Setting1)
        {
            helicalSetting = HelicalSetting.Setting4;
        }
        else
        {
            helicalSetting = HelicalSetting.Setting1;
        }
    }

    void ApplyHelicalSetting()
    {
        switch (helicalSetting)
        {
            case HelicalSetting.Setting1:
                UpdateSetting1();
                break;
            case HelicalSetting.Setting4:
                UpdateSetting4();
                break;
        }
        
        previousHelicalSetting = helicalSetting;

        gainText.text = string.Format("(Y) Gain factor: {0} (Height: {1} Turns: {2})", 
            GetGainText(),
            helicalRotation.height,
            helicalRotation.numberOfTurns);
    }

    string GetGainText()
    {
        switch (helicalSetting)
        {
            case HelicalSetting.Setting1:
                return "1";
            case HelicalSetting.Setting4:
                return "2";

            default:
                return "?";
        }
    }

    void UpdateSetting1()
    {
        helicalRotation.transform.position = new Vector3(0, 0, 0);
        helicalRotation.height = 0.0f;
        helicalRotation.numberOfTurns = .5f;
        
        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        helicalRotation.ResetChairPosition();
    }

    void UpdateSetting4()
    {
        helicalRotation.transform.position = new Vector3(0, 0, 0);
        helicalRotation.height = 4.0f;
        helicalRotation.numberOfTurns = 1.0f;

        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        helicalRotation.ResetChairPosition();
    }
}


