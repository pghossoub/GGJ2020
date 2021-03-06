﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
using Marsheleene.Variables;

public class OnMouseOutline : MonoBehaviour
{
    public BoolVariable isDragging;
    public StringVariable gameView;
    //public VideoFragmentVariable fragmentDrag;
    public VideoFragmentVariable m_activeFragment;

    void OnMouseEnter()
    {
        switch (gameObject.tag)
        {
            case "StartPostIt":
                if (gameView.Value == "intro")
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "ExitPostIt":
                if (gameView.Value == "intro")
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "BackPostIt":
                if (gameView.Value == "loupe" || gameView.Value == "montage")
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "Loupe":
                if (gameView.Value == "table" && isDragging.Value)
                {
                    GetComponent<Outline>().enabled = true;
                }
                else
                {
                    GetComponent<Outline>().enabled = false;
                }
                break;
            case "Banc":
                if (gameView.Value == "table" && isDragging.Value)
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "Repair":
                if (gameView.Value == "montage")
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "Erase":
                if (gameView.Value == "montage")
                {
                    GetComponent<Outline>().enabled = true;
                }
                break;
            case "Fragment":
                if (gameView.Value != "start" && gameView.Value != "intro")
                {
                    if (!isDragging.Value)
                    {
                        GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        //if (fragmentDrag.Value.name == this.name)
                        if (m_activeFragment.Value.gameObject == this.gameObject)
                        {
                            GetComponent<Outline>().enabled = true;
                        }
                        else
                        {
                            GetComponent<Outline>().enabled = false;
                        }
                    }
                }
                break;
        }
    }


    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }

}
