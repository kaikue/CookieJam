using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : Singleton<MonoBehaviour>
{
    
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI timerText;
    private EndState endState;

    
    [Header("Timer")]
    public float timeLeft;
    [SerializeField] private float colorTransitionSpeed;
    //in the green
    [SerializeField] private Color green;
    //in the orange
    [SerializeField] private Color orange;
    [SerializeField] private float orangeThreshold;
    //in the red
    [SerializeField] private Color red;
    [SerializeField] private float redThreshold;

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
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Gametimer()
    {
        while (true)
        {
            gameText.text = "Time left until " + endState + "! : ";

            timeLeft = timeLeft - Time.deltaTime;
            timerText.text = timeLeft.ToString("F" + 2);
            if (timeLeft < redThreshold)
            {
                timerText.color = Color.Lerp(timerText.color, red, Time.deltaTime * colorTransitionSpeed);
            }
            else if (timeLeft < orangeThreshold)
            {
                timerText.color = Color.Lerp(timerText.color, orange, Time.deltaTime * colorTransitionSpeed);
            }
            else
            {
                timerText.color = Color.Lerp(timerText.color, green, Time.deltaTime * colorTransitionSpeed);
            }



            yield return null;
        }
    }
}
