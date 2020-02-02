using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marsheleene.Variables;

public class LedMatieralChange : MonoBehaviour
{
    public BoolVariable isFilmRollDone;
    Renderer render;
    public Material mat;
    public Material oldMat;

    bool isLit = false;

    // Update is called once per frame
    void Update()
    {
            if (isFilmRollDone.Value && isLit == false)
            {
                GetComponent<Renderer>().sharedMaterials[0] = mat;
                isLit = isFilmRollDone;
            }
            if (!isFilmRollDone.Value && isLit)
            {
            GetComponent<Renderer>().sharedMaterials[0] = oldMat;
            isLit = isFilmRollDone;
            }

     }

}
