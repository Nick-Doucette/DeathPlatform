using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator ReloadLevelCoroutine(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        // Reload level
        SceneManager.LoadScene(levelIndex);
    }
}
