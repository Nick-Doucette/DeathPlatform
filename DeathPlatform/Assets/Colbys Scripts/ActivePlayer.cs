using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool player1Active = true;

    public GameObject player1;
    public GameObject player2;

    CameraController cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Active)
        {
            player1.GetComponent<PlayerMovement>().isActive = true;
            player2.GetComponent<PlayerMovement>().isActive = false;
        }
        else
        {
            player1.GetComponent<PlayerMovement>().isActive = false;
            player2.GetComponent<PlayerMovement>().isActive = true;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchActivePlayers();
        }

    }

    public void SwitchActivePlayers()
    {
        player1Active = !player1Active;
        switch(player1Active)
        {
            case true:
                cam.ChangeCameraFocus(player1.GetComponent<PlayerController>());
                break;

            case false:
                cam.ChangeCameraFocus(player2.GetComponent<PlayerController>());
                break;
        }
    }
}
