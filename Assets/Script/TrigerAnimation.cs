using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerAnimation : MonoBehaviour {

    public Animator animator;
    bool On = false;

    // Use this for initialization
    void Start()
    {

    }

    public void DoOn()
    {
        On = true;
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("On", On);

    }
}
