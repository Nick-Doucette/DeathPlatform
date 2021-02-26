using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 4f;
    public float moveSpeed = 100;
    private ActivePlayer ap;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ap = GameObject.FindGameObjectWithTag("ActivePlayer").GetComponent<ActivePlayer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime >= 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

           

            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMoveSpeed(float speedToSet)
    {
        moveSpeed = speedToSet;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player")
        {
            GameObject collidingPlayer = collision.gameObject;


            
                ap.SwitchActivePlayers();
                collidingPlayer.GetComponent<PlayerMovement>().ChangeToPlatform();

                Destroy(gameObject);
            

        }

        if(collision.gameObject.tag == "PlatformCollider")
        {
            Destroy(gameObject);
        }

    }


}
