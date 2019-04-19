using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePopup : MonoBehaviour {

	public Animator Animator;
	private Text DamageText;

	void Awake () 
	{
		AnimatorClipInfo[] ClipInfo = Animator.GetCurrentAnimatorClipInfo(0);
		Destroy(gameObject, ClipInfo[0].clip.length);
		DamageText = Animator.GetComponent<Text>();
	}
	
	
	public void SetText(string s)
	{
		DamageText.text = s;
	}



}
