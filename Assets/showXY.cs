using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showXY : MonoBehaviour {

    

    float saveX = 8.0f;
    float saveY = 10.0f;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        //Debug.Log(tmp);
        if (tmp.y < -10)
        {
            
            goBack();
        }
        if(tmp.x>=21 && tmp.x <=22 && tmp.y>=14 && tmp.y <= 15)
        {
            saveX = 22.0f;
            saveY = 15.0f;
        }
    }
    public void goBack()
    {
        GameObject.Find("Player").transform.position = new Vector3(saveX, saveY, 0);
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("AHHHHHH!");
        goBack();
    }
}