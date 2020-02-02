using UnityEngine;
using Outline;
using Marsheleene.Variables;
using System;

public class MouseOutline : MonoBehaviour
{
    public LayerMask m_fragmentLayerMask;
    public LayerMask m_dropZoneLayerMask;

    public Camera mainCamera;

    public BoolReference m_isDragging;

    private Outline.Outline _outline;

    void Awake()
    {
        _outline = GetComponent<Outline.Outline>();
        _outline.OutlineColor = Color.yellow;
    }
    void Update()
    {
        CheckOutline();
    }

    private bool CastRay(LayerMask layerMask, out RaycastHit hit)
    {
        Vector3 mousePosition3D = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        return Physics.Raycast(
            mainCamera.ScreenPointToRay(mousePosition3D),
            out hit,
            float.PositiveInfinity,
            layerMask
            );
    }

    private void CheckOutline()
    {
        RaycastHit hit;
        if (m_isDragging.Value)
        {
            if (!CompareTag("Fragment"))
            {
                if (CastRay(m_dropZoneLayerMask, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        _outline.enabled = true;
                        _outline.OutlineWidth = 10f;
                        return;
                    }
                }
            }
        }
        else
        {
            if (CompareTag("Fragment"))
            {
                if (CastRay(m_fragmentLayerMask, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        _outline.enabled = true;
                        _outline.OutlineWidth = 10f;
                        return;
                    }
                }
            }
        }
        _outline.enabled = false;
        _outline.OutlineWidth = 0f;
    }

}
