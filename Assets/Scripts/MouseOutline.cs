using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOutline : MonoBehaviour
{
    public LayerMask layerMask;

    public Camera mainCamera;

    private Outline outline;

    void Awake()
    {
        //outline = GetComponent<Outline>();
    }
    void Update()
    {
        Vector3 mousePosition3D = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        RaycastHit hit;

        bool mouseOnObject = Physics.Raycast(
            mainCamera.ScreenPointToRay(mousePosition3D),
            out hit,
            float.PositiveInfinity, 
            layerMask
            );


        if (mouseOnObject)
        {
            GameObject objectOnMouse = hit.collider.gameObject;
            outline = objectOnMouse.GetComponent<Outline>();
            outline.OutlineWidth = 10f;
            outline.OutlineColor = Color.yellow;
            Debug.Log("mouseOnObject");
        }
        else
            if(outline != null)
                outline.OutlineWidth = 0f;
    }
}
