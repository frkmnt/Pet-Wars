using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseClickManager : MonoBehaviour {

    
    private HouseTileManager HouseManager;


	void Awake ()
    {
        HouseManager = GameObject.Find("HouseManagerPrefab(Clone)").GetComponent<HouseTileManager>();
    }
	

	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            HouseTile c;

            //RaycastHit2D hit = Physics2D.Raycast(cameraPosition, mousePosition, distance(optional));

            if (hit && hit.collider)
            {
                c = hit.transform.GetComponent<HouseTile>();
                c.OnClick();
            }

            
      

        }

	}
}
