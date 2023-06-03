using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : Singleton<MonoBehaviour>
{
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
        
        while (true)
        {
            

            timeLeft = timeLeft - Time.deltaTime;
            UpdateTimerUI?.TriggerEvent(this, timeLeft);



            yield return null;
        }
    }

}
