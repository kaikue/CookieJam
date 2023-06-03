using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI gameText;
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Timer")]
    [SerializeField] private float colorTransitionSpeed;
    //in the green
    [SerializeField] private Color green;
    //in the orange
    [SerializeField] private Color orange;
    [SerializeField] private float orangeThreshold;
    //in the red
    [SerializeField] private Color red;
    [SerializeField] private float redThreshold;

    [SerializeField] public GameObject Fly;
    [SerializeField] public GameObject Swim;
    [SerializeField] public GameObject Dig;
    [SerializeField] public GameObject Cold;

    private PlayerStats.PStats localStats;

    public void ChangeTimeText(Component sender, object data)
    {
        if (data is float)
        {
            float time = (float)data;
            timerText.text = time.ToString("F" + 2);
            if (time < redThreshold)
            {
                timerText.color = Color.Lerp(timerText.color, red, Time.deltaTime * colorTransitionSpeed);
            }
            else if (time < orangeThreshold)
            {
                timerText.color = Color.Lerp(timerText.color, orange, Time.deltaTime * colorTransitionSpeed);
            }
            else
            {
                timerText.color = Color.Lerp(timerText.color, green, Time.deltaTime * colorTransitionSpeed);
            }
        }
    }

    public void UpdateUI(Component component, object args)
    {
        Debug.Log("updateUI");
        if (args is GameManager.EndState endstate)
        {
            gameText.text = "Time left until " + endstate + "! : ";
        }
        else if (args is PlayerStats.PStats stats)
        {
            DisplayStatIncrease(stats);
            localStats = stats;
        }
    }

    private void DisplayStatIncrease(PlayerStats.PStats stats)
    {
        var flySlider = Fly.GetComponent<Slider>();
        flySlider.value = stats.fly;

        var digSlider = Dig.GetComponent<Slider>();
        digSlider.value = stats.dig;

        var swimSlider = Swim.GetComponent<Slider>();
        swimSlider.value = stats.swim;

        var coldSlider = Cold.GetComponent<Slider>();
        coldSlider.value = stats.cold;

    }
}
