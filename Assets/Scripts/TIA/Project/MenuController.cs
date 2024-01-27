using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject[] pages; // Массив страниц
    private int currentPageIndex = 0; // Индекс текущей страницы

    public GameObject[] prefabs; // Массив prefab для каждой страницы
    private GameObject currentPrefab;
    private GameObject objectFromPrefab;
    private ObjectMovementController objectMovementController;


    private Canvas canvas;

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        objectMovementController = GetComponent<ObjectMovementController>();

        // Изначально делаем активной только первую страницу
        ShowPage(currentPageIndex);
    }

    public void OnSelectButtonClicked()
    {
        // Debug.Log("Select button triggered - current prefab " + currentPrefab.name);

        if (currentPrefab != null)
        {
            // Создаем prefab
            objectFromPrefab = Instantiate(currentPrefab);

            // Получаем ссылку на ImageTargetDrone
            GameObject imageTargetDrone = GameObject.Find("ImageTargetDrone");

            // Если нашли ImageTargetDrone, делаем objectFromPrefab его дочерним объектом
            if (imageTargetDrone != null)
            {
                objectFromPrefab.transform.parent = imageTargetDrone.transform;
            }
            else
            {
                Debug.LogError("ImageTargetDrone not found!");
            }

            // Устанавливаем позицию перед AR камерой
            float distanceFromCamera = 1.0f; // Замените на ваше значение

            // Учитываем размеры объекта, чтобы установить его середину перед камерой по оси x
            float objectWidth = objectFromPrefab.GetComponent<Renderer>().bounds.size.x;
            Vector3 position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

            objectFromPrefab.transform.position = position;

            // Устанавливаем поворот PipeBooster
            if (currentPrefab.name == "PipeBooster")
            {
                position.x = Camera.main.transform.position.x + Camera.main.transform.forward.x * distanceFromCamera - objectWidth / 2;
                objectFromPrefab.transform.position = position;
                objectFromPrefab.transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
            }
            if (currentPrefab.name == "Elevator")
            {
                objectFromPrefab.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
            }
            if (currentPrefab.name == "Platform")
            {
                objectFromPrefab.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }

        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }

    }

    public void OnMenuRightButtonClicked()
    {
        // При нажатии кнопки вправо переключаемся на следующую страницу
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        ShowPage(currentPageIndex);
    }

    public void OnMenuLeftButtonClicked()
    {
        // При нажатии кнопки влево переключаемся на предыдущую страницу
        currentPageIndex = (currentPageIndex - 1 + pages.Length) % pages.Length;
        ShowPage(currentPageIndex);
    }

    private void ShowPage(int pageIndex)
    {
        // Делаем активной только выбранную страницу
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
            currentPrefab = prefabs[pageIndex];

        }
    }

    //--------------------------------------------------------------------------------------------

    public void OnUpButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта вверх по оси Z
            objectMovementController.MoveObjectUp(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }

    public void OnDownButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта вниз по оси Z
            objectMovementController.MoveObjectDown(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnRightButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта вправо по оси X
            objectMovementController.MoveObjectRight(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnLeftButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта влево по оси X
            objectMovementController.MoveObjectLeft(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnCloserButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта ближе по оси Y
            objectMovementController.MoveObjectCloser(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnFartherButtonClicked()
    {
        if (currentPrefab != null)
        {
            // Запускаем плавное движение только что созданного объекта дальше по оси Y
            objectMovementController.MoveObjectFarther(objectFromPrefab);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }
    }



}
