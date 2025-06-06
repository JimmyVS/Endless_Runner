using UnityEngine;
using UnityEngine.SceneManagement;

public class Clouds : MonoBehaviour
{
    public float rotationSpeed = 1f;
    private float currentRotation = 146.0f;
    private Material skyboxMaterial;
    
    // Store the original skybox to reset it later
    private Material originalSkybox;

    void Start()
    {
        // Get the skybox material
        skyboxMaterial = RenderSettings.skybox;

        // Save the original skybox material for reset later
        originalSkybox = RenderSettings.skybox;

        // Check if we're in the correct scene
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Set the initial rotation
            currentRotation = 146.0f;
            skyboxMaterial.SetFloat("_Rotation", currentRotation);
        }

        // Hook into the scene load event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        // Only rotate the skybox in the specific scene
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            // Increment the rotation value over time
            currentRotation += rotationSpeed * Time.deltaTime;

            // Apply the new rotation to the skybox
            skyboxMaterial.SetFloat("_Rotation", currentRotation);
        }
    }

    // Reset the skybox when the scene is changed
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MainMenu")
        {
            // Reset the skybox to the original material
            RenderSettings.skybox = originalSkybox;
        }
    }

    void OnDisable()
    {
        // Ensure to reset the skybox when the object is disabled
        RenderSettings.skybox = originalSkybox;

        // Unsubscribe from scene loading events
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnApplicationQuit()
    {
        // Ensure to reset the skybox when quitting the application
        RenderSettings.skybox = originalSkybox;
    }
}
