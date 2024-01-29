using UnityEngine;

public class FinishController : MonoBehaviour
{
    public TimerController timerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            // Check if the timerController is assigned
            if (timerController.timerText.gameObject.activeSelf)
            {
                // Если столкнулся Drone, выводим сообщение о победе
                Debug.Log("Happy happy happy I am not a king I am not a god I am I am capybara!");

                timerController.StopTimer();

                // Здесь вы можете добавить любой код для завершения игры
                // Например, выключение объектов, отображение экрана завершения, и т.д.
            }
            else
            {
                Debug.Log("TimerController is not assigned. Make sure to press the 'Start' button first.");
            }
        }
    }
}
