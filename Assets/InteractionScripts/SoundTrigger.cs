// --------------------------------------------------------
//  Animation Script
//  Sound Trigger
//  Pedro Oliveira 2020
// --------------------------------------------------------

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    Animator animator;
    public AudioSource mySound;
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
      if (animator.GetBool(myTrigger))
      {
          mySound.Play();
      }
    }
}
