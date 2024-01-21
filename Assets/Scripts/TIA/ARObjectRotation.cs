// Резкая смена rotation на 90 по нажатию кнопки
/*using UnityEngine;

public class ARObjectRotation : MonoBehaviour
{
    public GameObject objectToRotate;
    public GameObject button1;
    public GameObject button2;

    private bool button1Pressed = false;
    private bool button2Pressed = false;

    private void Start()
    {
        // Init colors 
        button1.GetComponent<Renderer>().material.color = Color.red;
        button2.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnMouseDown()
    {
        Debug.LogError("OnMouseDown !!!");

        if (gameObject == button1)
        {
            button1Pressed = !button1Pressed;
            RotateObject(); 
            button1.GetComponent<Renderer>().material.color = button1Pressed ? Color.green : Color.red; 
        }
        else if (gameObject == button2)
        {
            button2Pressed = !button2Pressed; 
            RotateObject(); 
            button2.GetComponent<Renderer>().material.color = button2Pressed ? Color.yellow : Color.blue; 
        }
    }

    private void RotateObject()
    {
        if (objectToRotate != null)
        {
            float rotationAmount = 90f;
            Vector3 rotation = objectToRotate.transform.eulerAngles;

            if (button1Pressed && !button2Pressed)
            {
                rotation.y += rotationAmount; // влево
            }
            else if (!button1Pressed && button2Pressed)
            {
                rotation.y -= rotationAmount; // вправо
            }

            objectToRotate.transform.eulerAngles = rotation;
        }
    }
}
*/


using UnityEngine;

public class ARObjectRotation : MonoBehaviour
{
    public GameObject objectToRotate;
    public GameObject button1;
    public GameObject button2;

    private bool button1Pressed = false;
    private bool button2Pressed = false;
    private bool rotationStarted = false;

    private float rotationSpeed = 50f; 

    private void Start()
    {
        // init colors
        button1.GetComponent<Renderer>().material.color = Color.green;
        button2.GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnMouseDown()
    {

        if (gameObject == button1)
        {
            button1Pressed = !button1Pressed; 
            button2Pressed = false; 
            rotationStarted = button1Pressed;

            // colors change
            button1.GetComponent<Renderer>().material.color = button1Pressed ? new Color(0f, 0.5f, 0f) : Color.green;
            button2.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (gameObject == button2)
        {
            button2Pressed = !button2Pressed;
            button1Pressed = false;
            rotationStarted = button2Pressed; 

            button2.GetComponent<Renderer>().material.color = button2Pressed ? new Color(0.5f, 0f, 0f) : Color.red; 
            button1.GetComponent<Renderer>().material.color = Color.green; 
        }
    }

    private void Update()
    {
        if (rotationStarted && objectToRotate != null)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            Vector3 rotation = objectToRotate.transform.eulerAngles;

            if (button1Pressed && !button2Pressed)
            {
                rotation.y += rotationStep; // left
            }
            else if (!button1Pressed && button2Pressed)
            {
                rotation.y -= rotationStep; // right
            }

            objectToRotate.transform.eulerAngles = rotation;
        }
    }
}
