using System;
using UnityEngine;

public class HelicalRotation : MonoBehaviour
{
    public ChairRotation chairRotation;
    public Direction direction;
    public Transform rotationTransform;

    // Given parameters
    public float radius = 2.0f;
    public float height = 4.0f;
    public float width = 4.0f;
    public float numberOfTurns = 1.0f;

    public bool isFollowingRotationDirection = false;

    void Start()
    {
    }


    void OnEnable() 
    {
        chairRotation.OnChairRotate += OnChairRotation;
    }

    void OnDisable() 
    {
        chairRotation.OnChairRotate -= OnChairRotation;
    }

    private float GetLerp(float angle)
    {
        float min = chairRotation.minRotation;
        float max = chairRotation.maxRotation;

        // If direction is inward
        // if (!direction.is90Deg && !direction.isReverseDirection)
        // {
        //     return Mathf.InverseLerp(min, max, angle);
        // }
        // else 
        {
            return Mathf.InverseLerp(max, min, angle);
        }
    }

    public Vector3 MapAngleToPosition(float angle)
    {
        float l = GetLerp(angle);
        float t = Mathf.Lerp(0, 2 * Mathf.PI * numberOfTurns, l);

        // Calculate the position
        float x = radius * Mathf.Cos(t); 
        float y = radius * Mathf.Sin(t); 
        float z = (height / (2 * Mathf.PI * numberOfTurns)) * t;

        return new Vector3(x, z, y);
    }


    private void OnChairRotation(Vector3 rotation, float yRotationNormalized)
    {
        float f= this.direction.ry;
        

        Debug.Log(
            "OnChairRotation: " + rotation + 
            " angle: " + yRotationNormalized + 
            " f:" + f);

        transform.localPosition = MapAngleToPosition(yRotationNormalized);

        if (isFollowingRotationDirection) {
            rotationTransform.RotateAround(chairRotation.transform.position, Vector3.up, f);
        } 
        
    }

    public void ResetChairPosition() 
    {
        var r = this.chairRotation.yRotationNormalized;
        this.OnChairRotation(Vector3.zero, r);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
