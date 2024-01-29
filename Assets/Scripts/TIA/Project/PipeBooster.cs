/*using UnityEngine;

public class PipeBooster : MonoBehaviour
{
    public float pipeSpeed = 2.0f; // Скорость движения по трубе
    public Transform startTrigger; // Триггер начала трубы
    public Transform endTrigger; // Триггер конца трубы

    private bool isMoving = false; // Флаг для отслеживания движения Drone
    private float initialSpeed; // Исходная скорость Drone перед входом в трубу

    void Start()
    {
        initialSpeed = pipeSpeed;
    }

    void Update()
    {
        if (isMoving)
        {
            MoveDroneInPipe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPipeTrigger"))
        {
            // Запускаем Drone по трубе
            isMoving = true;
            pipeSpeed = initialSpeed; // Исходная скорость при входе в трубу
        }
        else if (other.CompareTag("EndPipeTrigger"))
        {
            // Drone достиг конца трубы, продолжаем движение со скоростью, с которой он вошел в трубу
            pipeSpeed = initialSpeed;
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StartPipeTrigger"))
        {
            Debug.Log("Start trigger");
            // Когда Drone покидает триггер начала трубы, устанавливаем скорость на 0, чтобы он не двигался
            pipeSpeed = 0.0f;
        }
    }*/
/*
    private void MoveDroneInPipe()
    {
        // Получаем текущую позицию трубы
        Vector3 currentPosition = transform.position;

        // Двигаем трубу вдоль ее оси
        transform.Translate(Vector3.forward * pipeSpeed * Time.deltaTime);

        // Обновляем позицию триггеров вместе с трубой
        // startTrigger.position += transform.position - currentPosition;
        // endTrigger.position += transform.position - currentPosition;
    }
}
*/


using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform startTrigger; // Триггер начала трубы
    public Transform endTrigger; // Триггер конца трубы
    public float pipeSpeed = 5.0f; // Скорость движения по трубе

    private bool isDroneInside = false; // Флаг для отслеживания нахождения Drone в трубе

    void Update()
    {
        if (isDroneInside)
        {
            MoveDroneInPipe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPipeTrigger"))
        {
            // Drone дотронулся до триггера начала трубы
            isDroneInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EndPipeTrigger"))
        {
            // Drone покинул трубу, сбрасываем флаг и останавливаем движение
            isDroneInside = false;
        }
    }

    /*
    private void MoveDroneInPipe()
    {
        // Получаем направление от начала к концу трубы
        Vector3 pipeDirection = endTrigger.position - startTrigger.position;

        // Нормализуем направление, чтобы получить единичный вектор
        pipeDirection.Normalize();

        // Перемещаем Drone вдоль направления с установленной скоростью
        transform.Translate(pipeDirection * pipeSpeed * Time.deltaTime, Space.World);
    } */


    // Чтобы дрон летел строго от начала трубы к концу по линии
    private void MoveDroneInPipe()
    {
        // Получаем текущую позицию трубы
        Vector3 currentPosition = transform.position;

        // Получаем направление от начала к концу трубы
        Vector3 pipeDirection = endTrigger.position - startTrigger.position;

        // Нормализуем направление, чтобы получить единичный вектор
        pipeDirection.Normalize();

        // Вычисляем целевую позицию (конечную точку в трубе)
        Vector3 targetPosition = startTrigger.position + pipeDirection * Vector3.Distance(startTrigger.position, endTrigger.position);

        // Используем линейную интерполяцию для перемещения Drone от текущей позиции к целевой
        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * pipeSpeed);

        // Проверяем, достиг ли Drone конца трубы
        float distanceToEnd = Vector3.Distance(transform.position, endTrigger.position);
        if (distanceToEnd < 0.1f)
        {
            // Если расстояние мало, значит, Drone достиг конца трубы, останавливаем движение
            isDroneInside = false;
        }
    }


}
