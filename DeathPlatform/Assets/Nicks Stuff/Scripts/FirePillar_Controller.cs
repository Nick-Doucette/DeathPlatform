using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillar_Controller : MonoBehaviour
{
    [SerializeField]
    private float timeRemaining = 5f;
    [SerializeField]
    private float timeRemaining2 = 2f;
    public bool firing = false;

    private GameObject sprite;
    private Animator fireAnim;

    private ActivePlayer ap;
    void Awake()
    {
        sprite = this.gameObject.transform.Find("FireAnim").gameObject;
        ap = GameObject.FindGameObjectWithTag("ActivePlayer").GetComponent<ActivePlayer>();
        fireAnim = sprite.GetComponent<Animator>();
    }

    void Update()
    {
        if (!firing)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                firing = true;
                timeRemaining = 5f;
                Fire();
            }
        }
        else
        {
            if(timeRemaining2 > 0)
            {
                timeRemaining2 -= Time.deltaTime;
            }
            else
            {
                firing = false;
                timeRemaining2 = 2f;
                StopFire();
            }
            
        }
    }

    private void Fire()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        sprite.GetComponent<SpriteRenderer>().enabled = true;
        fireAnim.SetBool("Firing", true);
    }

    private void StopFire()
    {
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        sprite.GetComponent<SpriteRenderer>().enabled = false;
        fireAnim.SetBool("Firing", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Player2")
        {
            GameObject collidingPlayer = collision.gameObject;
            if (collidingPlayer.GetComponent<PlayerMovement>().isActive){ ap.SwitchActivePlayers(); }
            collidingPlayer.GetComponent<PlayerMovement>().ChangeToPlatform();
        }
    }
}
