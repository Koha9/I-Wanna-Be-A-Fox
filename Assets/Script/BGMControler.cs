using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControler : MonoBehaviour {

    // Use this for initialization
    public GameObject Sound;
    private void Awake()
    {
        if (Sound)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
