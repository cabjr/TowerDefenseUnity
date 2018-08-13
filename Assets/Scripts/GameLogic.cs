using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {
    public int hp = 5;
    public Text uiHP;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        if (uiHP!=null)
        {
            uiHP.text = hp.ToString();
        }
        
    }
}
