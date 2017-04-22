using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    private Renderer color;
    public float time;
    private Color myColor;
	// Use this for initialization    
	void Start () {
        color = GetComponent<Renderer>();
        color.enabled = true;
        myColor = new Color(0, 1, 0);
        color.material.color = myColor;
        
    }
	
	void Update () {
        
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time < 4 )
            {
                myColor.g = time * 0.25f;
                myColor.r = 1.0f - (time * 0.25f);
                color.material.color = myColor;
            }           
        }   
        
    }
}
