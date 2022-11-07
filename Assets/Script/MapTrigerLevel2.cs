using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapTrigerLevel2 : MonoBehaviour {

    public UnityEvent TrigerOnEvent;
    public float TrigerSizeX = 0.1f;
    public float TrigerSizeY = 1.0f;


    [SerializeField] private Transform Player;
    [SerializeField] private Transform ThisTriger;
    int counter = 1;

    private void Awake()
    {
        if (TrigerOnEvent == null)
            TrigerOnEvent = new UnityEvent();
    }
    
    void Update()
    {
        if (Mathf.Abs(Player.position.x - ThisTriger.position.x) <= TrigerSizeX / 2 && Mathf.Abs(Player.position.y - ThisTriger.position.y) <= TrigerSizeY / 2 && counter < 1)
        {
            TrigerOnEvent.Invoke();
            counter++;
        }
    }
    public void EnableLevel2Triger()
    {
        counter = 0;
        Gizmos.color = Color.yellow;
    }


    //Preview-------------------------------------------------------------
    void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Vector3 globalWaypointPos = new Vector3(ThisTriger.position.x, ThisTriger.position.y, 0);
        Gizmos.DrawLine(globalWaypointPos - Vector3.up * TrigerSizeY / 2 - Vector3.left * TrigerSizeX / 2, globalWaypointPos + Vector3.up * TrigerSizeY / 2 - Vector3.left * TrigerSizeX / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.up * TrigerSizeY / 2 + Vector3.left * TrigerSizeX / 2, globalWaypointPos + Vector3.up * TrigerSizeY / 2 + Vector3.left * TrigerSizeX / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.left * TrigerSizeX / 2 - Vector3.up * TrigerSizeY / 2, globalWaypointPos + Vector3.left * TrigerSizeX / 2 - Vector3.up * TrigerSizeY / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.left * TrigerSizeX / 2 + Vector3.up * TrigerSizeY / 2, globalWaypointPos + Vector3.left * TrigerSizeX / 2 + Vector3.up * TrigerSizeY / 2);
    }
    //Preview-------------------------------------------------------------
}
