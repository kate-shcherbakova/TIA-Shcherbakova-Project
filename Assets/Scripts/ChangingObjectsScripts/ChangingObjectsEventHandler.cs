using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ChangingObjectsEventHandler : DefaultObserverEventHandler
{
    public GameObject[] objectsToDisplay; // all 3D objects

    int currentIndex = 0;

    // when marker is found
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound(); // from default method 

        if (objectsToDisplay.Length > 0)
        {
            ShowNextObject();
        }
    }

    void ShowNextObject()
    {
        // Disable all objects
        foreach (var obj in objectsToDisplay)
        {
            obj.SetActive(false);
        }

        // Enable next object
        objectsToDisplay[currentIndex].SetActive(true);

        // index for the next object
        currentIndex = (currentIndex + 1) % objectsToDisplay.Length;
    }
}
