using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.titleMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
