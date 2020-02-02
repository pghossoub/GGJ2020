using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneWorkbench : DropZone
{
    public Transform dropPoint;

    private bool isWorkbenchUsed = false;
    private Collider[] workBenchColliders;
    private Collider[] slotsColliders;

    public override void DropItem(GameObject item, Vector3 dropPosition)
    {
        //Bouger la camera

        base.DropItem(item, dropPosition);
        item.transform.position = dropPoint.position;

        isWorkbenchUsed = true;

        workBenchColliders = GetComponents<Collider>();

        foreach (Collider collider in workBenchColliders)
        {
            //Debug.Log("+");
            if (collider.isTrigger)
            {
                //Debug.Log("*");
                collider.enabled = false;
            }
        }

        slotsColliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in slotsColliders)
        {
            if (collider.isTrigger && collider.name == gameObject.name)
            {
                Debug.Log("-");
                collider.enabled = true;
            }
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (isWorkbenchUsed)
            return;
        else
            base.OnCollisionEnter(collision);
    }
}
