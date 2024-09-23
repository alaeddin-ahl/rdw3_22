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

    private Transform[] GetChildren(Transform parent)
    {
        var children = new Transform[parent.childCount];

        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = parent.GetChild(i);
        }

        return children;
    }

    public void ToggleAudioPosition()
    {
        var children = GetChildren(gameObject.transform);
        for (var i = 0; i < children.Length; i++)
        {
            // Debug.Log(children[i].name);
            children[i].transform.Rotate(new Vector3(0, 90f, 0));
        }
        currentAngle += 90;
        currentAngle %= 360;
        audioPosText.text = "Audio Source Position: +" + currentAngle + " degrees";
    }
}
