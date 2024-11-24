using System;
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
    public ChairRotation chairRotation;

    public TextMeshProUGUI gainText;
    public TextMeshProUGUI rotationText;

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

        // chairRotation.OnChairRotate += OnChairRotate;
    }

    private void OnChairRotate(Vector3 rotation, float yRotationNormalized)
    {
        rotationText.text = string.Format("Chair rotation: {0:F0} ({1:F0})", 
            yRotationNormalized);
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

        rotationText.text = string.Format("Chair rotation: {0:F0}", 
            chairRotation.yControllerNormalized);
    }

    public void ToggleHelicalSetting()
    {
        // Get all possible enum values
        var values = Enum.GetValues(typeof(HelicalSetting));
        
        // Find the current index
        int currentIndex = Array.IndexOf(values, helicalSetting);
        
        // Move to next value, or wrap around to first value
        int nextIndex = (currentIndex + 1) % values.Length;
        
        // Set the new value
        helicalSetting = (HelicalSetting)values.GetValue(nextIndex);
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

        gainText.text = string.Format("(Y) Gain factor: {0} (min: {1} max: {2})", 
            GetGainText(),
            chairRotation.minRotation,
            chairRotation.maxRotation);
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
        // helicalRotation.height = 0.0f;
        // helicalRotation.numberOfTurns = .5f;
        helicalRotation.height = 4.0f;
        helicalRotation.numberOfTurns = 1.0f;

        chairRotation.minRotation = -179;
        chairRotation.maxRotation = 179;
        
        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        helicalRotation.ResetChairPosition();
    }

    void UpdateSetting4()
    {
        helicalRotation.transform.position = new Vector3(0, 0, 0);
        helicalRotation.height = 4.0f;
        helicalRotation.numberOfTurns = 1.0f;

        chairRotation.minRotation = -90;
        chairRotation.maxRotation = 90;

        helicalStairs.DeleteChildren();
        helicalStairs.GenerateHelicalStairs();

        helicalRotation.ResetChairPosition();
    }
}


