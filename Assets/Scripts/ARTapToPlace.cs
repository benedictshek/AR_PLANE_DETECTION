using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public Camera arCamera;
    public ARRaycastManager arRaycastManager;
    public GameObject spawnedARGameObject;

    private List<ARRaycastHit> _arRaycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (arRaycastManager.Raycast(ray, _arRaycastHits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = _arRaycastHits[0].pose;
                GameObject spawnedObject = Instantiate(spawnedARGameObject, hitPose.position, Quaternion.identity);
                
                // Rotate the spawned object to face the camera's front view
                var cameraToSpawnedObject = arCamera.transform.position - spawnedObject.transform.position;
                cameraToSpawnedObject.y = 0f; // Ensure the rotation is only around the y-axis
                Quaternion rotation = Quaternion.LookRotation(cameraToSpawnedObject);
                spawnedObject.transform.rotation = rotation;
            }
        }
    }
}
