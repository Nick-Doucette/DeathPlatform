using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFlipping : MonoBehaviour
{

    Vector3 vec;

    // Start is called before the first frame update
    void Start()
    {
        vec = new Vector3(10,10,1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.localScale = vec;
    }
}
