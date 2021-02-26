using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private ActivePlayer ap;


    // Start is called before the first frame update
    void Start()
    {
        ap = GameObject.FindGameObjectWithTag("ActivePlayer").GetComponent<ActivePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player")
        {
            GameObject collidingPlayer = collision.gameObject;
            

            if (collidingPlayer.GetComponent<PlayerMovement>().isActive)
            {
                ap.SwitchActivePlayers();
            }
            collidingPlayer.GetComponent<PlayerMovement>().ChangeToPlatform();
            
        }
    }
}
