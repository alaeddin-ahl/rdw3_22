using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSLColorGenerator : MonoBehaviour
{
    // Convert HSL to RGB color
    public static Color HSLToRGB(float h, float s, float l)
    {
        // Make sure h is in range 0-360
        h = Mathf.Repeat(h, 360f);
        // Convert s,l to range 0-1
        s = Mathf.Clamp01(s);
        l = Mathf.Clamp01(l);

        float c = (1f - Mathf.Abs(2f * l - 1f)) * s;
        float x = c * (1f - Mathf.Abs((h / 60f) % 2f - 1f));
        float m = l - c / 2f;

        float r = 0, g = 0, b = 0;

        if (h < 60f) { r = c; g = x; b = 0; }
        else if (h < 120f) { r = x; g = c; b = 0; }
        else if (h < 180f) { r = 0; g = c; b = x; }
        else if (h < 240f) { r = 0; g = x; b = c; }
        else if (h < 300f) { r = x; g = 0; b = c; }
        else { r = c; g = 0; b = x; }

        return new Color(r + m, g + m, b + m, 1f);
    }

}

