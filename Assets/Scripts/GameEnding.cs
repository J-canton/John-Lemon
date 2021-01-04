using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    private float timer;
    private bool isPlayerExit;
    private bool isPlayerCaught;


    private void Update()
    {
        if (isPlayerExit)
        {
            EndLevel(exitBackgroundCanvasGroup, false);
        }
        else if(isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerExit = true;
        }
    }

    void EndLevel(CanvasGroup canvas, bool doRestart)
    {
        timer += Time.deltaTime;
        canvas.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }
        
    }

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}
