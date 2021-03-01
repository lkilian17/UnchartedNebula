using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject cannon1;
    [SerializeField] GameObject cannon2;
    [SerializeField] GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(laser, cannon1.transform.position, cannon1.transform.rotation);
            Instantiate(laser, cannon2.transform.position, cannon2.transform.rotation);
        }
    }
}
