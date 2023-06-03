using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<MonoBehaviour>
{
    public float timeLeft;
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI timeText;
    private EndState endState;

    public enum EndState
    {
        IceAge, Meteor, WorldFlood
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GameTimer()
    {
        while (true)
        {
            gameText.text = "Time left until" + endState + " : ";
            yield return null;
        }
    }
}
