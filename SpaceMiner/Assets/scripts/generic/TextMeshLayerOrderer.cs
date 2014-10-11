using UnityEngine;
using System.Collections;

public class TextMeshLayerOrderer : MonoBehaviour {

    public int OrderInLayer = 0;

    void Start ()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.sortingOrder = OrderInLayer;
    }

}