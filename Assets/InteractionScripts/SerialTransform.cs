// --------------------------------------------------------
//  Serial Tranform Script
//  Pedro Oliveira 2021
// --------------------------------------------------------

// !! Tip !! - Add a delay of 30 in the Arduino code to reduce the lag in the Unity side

using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialTransform : MonoBehaviour
{
  public string portName = "/dev/cu.usbmodem144201";
  public int baudrate = 9600;
  public static SerialPort sp;
  public string debugMessage, serialMessage;
  public float transformFactor = 1;
  public static float tranformValue = 1;
  public bool posX = false;
  public bool posY = false;
  public bool posZ = false;
  public bool rotX = false;
  public bool rotY = false;
  public bool rotZ = false;

  void Start ()
  {
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
          serialMessage = value;
          tranformValue = float.Parse(value) * transformFactor;
          //Tranform Position
          if(posX){transform.position = new Vector3(tranformValue, transform.position.y, transform.position.z);}
          if(posY){transform.position = new Vector3(transform.position.x,tranformValue, transform.position.z);}
          if(posZ){transform.position = new Vector3(transform.position.x, transform.position.y, tranformValue);}
          //Tranform Rotation
          if(rotX){transform.eulerAngles = new Vector3(tranformValue, 0, 0);}
          if(rotY){transform.eulerAngles = new Vector3(0, tranformValue, 0);}
          if(rotZ){transform.eulerAngles = new Vector3(0, 0, tranformValue);}
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
