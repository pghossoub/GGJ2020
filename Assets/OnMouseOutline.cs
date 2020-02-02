using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class OnMouseOutline : MonoBehaviour
{
    private void Awake()
    {
        //GetComponent<Outline>().enabled = false;
    }
    void OnMouseEnter()
    {
        GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }
}
