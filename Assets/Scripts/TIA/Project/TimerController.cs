using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    private bool timerRunning = false;

    void Start()
    {
        timerText.text = "Time: 0";
    }

    void Update()
    {
        if (timerRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimer(elapsedTime);
        }
    }

    public void StartTimer()
    {
        timerText.gameObject.SetActive(true);
        startTime = Time.time;
        timerRunning = true;
    }

    private void UpdateTimer(float elapsedTime)
    {
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);

        timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
