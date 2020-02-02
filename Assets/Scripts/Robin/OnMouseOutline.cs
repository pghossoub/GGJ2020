using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using Marsheleene.Variables;

public class OnMouseOutline : MonoBehaviour
{
    public BoolVariable isDragging;

    void OnMouseEnter()
    {
        if (gameObject.tag == "Fragment")
        {
            if (!isDragging.Value)
            {
                GetComponent<Outline>().enabled = true;
            }
            else
            {
                GetComponent<Outline>().enabled = false;
            }
        }

        if (gameObject.tag == "DropZone")
        {
            if (isDragging.Value)
            {
                GetComponent<Outline>().enabled = true;
            }
        }

    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }

}
