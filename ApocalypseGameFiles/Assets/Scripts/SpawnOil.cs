using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOil : MonoBehaviour {

    public GameObject oil;
    
	// Use this for initialization
	void Start () {
		
        
        for (int i = 0; i<=5; i++)
        {
            float x = Random.Range(-7, 12);
            float y = Random.Range(-8, 8);
        
            Instantiate (oil,new Vector2(x, y), Quaternion.identity); 
        }
        
        
	}
	

}
