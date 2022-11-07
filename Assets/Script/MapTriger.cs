using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapTriger : MonoBehaviour {

    public UnityEvent TrigerOnEvent;
    public float TrigerSizeX = 0.1f;
    public float TrigerSizeY = 1.0f;


    [SerializeField] private Transform Player;
    [SerializeField] private Transform ThisTriger;
    int counter = 0;
    
    private void Awake()
    {
        if (TrigerOnEvent == null)
            TrigerOnEvent = new UnityEvent();
    }

	void Update () {
        if (Mathf.Abs(Player.position.x-ThisTriger.position.x)<=TrigerSizeX/2 && Mathf.Abs(Player.position.y - ThisTriger.position.y) <= TrigerSizeY/2 && counter < 1)
        {
            TrigerOnEvent.Invoke();
            counter++;
        }
	}
    //Preview-------------------------------------------------------------
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 globalWaypointPos = new Vector3(ThisTriger.position.x, ThisTriger.position.y, 0);
        Gizmos.DrawLine(globalWaypointPos - Vector3.up * TrigerSizeY/2 - Vector3.left * TrigerSizeX / 2, globalWaypointPos + Vector3.up * TrigerSizeY/2 - Vector3.left * TrigerSizeX / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.up * TrigerSizeY/2 + Vector3.left * TrigerSizeX / 2, globalWaypointPos + Vector3.up * TrigerSizeY/2 + Vector3.left * TrigerSizeX / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.left * TrigerSizeX / 2 - Vector3.up * TrigerSizeY / 2, globalWaypointPos + Vector3.left * TrigerSizeX/2 - Vector3.up * TrigerSizeY / 2);
        Gizmos.DrawLine(globalWaypointPos - Vector3.left * TrigerSizeX / 2 + Vector3.up * TrigerSizeY / 2, globalWaypointPos + Vector3.left * TrigerSizeX / 2 + Vector3.up * TrigerSizeY / 2);
    }
    //Preview-------------------------------------------------------------
}
