using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;

    public GameObject playerSprite;

    float horizontalMovement = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public bool isActive = false;


    public GameObject platform;
    public Collider2D[] platformCollider;
    private Animator anim;
    private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        anim = playerSprite.GetComponent<Animator>();
        particle = this.gameObject.transform.Find("PSPlatform").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

            if(horizontalMovement == 0)
            {
                Debug.Log("idle");
                anim.SetBool("Running", false);
            }
            else
            {
                Debug.Log("running");
                anim.SetBool("Running", true);
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetTrigger("Jump");
            }
        }

    }

    private void FixedUpdate()
    {
        if(isActive)
        {
            controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        else
        {
            
            controller.Move(0,false,false);
        }
        
    }

    public void ChangeToPlatform()
    {
        Debug.Log("ChangeToPlatform");

        SoundManager.PlaySound(SoundManager.Sound.playerToPlatform, transform.position);

        isActive = false;
        controller.ChangeRigidbody2DToStatic();
        controller.SetIsPlatform(true);
        
        for(int i = 0; i <= platformCollider.Length - 1; i++)
        {
            platformCollider[i].enabled = false;
        }

        particle.Play();

        playerSprite.SetActive(false);
        platform.SetActive(true);
    }

    public void ChangeToPlayer()
    {
        Debug.Log("ChangeToPlayer");

        controller.ChangeRigidbody2DToDynamic();
        controller.SetIsPlatform(false);

        for (int i = 0; i <= platformCollider.Length - 1; i++)
        {
            platformCollider[i].enabled = true;
        }

        playerSprite.SetActive(true);
        platform.SetActive(false);

    }
}
