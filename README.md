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
