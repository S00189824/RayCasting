using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRay : MonoBehaviour
{
    public float maxDistance = 100;
    public LayerMask layerMask;
    RaycastHit hitResult;
    Camera myCam;
    Ray mouseRay;
    public Color pixelcolor;
    public GameManager manager;


    private void Start()
    {
        myCam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out hitResult,maxDistance, layerMask))
            {
                Vector3 point = hitResult.point;
                Vector3 normal = hitResult.normal;
                Vector2 UV = hitResult.textureCoord;


                MeshRenderer mesh = hitResult.collider.gameObject.GetComponent<MeshRenderer>();

                Texture2D tex = mesh.material.mainTexture as Texture2D;

                Vector2 uv = hitResult.textureCoord;

                pixelcolor = tex.GetPixelBilinear(uv.x, uv.y);

                manager.SpawnGenerator(point, normal, pixelcolor);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mouseRay);
    }
}
