using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning;
    
    [Space] public TMP_Text displayText;

    private float _minutes;
    private float _seconds;

    private bool _firstStart;

    private void Awake()
    {
        _minutes = Mathf.FloorToInt(timeRemaining / 60f);
        _seconds = Mathf.FloorToInt(timeRemaining % 60f);
        displayText.text = $"00:{_minutes:00}:{_seconds:00}";
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                _minutes = Mathf.FloorToInt(timeRemaining / 60f);
                _seconds = Mathf.FloorToInt(timeRemaining % 60f);
                displayText.text = $"00:{_minutes:00}:{_seconds:00}";
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void FirstStart()
    {
        if (_firstStart) return;
        
        _firstStart = true;
        timerIsRunning = true;
    }
}
