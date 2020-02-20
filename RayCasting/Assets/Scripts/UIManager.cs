using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text txtSoil;
    public Text txtGold;
    public Text txtCoal;
    public Text txtWater;

    public GameManager manager;

	// Use this for initialization
	void Start ()
    {
		if(manager != null)
        {
            manager.OnResourcesUpdated
        }
	}
}
