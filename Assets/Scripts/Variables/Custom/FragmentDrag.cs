using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


[CreateAssetMenu]
public class FragmentDrag : ScriptableObject
{
    public string fragmentName;
    public int order;
    public VideoFragment video;
    public MeshFilter meshFilter;
}
