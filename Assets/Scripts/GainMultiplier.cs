using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GainMultiplier : MonoBehaviour
{
    private ChairRotation cr = null;
    private float speedMultiplier = 2;
    public TextMeshProUGUI gainText = null;

    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<ChairRotation>();
        GainTextUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            ToggleGainMultiplier();
        }
    }

    public void ToggleGainMultiplier()
    {
        speedMultiplier*= 2;
        if(speedMultiplier > 5)
        {
            speedMultiplier = 0.5f;
        }

        GainTextUpdate();
    }

    /*
        12.5 = x0.5
        25 = x1
        50 = x2
        100 = x4
    */

    public void GainTextUpdate()
    {
        gainText.text = "Current Gain: x" + speedMultiplier;
    }
}
