using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public VisibilityCheck targetAstronaut;
    public VisibilityCheck targetDrone;
    public float speed = 0.3f;
    public float stopDistance = 0.1f;

    private Transform currentTarget;
    private bool moving = false;
    private bool hasMoved = false;

    void Update()
    {
        if (targetAstronaut == null || targetDrone == null)
        {
            return;
        }

        bool astronautVisible = targetAstronaut.isVisbile;
        bool droneVisible = targetDrone.isVisbile;

        if (astronautVisible && droneVisible)
        {
            if (!hasMoved)
            {
                // Debug.Log("!!! Sphere position " + transform.position);
                currentTarget = targetDrone.transform;
                hasMoved = true;
            }
            moving = true;
        }
        else
        {
            moving = false;
            hasMoved = false;
        }

        if (moving)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Debug.Log("!!! Moving to target " + transform.position);

        if (currentTarget == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        //if (Vector3.Distance(transform.position, currentTarget.position) < stopDistance)
        // {
            if (currentTarget == targetAstronaut)
            {
                currentTarget = targetDrone.transform;
            }
            else
            {
                moving = false;
            }
        //}
    }
}
