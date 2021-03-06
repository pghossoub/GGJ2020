﻿using UnityEngine;

using Marsheleene.Variables;

public class MouseDragDrop : MonoBehaviour
{
    public LayerMask layerMaskFragment;
    public LayerMask layerMaskDropZone;

    public Camera mainCamera;

    public BoolReference m_isDragging;

    private GameObject _objectOnMouse;
    private Transform _objectOnMouseTransform;
    private Vector3 startPosition;

    private Transform posObjetZ;


    private void Start()
    {
        m_isDragging.Value = false;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        //drag is On, object follow mouse
        if (m_isDragging.Value)
        {
            ObjectFollowMouse();

            //drag is On, on click, object drop in start position
            if (Input.GetButtonDown("Fire1"))
            {

                Vector3 mousePosition3D = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

                mousePosition3D.z = Vector3.Dot(
                             transform.position - mainCamera.transform.position,
                             mainCamera.transform.forward
                           );

                Vector3 mousePositionWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition3D);
                RaycastHit hit;
                bool mouseOnObject = Physics.Raycast(
                    mainCamera.ScreenPointToRay(mousePosition3D),
                    out hit,
                    float.PositiveInfinity,
                    layerMaskDropZone
                    );

                if (mouseOnObject && !hit.collider.CompareTag("Fragment"))
                {

                    DropItem(hit.collider.gameObject, hit.collider.transform.position);
                }
                
              
                return;

            }
        }

        //drag is Off, wait for a click on object
        if (!m_isDragging.Value && Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition3D = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            mousePosition3D.z = Vector3.Dot(
                         transform.position - mainCamera.transform.position,
                         mainCamera.transform.forward
                       );

            Vector3 mousePositionWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition3D); ;
            RaycastHit hit;

            bool mouseOnObject = Physics.Raycast(
                mainCamera.ScreenPointToRay(mousePosition3D),
                out hit,
                float.PositiveInfinity,
                layerMaskFragment
                );

            if (mouseOnObject) 
                
            {

                if (hit.collider.CompareTag("Fragment"))
                {

                    m_isDragging.Value = true;
                    hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;

                    _objectOnMouse = hit.collider.gameObject;
                    _objectOnMouseTransform = _objectOnMouse.transform;
                    startPosition = _objectOnMouseTransform.position;

                    var rb = _objectOnMouse.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    //rb.isKinematic = true;
                }

                
            }
        }
    }

    public void DropItem(GameObject dropZone, Vector3 dropPosition)
    {
        DropZone dropZoneScript = dropZone.GetComponent<DropZone>();
        dropZoneScript.DropItem(_objectOnMouse, dropPosition);
        m_isDragging.Value = false;
    }

    private void ObjectFollowMouse()
    {
        _objectOnMouseTransform = GameObject.Find("Fragement_1_1_A").GetComponent<Transform>();
        Vector3 mousePosition3D = Input.mousePosition;

        //mousePosition3D.z = Vector3.Dot( _objectOnMouseTransform.position - mainCamera.transform.position, mainCamera.transform.forward);
        mousePosition3D.z = Vector3.Dot(Vector3.forward - mainCamera.transform.position, mainCamera.transform.forward);

        Vector3 mousePositionWorldSpace = mainCamera.ScreenToWorldPoint(mousePosition3D);

        float posX = mousePositionWorldSpace.x;
        float posY = mousePositionWorldSpace.y;

        _objectOnMouseTransform.position = new Vector3(posX, posY, _objectOnMouseTransform.position.z);
    }
}
