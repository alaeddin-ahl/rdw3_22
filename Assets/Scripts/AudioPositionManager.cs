using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioPositionManager : MonoBehaviour
{
    public TextMeshProUGUI audioPosText = null;
    public int currentAngle = 0;
    private float current_time = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioPosText.text = GetAudioText(currentAngle);
    }

    // Update is called once per frame
    void Update()
    {
        current_time += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.P)){
            ToggleAudioPosition();
        }
    }

    public void ToggleAudioPosition()
    {
        if(current_time < 2.0f) return;

        current_time = 0f;

        GameObject[] audioEmitters = GameObject.FindGameObjectsWithTag("AudioEmitter");

        foreach(GameObject obj in audioEmitters)
        {       
            obj.GetComponent<Animator>().SetTrigger("Next");
        }

        currentAngle += 90;
        currentAngle %= 360;
        audioPosText.text = GetAudioText(currentAngle);
    }

    private string GetAudioText(int angle) 
    {
        // return "Audio Source Position: +" + angle + " degrees";
        return string.Format("(B) Sound: {0}°",angle);
    }
}
