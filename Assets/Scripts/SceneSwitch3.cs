using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0); // Replace '2' with the index of your third scene
    }
}