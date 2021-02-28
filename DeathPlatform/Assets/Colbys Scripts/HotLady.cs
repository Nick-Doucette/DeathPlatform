using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotLady : MonoBehaviour
{


    LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>() ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player")
        {

            SoundManager.PlaySound(SoundManager.Sound.endLevelSound, transform.position);

            GameObject collidingPlayer = collision.gameObject;

            levelLoader.LoadNextLevel();
            

        }
    }
}
