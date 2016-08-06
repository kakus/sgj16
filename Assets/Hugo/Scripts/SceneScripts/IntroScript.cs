using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public GameObject IntroCanvas;

    void Start()
    {
        GameStateManager.GetInstance().OnGameStateChange += OnGameStateChange;
    }

    private void OnGameStateChange(EGameState NewState)
    {
        if (NewState == EGameState.PLAY_STATE)
        {
            StartCoroutine(ShowAnimAndSwichScene());
        }
    }

    private IEnumerator ShowAnimAndSwichScene()
    {
		IntroCanvas.GetComponent<Animator>().SetTrigger("WeHaveCaller");
		yield return new WaitForSeconds(3);		
        SceneManager.LoadScene(1);
    }
}
