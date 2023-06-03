using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    }
}
