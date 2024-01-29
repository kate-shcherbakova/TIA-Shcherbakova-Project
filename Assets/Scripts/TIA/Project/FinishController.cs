using TMPro;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public TimerController timerController;
    public float droneHeightAboveFinish = 0.2f;
    public GameObject win;
    public TMP_Text timeSpent;
    public TMP_Text numberOfObjectsUsed;

    private int number;

    // Добавьте метод для установки значения из MenuController
    public void SetNumberOfObjectsUsed(int value)
    {
        number = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            // Check if the timerController is assigned and the timerText is active
            if (timerController != null && timerController.timerText.gameObject.activeSelf)
            {
                // Если столкнулся Drone, выводим сообщение о победе
                Debug.Log("Happy happy happy I am not a king I am not a god I am I am capybara!");

                // Переместить дрон над объектом Finish
                MoveDroneAboveFinish(other.gameObject);

                timerController.StopTimer();

                win.SetActive(true);
                timeSpent.text = timerController.timerText.text;
                numberOfObjectsUsed.text = "Number of objects used: " + number;


            }
            else
            {
                Debug.Log("TimerController is not assigned or the timer is not active. Make sure to press the 'Start' button first.");
            }
        }
    }

    private void MoveDroneAboveFinish(GameObject drone)
    {
        // Получаем текущую позицию Finish
        Vector3 finishPosition = transform.position;

        // Поднимаем дрон на заданную высоту над Finish
        Vector3 droneTargetPosition = new Vector3(finishPosition.x, finishPosition.y + droneHeightAboveFinish, finishPosition.z);

        // Устанавливаем новую позицию для дрона
        drone.transform.position = droneTargetPosition;

        // Опционально: вы можете заморозить какие-либо оси вращения или перемещения, если это необходимо
        Rigidbody droneRigidbody = drone.GetComponent<Rigidbody>();
        if (droneRigidbody != null)
        {
            droneRigidbody.velocity = Vector3.zero;
            droneRigidbody.angularVelocity = Vector3.zero;
            droneRigidbody.isKinematic = true; // Зависит от вашего случая использования
        }
    }
}
