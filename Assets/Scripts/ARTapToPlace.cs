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
                Instantiate(spawnedARGameObject, hitPose.position, hitPose.rotation);
            }
        }
    }
}
