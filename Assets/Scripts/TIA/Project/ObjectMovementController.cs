using System.Collections;
using UnityEngine;

public class ObjectMovementController : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float moveDistance = 0.5f; // Изменено значение расстояния

    private bool isMoving = false;
    private GameObject objectToMove;

    public void MoveObjectUp(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.up * moveDistance));
        }
    }

    // Добавьте следующий метод в класс ObjectMovementController
    public void MoveObjectDown(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.down * moveDistance));
        }
    }

    // Добавьте следующий метод в класс ObjectMovementController
    public void MoveObjectRight(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.right * moveDistance));
        }
    }

    // Добавьте следующий метод в класс ObjectMovementController
    public void MoveObjectLeft(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.left * moveDistance));
        }
    }

    // Добавьте следующий метод в класс ObjectMovementController
    public void MoveObjectCloser(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.back * moveDistance));
        }
    }

    // Добавьте следующий метод в класс ObjectMovementController
    public void MoveObjectFarther(GameObject objectToMove)
    {
        if (!isMoving)
        {
            this.objectToMove = objectToMove;
            StartCoroutine(MoveObject(Vector3.forward * moveDistance));
        }
    }

    //--------------------------------------------------------------------------------------------

    private IEnumerator MoveObject(Vector3 targetOffset)
    {
        isMoving = true;

        Vector3 startPosition = objectToMove.transform.position;
        Vector3 targetPosition = startPosition + targetOffset;

        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            objectToMove.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.transform.position = targetPosition;
        isMoving = false;
    }
}
