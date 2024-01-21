using UnityEngine;

public class ElevatorDown : MonoBehaviour
{
    public float speed = 2.0f; // Скорость движения лифта
    private bool isMoving = false; // Флаг для отслеживания движения лифта
    private Rigidbody elevatorRigidbody; // Ссылка на Rigidbody лифта
    private Collider[] elevatorColliders; // Массив коллайдеров лифта

    void Start()
    {
        elevatorRigidbody = GetComponent<Rigidbody>(); // Получаем ссылку на Rigidbody лифта
        elevatorRigidbody.isKinematic = true; // Устанавливаем isKinematic в true для управления движением вручную

        elevatorColliders = GetComponentsInChildren<Collider>();
    }

    void Update()
    {
        if (isMoving)
        {
            MoveElevator(); // Вызываем метод для движения лифта
        }
    }

    private void MoveElevator()
    {
        Vector3 downDirection = Vector3.down * speed * Time.deltaTime; // Направление движения вниз
        elevatorRigidbody.MovePosition(transform.position + downDirection); // Перемещаем лифт вниз

        // Дополнительные проверки на столкновение с другими объектами (кроме сферы)
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        // Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject != gameObject && !collider.CompareTag("ElevatorCollider") && !collider.CompareTag("ElevatorTrigger") && !collider.CompareTag("Drone"))
            {
                // Debug.Log("FFFFF Collider andronic! " + collider.gameObject.name + "trigger - " + collider.tag);
                isMoving = false; // Останавливаем движение лифта

                // Отключаем все коллайдеры лифта
                foreach (Collider elevatorCollider in elevatorColliders)
                {
                    // Debug.Log(elevatorCollider.name + " +++++ name of the collider");
                    elevatorCollider.enabled = false;
                }

                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            // Debug.Log("Hi there Drone inside Elevator");
            isMoving = true; // Начинаем движение лифта при входе сферы в зону Trigger
        }
    }
}
