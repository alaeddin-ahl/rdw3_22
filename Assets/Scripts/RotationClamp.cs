using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    [Header("Rotation Constraints")]
    [Tooltip("Enable/disable rotation clamping")]
    public bool clampRotation = true;
    
    [Tooltip("Minimum rotation angle in degrees")]
    public float minAngle = -180f;
    
    [Tooltip("Maximum rotation angle in degrees")]
    public float maxAngle = 180f;
    
    // Cache the transform for better performance
    private Transform cachedTransform;
    
    private void Awake()
    {
        cachedTransform = transform;
    }
    
    private void LateUpdate()
    {
        if (!clampRotation) return;
        
        // Get current rotation angles
        Vector3 currentRotation = cachedTransform.eulerAngles;
        
        // Convert angle to -180 to 180 range
        float angle = currentRotation.z;
        if (angle > 180f)
        {
            angle -= 360f;
        }
        
        // Clamp the angle
        float clampedAngle = Mathf.Clamp(angle, minAngle, maxAngle);
        
        // Only update if the angle has changed
        if (!Mathf.Approximately(angle, clampedAngle))
        {
            currentRotation.z = clampedAngle;
            cachedTransform.eulerAngles = currentRotation;
        }
    }
    
    // Helper method to set rotation limits at runtime
    public void SetRotationLimits(float min, float max)
    {
        minAngle = min;
        maxAngle = max;
    }
}