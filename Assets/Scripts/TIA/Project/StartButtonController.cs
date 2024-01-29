using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    public Button startButton; // Ссылка на кнопку "Start"
    public GameObject drone; // Ссылка на объект Drone
    public GameObject menu;
    public Button stopButton;

    private TimerController timerController;
    // private Canvas canvas;

    void Start()
    {
        //canvas = GetComponent<Canvas>();
        timerController = GetComponent<TimerController>();

        // Добавляем слушатель на событие нажатия кнопки
        startButton.onClick.AddListener(StartGame);
        //timerController = GameObject.Find("TimerText").GetComponent<TimerController>();
    }

    void StartGame()
    {
        // Активируем использование гравитации у Drone
        Rigidbody droneRigidbody = drone.GetComponent<Rigidbody>();
        if (droneRigidbody != null)
        {
            droneRigidbody.isKinematic = false;
            droneRigidbody.useGravity = true;
        }
        else
        {
            Debug.LogError("Rigidbody not found on the Drone object.");
        }

        menu.SetActive(false);
        stopButton.gameObject.SetActive(true);
        timerController.StartTimer();
    }
}

