using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropZone : MonoBehaviour
{
    public MouseDragDrop m_mouseDragDrop;

    public virtual void DropItem(GameObject item, Vector3 dropPosition)
    {
        // item.transform.position = dropPosition;
        var rb = item.GetComponent<Rigidbody>();
        rb.useGravity = true;
        //rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        m_mouseDragDrop.DropItem(gameObject, collision.contacts[0].point);
    }

}
