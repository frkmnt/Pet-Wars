using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupController : MonoBehaviour {

	private static DamagePopup popup;
	private static GameObject canvas;

	public static void Initialize()
	{
		canvas = GameObject.Find("ButtonCanvas");
		popup = Resources.Load<DamagePopup>("Damage/DamageParent");
	}
	
	public static void CreateHitPopup (string s, Transform l) 
	{		
		DamagePopup instance = Instantiate(popup);

		Vector2 ScreenPos = Camera.main.WorldToScreenPoint(l.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = ScreenPos;
		
		instance.SetText(s);
        
	}

    public static void CreateMissPopup( Transform l)
    {
        DamagePopup instance = Instantiate(popup);

        Vector2 ScreenPos = Camera.main.WorldToScreenPoint(l.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = ScreenPos;

        instance.SetText("Dodged!");

    }
}
