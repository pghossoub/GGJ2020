using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneGlass : DropZone
{
    public override void DropItem(GameObject item, Vector3 dropPosition)
    {
        base.DropItem(item, dropPosition);
        Transform dropPoint = GetComponentInChildren<Transform>();
        item.transform.position = dropPoint.position;
    }
}
