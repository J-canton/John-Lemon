using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundCanvasGroup;
    private float timer;
    private bool isPlayerExit;


    private void Update()
    {
        if (isPlayerExit)
        {
            timer += Time.deltaTime;
            exitBackgroundCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0,1);

            if (timer > fadeDuration + displayImageDuration)
            {
                EndLevel();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerExit = true;
        }
    }

    void EndLevel()
    {
        Application.Quit();
    }
}
