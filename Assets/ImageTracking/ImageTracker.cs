using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    // Declare tracked image object and
    // Array of Gameobjects to store prefabs(entities)
    private ARTrackedImageManager trackedImages;
    public GameObject[] ArPrefabs;

    // Initialize list of Gameobjects to 
    // Store 
    List<GameObject> ARObjects = new List<GameObject>();

    // Awake functions gets ARTrackedImage component on AR object
    void Awake()
    {
        trackedImages = GetComponent<ARTrackedImageManager>();
    }

    // OnEnable is called when the script is enabled
    void OnEnable()
    {
        trackedImages.trackedImagesChanged += OnTrackedImagesChanged;
    }

    // OnDisable is called when the script is disabled
    void OnDisable()
    {
        trackedImages.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    // Event Handler
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //Create object based on image tracked
        foreach (var trackedImage in eventArgs.added)
        {
            foreach (var arPrefab in ArPrefabs)
            {
                if (trackedImage.referenceImage.name == arPrefab.name)
                {
                    // Instantiate the corresponding AR prefab as a child of the tracked image
                    var newPrefab = Instantiate(arPrefab, trackedImage.transform);

                    // Add the instantiated object to the list
                    ARObjects.Add(newPrefab);
                }
            }
        }

        //Update tracking position
        foreach (var trackedImage in eventArgs.updated)
        {
            // Iterate through AR objects and enable them to be shown
            // if name given in Reference Image Library and name on ImageTracker Script's AR prefabs are same 
            foreach (var gameObject in ARObjects)
            {
                if (gameObject.name == trackedImage.name)
                {
                    gameObject.SetActive(trackedImage.trackingState == TrackingState.Tracking);
                }
            }
        }

    }
}