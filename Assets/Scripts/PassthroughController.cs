using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(OVRPassthroughLayer))]
public class PassthroughController : MonoBehaviour
{
    [SerializeField]
    private OVRPassthroughLayer passthroughLayer;

    [SerializeField]
    private TextMeshProUGUI passThroughText;

    // Start is called before the first frame update
    void Start()
    {
        passthroughLayer = GetComponent<OVRPassthroughLayer>();   
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePassthrough();
        }
    }

    void UpdateText()
    {
        if (passThroughText != null){
            passThroughText.text = passthroughLayer.enabled ? "Passthrough enabled" : "Passthrough disabled";
        }
    }

    public void TogglePassthrough()
    {
        passthroughLayer.enabled = !passthroughLayer.enabled;
        UpdateText();
    }
}
