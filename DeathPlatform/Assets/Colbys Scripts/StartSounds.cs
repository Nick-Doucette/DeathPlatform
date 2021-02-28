using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonHoverSound;
    public AudioClip buttonClickSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHoverSound()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(buttonHoverSound); 
    }    

    public void ButtonClickSound()
    {
        audioSource.volume = 1f;
        audioSource.PlayOneShot(buttonClickSound);
    }
}
