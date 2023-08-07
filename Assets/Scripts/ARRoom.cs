using UnityEngine;

public class ARRoom : MonoBehaviour
{
    public bool isInsidePortal;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInsidePortal = true;
            Debug.Log("Camera is inside the Portal.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            isInsidePortal = false;
            Debug.Log("Camera is outside the Portal.");
        }
    }
}
