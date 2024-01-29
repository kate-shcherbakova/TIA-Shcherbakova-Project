using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject[] pages; // Массив страниц
    public GameObject[] prefabs; // Массив prefab для каждой страницы

    private int currentPageIndex = 0; // Индекс текущей страницы
    private GameObject currentPrefab;
    private GameObject objectFromPrefab;
    private ObjectMovementController objectMovementController;

    private int numberOfObjectsUsed = 0;
    private FinishController finishController;

    private void Start()
    {
        // canvas = GetComponent<Canvas>();
        objectMovementController = GetComponent<ObjectMovementController>();
        finishController = GameObject.FindObjectOfType<FinishController>();

        // Изначально делаем активной только первую страницу

        bool isHard = PlayerPrefs.GetInt("hard", 0) == 1;

        if (isHard)
        {
            currentPageIndex = UnityEngine.Random.Range(0, pages.Length);
        }

        ShowPage(currentPageIndex);

        if (isHard)
        {
            GameObject menuRightButton = pages[currentPageIndex].transform.Find("Panel").gameObject.transform.Find("MenuRightButton").gameObject;
            menuRightButton.SetActive(false);
            GameObject menuLeftButton = pages[currentPageIndex].transform.Find("Panel").gameObject.transform.Find("MenuLeftButton").gameObject;
            menuLeftButton.SetActive(false);
        }

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
            // float distanceFromCamera = 0.5f; // Замените на ваше значение
            float distanceFromCamera = 5.0f; // Замените на ваше значение

            // Учитываем размеры объекта, чтобы установить его середину перед камерой по оси x
            float objectWidth = objectFromPrefab.GetComponent<Renderer>().bounds.size.x;
            Vector3 position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

            objectFromPrefab.transform.position = position;

            // Устанавливаем поворот
            // Используем switch-case для определения правильного поворота
            switch (pages[currentPageIndex].name)
            {
                case "PagePipe":
                    if (currentPrefab.name == "PipeBooster")
                    {
                        position.x = Camera.main.transform.position.x + Camera.main.transform.forward.x * distanceFromCamera - objectWidth / 2;
                        objectFromPrefab.transform.position = position;
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
                    }
                    break;

                case "PagePipeInverse":
                    if (currentPrefab.name == "PipeBooster")
                    {
                        position.x = Camera.main.transform.position.x + Camera.main.transform.forward.x * distanceFromCamera + objectWidth / 2;
                        objectFromPrefab.transform.position = position;
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(-90f, 90f, 0f);
                    }
                    break;

                case "PageElevator":
                    if (currentPrefab.name == "Elevator")
                    {
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                    }
                    break;

                case "PagePlatform":
                    if (currentPrefab.name == "Platform")
                    {
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    break;

                case "PagePlatformMinus":
                    if (currentPrefab.name == "Platform")
                    {
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(0f, -20f, 0f);
                    }
                    break;

                case "PagePlatformPlus":
                    if (currentPrefab.name == "Platform")
                    {
                        objectFromPrefab.transform.localRotation = Quaternion.Euler(0f, 20f, 0f);
                    }
                    break;

                default:
                    Debug.LogError("Unhandled page: " + pages[currentPageIndex].name);
                    break;
            }

            // For "Finish"
            numberOfObjectsUsed++;
            finishController.SetNumberOfObjectsUsed(numberOfObjectsUsed);
        }
        else
        {
            Debug.LogError("Prefab not assigned for the current page.");
        }

    }

    public void OnMenuRightButtonClicked()
    {
        objectFromPrefab = null;
        // При нажатии кнопки вправо переключаемся на следующую страницу
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        ShowPage(currentPageIndex);
    }

    public void OnMenuLeftButtonClicked()
    {
        objectFromPrefab = null;
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
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта вверх по оси Z
            objectMovementController.MoveObjectUp(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }

    public void OnDownButtonClicked()
    {
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта вниз по оси Z
            objectMovementController.MoveObjectDown(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnRightButtonClicked()
    {
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта вправо по оси X
            objectMovementController.MoveObjectRight(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnLeftButtonClicked()
    {
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта влево по оси X
            objectMovementController.MoveObjectLeft(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnCloserButtonClicked()
    {
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта ближе по оси Y
            objectMovementController.MoveObjectCloser(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }

    // Добавьте следующий метод в класс MenuController
    public void OnFartherButtonClicked()
    {
        if ((currentPrefab != null) && (objectFromPrefab != null))
        {
            // Запускаем плавное движение только что созданного объекта дальше по оси Y
            objectMovementController.MoveObjectFarther(objectFromPrefab);
        }
        else
        {
            // Debug.Log("Prefab not assigned for the current page.");
        }
    }



}
