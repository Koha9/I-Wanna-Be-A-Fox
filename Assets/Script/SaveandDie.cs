using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SaveandDie : MonoBehaviour {
    public AudioClip DiedSound;
    private AudioSource m_DiedAudioSource;

    public UnityEvent DiedEvent;
    public static float saveX = -46f;
    public static float saveY = 19.32f;
    int counter0 = 0;
    int counter1 = 0;
    int counter2 = 0;
    int counter3 = 0;
    int counter4 = 0;

    static int level = 0;
    static float ResPown1X = -31f;
    static float ResPown1Y = 19.31f;
    static float ResPown2X = 27.72f;
    static float ResPown2Y = 7.49f;
    static float ResPown3X = -40f;
    static float ResPown3Y = -3.5f;

    // Use this for initialization

    private void Awake()
    {
        if (DiedEvent == null)
            DiedEvent = new UnityEvent();
    }



    void Start () {
        Trans();
        m_DiedAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))//Reset&GoBackToCheckPoint
        {
            ResetLevel(level);
            Trans();
        }
        Vector3 tmp = GameObject.Find("Player").transform.position;
    }

    void OnTriggerEnter2D(Collider2D c)//Hit by some Toge
    {
        m_DiedAudioSource.clip = DiedSound;
        m_DiedAudioSource.Play();
        Debug.Log("AHHHHHH!");
        DiedEvent.Invoke();
    }
    void SceneUnload()
    {
        if (counter0 >= 1)
        {
            SceneManager.UnloadScene(0);
            counter0 = 0;
        }
        if (counter1 >= 1)
        {
            SceneManager.UnloadScene(1);
            counter1 = 0;
        }
        if (counter2 >= 1)
        {
            SceneManager.UnloadScene(2);
            counter2 = 0;
        }
        if (counter3 >= 1)
        {
            SceneManager.UnloadScene(3);
            counter3 = 0;
        }
        if (counter4 >= 1)
        {
            SceneManager.UnloadScene(4);
            counter4 = 0;
        }
    }

    

    private void ResetLevel(int level)
    {
        switch (level)
        {
            case 0:
                SceneUnload();
                SceneManager.LoadScene(1);
                counter1 = 1;
                break;
            case 1:
                SceneUnload();
                SceneManager.LoadScene(2);
                counter2 = 1;
                break;
            case 2:
                SceneUnload();
                SceneManager.LoadScene(3);
                counter4 = 1;
                break;
            case 3:
                SceneUnload();
                SceneManager.LoadScene(4);
                counter4=1;
                break;
        }

    }
    void Trans()//Back to save point
    {
        GameObject.Find("Player").transform.position = new Vector3(saveX, saveY, 0);
    }

    //public-----------------------------
    public void LevelHome()
    {
        level = 0;
        saveX = -46f;
        saveY = 19.32f;
        ResetLevel(level);
    }
    public void DoSave()
    {
        Vector3 me = GameObject.Find("Player").transform.position;
        saveX = me.x;
        saveY = me.y;
    }
    public void TransToLevel1()
    {
        level = 1;
        
        saveX = ResPown1X;
        saveY = ResPown1Y;
        ResetLevel(level);
        
    }
    public void TransToLevel2()
    {
        level = 2;
        
        saveX = ResPown2X;
        saveY = ResPown2Y;
        ResetLevel(level);
    }
    public void TransToLevel3()
    {
        level = 3;
        
        saveX = ResPown3X;
        saveY = ResPown3Y;
        ResetLevel(level);        
    }
    //public-----------------------------


}
