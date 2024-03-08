// --------------------------------------------------------
//  Serial Trigger Script
//  Pedro Oliveira 2021
// --------------------------------------------------------

// !! Tip !! - Add a delay of 30 in the Arduino code to reduce the lag in the Unity side


using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialTrigger : MonoBehaviour
{
  Animator animator;
  public string portName = "/dev/cu.usbmodem144201";
  public int baudrate = 9600;
  public static SerialPort sp;
  public string debugMessage, serialMessage;
  public string triggerValue = "1";
  public string myTrigger;

  void Start ()
  {
    //Get Animator Component
    animator = GetComponent<Animator>();
    //Open Serial Connection
    sp = new SerialPort(portName, baudrate, Parity.None, 8, StopBits.One);
    OpenConnection();
  }

  void Update ()
  {
      string value = "test";
      if (sp.IsOpen){
          try {
          value = sp.ReadLine(); //Read the information
          value = value.Trim();
          //Trigger Animation when receive a value from serial
          if(value == triggerValue){
          animator.SetTrigger(myTrigger);
          Debug.Log("Works");
          }
          serialMessage = value;
          }
          catch {
          }

      }
  }

  public void OpenConnection()
  {
      if (sp != null)
      {
          if (sp.IsOpen)
          {
              //sp.Close();
              debugMessage = "Closing port!";
          }
          else
          {
              sp.Open();  // opens the connection
              if (sp.IsOpen)
              {
                  Debug.Log("Just opened");
              }
              sp.ReadTimeout = 20;  // sets the timeout value before reporting error (100)
              debugMessage = "Port Open!";
          }
      }
      else
      {
          if (sp.IsOpen)
          {
              print("Port is already open");
          }
          else
          {
              print("Port == null");
          }
      }
  }
  void OnApplicationQuit()
  {
      sp.Close();
  }
}
