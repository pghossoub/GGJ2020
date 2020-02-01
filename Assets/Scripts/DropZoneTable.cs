using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneTable : DropZone
{
    public MouseDragDrop m_mouseDragDrop;

    public override void DropItem(GameObject item, Vector3 dropPosition)
    {
        // item.transform.position = dropPosition;
        var rb = item.GetComponent<Rigidbody>();
        rb.useGravity = true;
        //rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_mouseDragDrop.DropItem(gameObject, collision.contacts[0].point);
    }
}
