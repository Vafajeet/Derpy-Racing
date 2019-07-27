using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wincondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            Debug.Log(collision.name + " wins!");
            SceneManager.LoadScene("P1Win");
        }
        if(collision.tag == "Player2")
        {
            Debug.Log(collision.name + " wins!");
            SceneManager.LoadScene("P2Win");
        }
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
