// --------------------------------------------------------
//  Animation Script
//  Keyboard Trigger
//  Pedro Oliveira 2020
// --------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{

    Animator animator;
    public KeyCode myKey;
    public string myTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //Get Animator Component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger Animation on key press
        if (Input.GetKeyDown(myKey))
        {
            animator.SetTrigger(myTrigger);
        }
        
    }
}
