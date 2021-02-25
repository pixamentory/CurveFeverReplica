using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool hasEnded = false;

    //Ending Game
    public void EndGame()
    {
        if (hasEnded)
            return;

        hasEnded = true;
        StartCoroutine(PlayEndAnimation());
    }

    //Restarting game After some delay
    IEnumerator PlayEndAnimation()
    {
        Debug.Log("Game Over");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
