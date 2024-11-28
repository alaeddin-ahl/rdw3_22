using Unity.VisualScripting;
using UnityEngine;

public class HelicalStairs : MonoBehaviour
{
    // Given parameters
    public float radius = 2.0f;
    public float height = 4.0f;
    public float width = 4.0f;
    public float numberOfTurns = 1f;
    public int numberOfSteps = 13;

    public GameObject stepPrefab; 
    
    public Transform offsetPosition;

    public bool isGenerateOnStart = true;

    public bool isMatchParametersFromHelicalRotation = false;

    public HelicalRotation helicalRotation;

    void Start()
    {
        if (isGenerateOnStart)
        {
            GenerateHelicalStairs();
        }
    }

    public void Update()
    {
    }

    public void DeleteChildren()
    {
        Debug.Log("DeleteChildren");
        // Loop through each child of the parent GameObject
        foreach (Transform child in transform)
        {
            // Destroy each child GameObject
            Destroy(child.gameObject);
        }
        Debug.Log("DeleteChildren done");
    }

    public void GenerateHelicalStairs()
    {
        if (isMatchParametersFromHelicalRotation)
        {
            if (helicalRotation == null)
            {
                Debug.LogError("HelicalRotation is not assigned");
                return;
            }

            radius = helicalRotation.radius;
            height = helicalRotation.height;
            numberOfTurns = helicalRotation.numberOfTurns;
        }

        var parent = this.transform;

        float hueStep = 360f / numberOfSteps;

        for (int i = 0; i < numberOfSteps; i++)
        {
            float hue = 360f - (i * hueStep);

            // Convert HSL to RGB (using 100% saturation and 50% lightness)
            Color color = HSLColorGenerator.HSLToRGB(hue, 1f, .5f);


            float t = (2 * Mathf.PI * numberOfTurns / numberOfSteps) * i;
            float x = radius * Mathf.Cos(-t);
            float y = radius * Mathf.Sin(-t);
            float z = (height / numberOfSteps) * i;

            // Create a new cube at the calculated position
            Vector3 localPosition = new Vector3(x, z, y);
            Vector3 position = parent.TransformPoint(localPosition + offsetPosition.position);

            Debug.Log("position: " + position);

            Vector3 directionToCenter = new Vector3(
                position.x,
                position.y,
                position.z);
            directionToCenter.y = 0; // Ignore height for rotation to face horizontally to the center
            
            Quaternion localRotation = Quaternion.LookRotation(directionToCenter);

            // Quaternion rotation = parent.rotation * localRotation;
            Quaternion rotation = localRotation;
            

            GameObject a = Instantiate(stepPrefab, position, rotation, parent);

            a.GetComponent<CubeController>().id = i;

            var objectRenderer = a.GetComponentInChildren<Renderer>();
            // objectRenderer.material.color = color;
            var material = objectRenderer.material;

            color.a = 0.5f; // 50% transparent
            material.color = color;
        }
    }

}