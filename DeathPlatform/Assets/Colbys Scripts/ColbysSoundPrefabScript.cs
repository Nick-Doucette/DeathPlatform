using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColbysSoundPrefabScript : MonoBehaviour
{

    private AudioClip audioClip;
    private float lifeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
