using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAnimation : MonoBehaviour {

    public Animator animator;
    bool IsSaved = false;
    bool IsSavedOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
    public void DoIsSaved()
    {
        IsSaved = true;
    }

    public void DoIsSavedOver()
    {
        IsSavedOver = true;
        IsSaved = false;
    }
    public void UndoIsSavedOver()
    {
        IsSavedOver = false;
    }


    // Update is called once per frame
    void Update () {
        animator.SetBool("IsSaved", IsSaved);
        animator.SetBool("IsSavedOver", IsSavedOver);
	}
}
