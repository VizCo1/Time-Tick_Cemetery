using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskObject : MonoBehaviour
{
    private void Start()
    {
        GetComponent<MeshRenderer>().sharedMaterial.renderQueue = 3002;
    }
}
