using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropZone : MonoBehaviour
{
    public abstract void DropItem(GameObject item, Vector3 dropPosition);
        
}
