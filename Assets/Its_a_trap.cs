using UnityEngine;
using System.Collections;

public class Its_a_trap : MonoBehaviour
{
    // Spaceshipコンポーネント
    Player kitsune;

    void Start()
    {
        // Spaceshipコンポーネントを取得
        kitsune = GetComponent<Player>();

    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("AHHHHHH!");
        GameObject.Find("Player").transform.position = new Vector3(2.0f, 5.0f, 0);
    }
}