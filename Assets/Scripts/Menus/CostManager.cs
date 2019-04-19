using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostManager : MonoBehaviour 
{

	public Text m_MyText;

    void Awake()
    {
        //Text sets your text to say this message
        m_MyText.text = "Cost = 0";
    }

    public void UpdateText()
    {
        
    }
}
