using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    //private Vector3 lastPlayerPositionY;
    private float distanceToMoveX;
    private float distaneToMoveY;

    void Start()
    {
        thePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;

    }

    void Update()
    {
        distanceToMoveX = thePlayer.transform.position.x - lastPlayerPosition.x;
        distaneToMoveY = thePlayer.transform.position.y - lastPlayerPosition.y;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distaneToMoveY, transform.position.z);
        lastPlayerPosition = thePlayer.transform.position;
    }

    public void ChangeCameraFocus(PlayerController pc)
    {
        thePlayer = pc;
    }
}
