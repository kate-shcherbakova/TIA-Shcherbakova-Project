1. Unity assets website - download Vuforia
2. To remove predefined video - Vuforia Configurations - Change Recording for Webcame 
3. Gravity will always be in direction of green arraw on image target 
4. You should enable gravity ONLY when the colliders are enabled, so, when the game has already started 
5. Is Kinematic - if you don't want the object to be moved by physical forces, it will be at the same place
6. Drag - to give objects the ability to stop
7. Pipe can be find in ProBuilder
8. To create a trigger: + Empty, add BoxCollider, check IsTrigger 
9. If trigger doesn't work, check if there's RigidBody!
10. Collision - when the objects touch each other
11. OnTriggerStay - the script will be called each frame. OnTriggerEnter - just onces, when the object touched the Trigger. Create trigger - inside object
12. Game play - pause (2 horizontal lines) - next button - game step by step
13. Чтоб не подставлять каждый раз ImageTarget - disable AR camera, in Image Target disable IT Behaviour + Default Observer Event Handler 
14. Canvas - Screen space overlay - camera - will be attached to the screen and don't move. World space - will move with camera
15. Better to choose Canvas - Screen space overlay - потому что тогда кнопки на переднем плане
16. Нужно отключить Mesh Collider у Drone, когда запустим Play
17. AR camera - First Target optimal 
18. Чтобы кнопка срабатывала ее нужно ставить ниже Panel
19. Чтобы выбрать конкретную функцию, которая будет вызываться по кнопке, к кнопке прикрепляем элемент, который содержит класс с функцией (Canvas). Потом выбираем конкретную функцию. 
20. Если прикрепляю скрипт (1) к canvas и ссылаю на объект из другого скрипта (2) в canvas, скрипт (2) должен быть выше скрипта (1)




Теперь я хочу сделать 6 кнопок + 1 кнопка "Attach". Они будут в моей canvas, как часть меню. Гейм плей будет такой:
1. Сейчас у меня есть страницы с кнопккой Select. Я могу спавнить объекты.
2. Я добавила в меню 6 кнопок (Up, Down (для оси z), Right, Left (для оси x), Closer, Farther (для оси y))
4. Когда объект заспавнился, можно редактировать его положение с помощью нажатия на кнопки (Up, Down (для оси z), Right, Left (для оси x), Closer, Farther (для оси y)). 
5. Когда пользовать решил, что объект стоит там, где нужно, он нажмает Attach. Больше двигать объект нельзя. 


using UnityEngine;

public class ElevatorDown : MonoBehaviour
{
    public GameObject insideWall;

    public void Start()
    {
        Debug.Log("START THE SCRIPT!!!");

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("TRIGGER enter!!!");
        if (other.gameObject.name.Equals("Sphere"))
        {
            Debug.Log("OTHER = SphereTag!!!");

            if (insideWall != null)
            {
                Vector3 newPosition = insideWall.transform.position;
                newPosition.y -= 0.3f; 
                insideWall.transform.position = newPosition;
            }
        }
    }
}
