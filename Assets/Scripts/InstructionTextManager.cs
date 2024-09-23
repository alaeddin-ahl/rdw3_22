using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionTextManager : MonoBehaviour
{
    private TextMeshProUGUI tmpro;
    public UnityEngine.UI.Image img;

    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
        tmpro.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInstructionText();
        }
    }

    public void ToggleInstructionText()
    {
        tmpro.enabled = !tmpro.enabled;
        img.enabled = tmpro.enabled;
    }
}
