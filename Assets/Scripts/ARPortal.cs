using UnityEngine;
using UnityEngine.Rendering;

public class ARPortal : MonoBehaviour
{
    public ARRoom arRoom;

    public Material stencilMaskMaterial;
    public Material stencilMaterial;
    
    private static readonly int StencilComp = Shader.PropertyToID("_StencilComp");
    private static readonly int Ref = Shader.PropertyToID("_Ref");

    private void Start()
    {
        SetMaterials(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Camera entered the portal.");
            SetMaterials(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("Camera exited the portal.");
            if (!arRoom.isInsidePortal)
            {
                SetMaterials(false);
            }
        }
    }
    
    private void SetMaterials(bool fullRender)
    {
        var stencilCompValue = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        stencilMaterial.SetInt(StencilComp, (int)stencilCompValue);
        
        var worldValue = fullRender ? 0 : 1;
        stencilMaskMaterial.SetInt(Ref, worldValue);
    }

    private void OnDestroy()
    {
        SetMaterials(false);
    }
}
