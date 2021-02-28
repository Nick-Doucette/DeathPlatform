using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSoundManager : MonoBehaviour
{

    private AudioSource audioSource;


    static bool AudioBegin = false;


    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!AudioBegin)
        {
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "matts 1-1")
        {
            audioSource.Stop();
            AudioBegin = false;
        }
    }
}
