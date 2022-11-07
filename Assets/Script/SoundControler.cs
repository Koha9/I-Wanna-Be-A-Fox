using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour {
    public AudioClip Sound;
    private AudioSource m_AudioSource;

    // Use this for initialization
    void Start () {
        m_AudioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        m_AudioSource.clip = Sound;
        
    }

    public void Play()
    {
        m_AudioSource.Play();
    }
}
