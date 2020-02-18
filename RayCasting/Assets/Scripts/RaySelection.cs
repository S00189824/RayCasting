using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownRay : MonoBehaviour {

    public Transform RaySource;
    public float MaxDistance = 100;
    public LayerMask layerMask;

    //store data on the intersection
    RaycastHit hitResult;

    public GameObject PrefabToSpawn;
    Ray mouseRay;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay,out hitResult,MaxDistance,layerMask))
            {
                float distance = hitResult.distance;
                Vector3 point = hitResult.point;
                Vector3 normal = hitResult.normal;

                GameObject hitObject = hitResult.collider.gameObject;

                Debug.Log(point);


            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mouseRay);
    }
}
