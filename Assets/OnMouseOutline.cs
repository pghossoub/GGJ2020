using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class OnMouseOutline : MonoBehaviour
{

    private void Update()
    {
    }
    void OnMouseEnter()
    {
        Debug.Log(Input.mousePosition.ToString());

        GetComponent<Outline>().enabled = true;
    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }
}
