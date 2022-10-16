using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    //public PlayerMovement playerMovement;

    


    public void EndGame()
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            FindObjectOfType<AudioManager>().Play("PlayerFalling");



            Debug.Log("GAME OVER");

            Invoke("Restart", 2);

        }
    }

    public void Restart()
    {
        //playerMovement.TakeDamage(20);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
