using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonUI : MonoBehaviour
{

    public Image switchingImage;
    public Sprite tabKey;
    public Sprite crossedOutTabKey;
    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");

    }

    // Update is called once per frame
    void Update()
    {
        if(player1.GetComponent<PlayerController>().isPlatform ^ player2.GetComponent<PlayerController>().isPlatform)
        {
            switchingImage.sprite = tabKey;
        }
        else
        {
            switchingImage.sprite = crossedOutTabKey;
        }
        
    }
}
