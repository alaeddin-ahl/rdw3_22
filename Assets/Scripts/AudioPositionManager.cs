using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioPositionManager : MonoBehaviour
{
    public TextMeshProUGUI audioPosText = null;
    public int currentAngle = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioPosText.text = "Audio Source Position: +" + currentAngle + " degrees";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            ToggleAudioPosition();
        }
    }

    public void ToggleAudioPosition()
    {
        GameObject[] audioEmitters = GameObject.FindGameObjectsWithTag("AudioEmitter");

        foreach(GameObject obj in audioEmitters)
        {       
            obj.GetComponent<Animator>().SetTrigger("Next");
        }

        currentAngle += 90;
        currentAngle %= 360;
        audioPosText.text = "Audio Source Position: +" + currentAngle + " degrees";
    }
}
