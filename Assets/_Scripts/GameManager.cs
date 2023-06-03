using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : Singleton<MonoBehaviour>
{
    
    public EndState endState { get; private set; }
    public float timeLeft;



    [Header("Events")]
    [SerializeField] private GameEvent UpdateTimerUI;
    [SerializeField] private GameEvent UpdateUI;

    public enum EndState
    {
        IceAge, Meteor, WorldFlood
    }

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomEndState();
        StartCoroutine(Gametimer());
        
    }
    private void ChooseRandomEndState()
    {
        endState = (EndState)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(EndState)).Length);
        UpdateUI?.TriggerEvent(this, endState);
    }

    // Update is called once per frame
    void Update()
    {
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
