using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite PlatformSprite;
    public SpriteRenderer spriteRenderer;
    public PlayerController controller;



    float horizontalMovement = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public bool isActive = false;


    public Collider2D[] playerColliders;
    public GameObject platformCollider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
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
        isActive = false;
        spriteRenderer.sprite = PlatformSprite;
        controller.ChangeRigidbody2DToStatic();
        controller.SetIsPlatform(true);
        platformCollider.SetActive(true);

        for(int i = 0; i <= playerColliders.Length - 1; i++)
        {
            playerColliders[i].enabled = false;
        }
        
    }
}
