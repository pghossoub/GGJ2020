using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZoneWorkbench : DropZone
{
    private BoxCollider _boxColliderSaved;
    public void SetupWorkbench()
    {
        //Bouger la camera
        BoxCollider[] boxcolliders = gameObject.GetComponents<BoxCollider>();
        foreach (BoxCollider boxcollider in boxcolliders)
        {
            if (boxcollider.isTrigger)
            {
                boxcollider.enabled = false;
                _boxColliderSaved = boxcollider;
            }
        }
        StartCoroutine(SetupSlots());
 
    }

    IEnumerator SetupSlots()
    {
        yield return new WaitForSeconds(2.0f);
        ActivateSlots();

    }

    private void ActivateSlots()
    {

    }
}
