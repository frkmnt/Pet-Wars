using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {


    private bool IsMoving,  HasMoved;
    
    private PetManager PetManager;


	void Start ()
    {
        PetManager = GameObject.Find("PetManagerPrefab(Clone)").GetComponent<PetManager>();
    }
	

	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            CombatTile c;

            //RaycastHit2D hit = Physics2D.Raycast(cameraPosition, mousePosition, distance(optional));

            if (hit && hit.collider)
            {
                c = hit.transform.GetComponent<CombatTile>();
                c.OnClick();
            }

            
      

        }

	}


    


}
