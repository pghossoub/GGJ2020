using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marsheleene.Variables;

public class CloneFragmentDrag : MonoBehaviour
{
    public FragmentDrag fragmentDrag;

    private void OnEnable()
    {
        this.gameObject.GetComponent<MeshFilter>().mesh = fragmentDrag.meshFilter.mesh;
    }
}