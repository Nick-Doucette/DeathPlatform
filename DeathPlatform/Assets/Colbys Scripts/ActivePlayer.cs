using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool player1Active = true;

    public GameObject player1;
    public GameObject player2;

    private bool deadTrigger = false;

    CameraController cam;

    LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
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

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(player1.GetComponent<PlayerController>().isPlatform && !player2.GetComponent<PlayerController>().isPlatform)
            {
                player1.transform.position = player2.transform.position;
                player1.GetComponent<PlayerMovement>().ChangeToPlayer();
                SoundManager.PlaySound(SoundManager.Sound.teleport, transform.position);
            }

            if (!player1.GetComponent<PlayerController>().isPlatform && player2.GetComponent<PlayerController>().isPlatform)
            {
                player2.transform.position = player1.transform.position;
                player2.GetComponent<PlayerMovement>().ChangeToPlayer();
                SoundManager.PlaySound(SoundManager.Sound.teleport, transform.position);
            }
            
        }

        if(player1.GetComponent<PlayerController>().isPlatform && player2.GetComponent<PlayerController>().isPlatform && !deadTrigger)
        {
            Debug.Log("Both platforms. we should be dead");
            deadTrigger = true;

            levelLoader.ReloadLevel();

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
