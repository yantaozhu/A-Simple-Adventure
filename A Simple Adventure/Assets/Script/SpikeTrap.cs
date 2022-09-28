using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
  	    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
