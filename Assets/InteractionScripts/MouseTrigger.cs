// --------------------------------------------------------
//  Animation Script
//  Mouse Trigger
//  Pedro Oliveira 2020
// --------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrigger : MonoBehaviour
{
    Animator animator;
    public enum myMouse {Left,Right,Middle}
    public myMouse myMouseButton;
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
        //Trigger Animation on Mouse Click
        if (Input.GetMouseButtonDown((int)myMouseButton))
        {
            animator.SetTrigger(myTrigger);
        }

    }
}
