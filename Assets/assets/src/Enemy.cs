using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int hp = 100;

    public int waypointIndex = 0;

    void Update()
    {
        Transform target = Waypoints.points[waypointIndex];
        Vector3 dir = target.position - transform.position;

        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        if (Vector3.Distance(target.position, transform.position) < 0.5f)
        {
            waypointIndex++;
            if (waypointIndex >= Waypoints.points.Length)
            {
                Destroy(gameObject);
                return;
            }
        }
    }

}
