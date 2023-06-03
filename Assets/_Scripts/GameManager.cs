using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : Singleton<MonoBehaviour>
{
    [SerializeField] private ElementFader blackPanel;

    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI loseText;

    // The current end state of the game
    public EndState endState { get; private set; }

    // The time left in the game
    public float timeLeft;


    // Events for updating the UI
    [Header("Events")]
    [SerializeField] private GameEvent UpdateTimerUI;
    [SerializeField] private GameEvent UpdateUI;

    // Enum representing different end states of the game
    public enum EndState
    {
        IceAge, Meteor, WorldFlood
    }

    // Start is called before the first frame update
    void Start()
    {
        loseText.enabled = false;
        winText.enabled = false;

        blackPanel.SetAlpha(1f);
        blackPanel.FadeOut();

        // Choose a random end state for the game
        ChooseRandomEndState();

        // Start the game timer coroutine
        StartCoroutine(Gametimer());
        
    }

    // Choose a random end state for the game
    private void ChooseRandomEndState()
    {
        endState = (EndState)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(EndState)).Length);
        UpdateUI?.TriggerEvent(this, endState);
    }

    IEnumerator Gametimer()
    {
        
        while (timeLeft > 0)
        {
            

            timeLeft = timeLeft - Time.deltaTime;
            UpdateTimerUI?.TriggerEvent(this, timeLeft);



            yield return null;
        }
        timeLeft = 0;
        UpdateTimerUI?.TriggerEvent(this, timeLeft);
        blackPanel.FadeIn();
        CheckWinState();
        while(true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return null;
        }
    }

    private void CheckWinState()
    {
        if (endState == EndState.IceAge && PlayerManager.Instance.stats.stats.cold > PlayerManager.Instance.stats.coldThreshold)
        {
            WinGame();
        }
        if (endState == EndState.Meteor && PlayerManager.Instance.stats.stats.dig > PlayerManager.Instance.stats.digThreshold)
        {
            WinGame();
        }
        if (endState == EndState.WorldFlood && PlayerManager.Instance.stats.stats.swim > PlayerManager.Instance.stats.swimThreshold)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    private void LoseGame()
    {
        loseText.enabled = true;
    }

    private void WinGame()
    {
        winText.enabled = true;
    }
}
