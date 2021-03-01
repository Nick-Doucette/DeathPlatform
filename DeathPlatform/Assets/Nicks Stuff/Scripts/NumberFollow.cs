using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberFollow : MonoBehaviour
{

    public bool isFirst = true;
    public float distance;

    private Transform player;

    void Awake()
    {
        if (isFirst) { player = GameObject.FindGameObjectWithTag("Player").transform; }
        else { player = GameObject.FindGameObjectWithTag("Player2").transform; }
    }
    
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distance, player.transform.position.z);
    }
}
