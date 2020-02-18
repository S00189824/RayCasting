using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelection : MonoBehaviour {

    public Transform RaySource;
    public float MaxDistance = 100;
    public LayerMask layerMask;
    Ray mouseray;
    public GameObject PrefabToSpawn;

    //store data on the intersection
    RaycastHit hitResult;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseray,out hitResult,MaxDistance,layerMask))
            {

                Vector3 point = hitResult.point;

                

                Instantiate(PrefabToSpawn, point, Quaternion.identity);
                


            }
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(mouseray);
    }
}
