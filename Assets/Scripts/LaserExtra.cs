using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserExtra : MonoBehaviour
{
    public bool activo = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!activo)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}
