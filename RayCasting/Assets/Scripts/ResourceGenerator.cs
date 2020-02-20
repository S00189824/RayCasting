using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]

public class ResourceGenerator : MonoBehaviour
{

	public void SetMaterialColor(Color color)
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}
