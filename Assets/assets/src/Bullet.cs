using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float deltaTime = 0;
    public float speed = 10.0f;
    public GameObject target = null;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Bullet hit the target!");
            Destroy(gameObject);
            target.GetComponent<Enemy>().hp -= 30;
            if (target.GetComponent<Enemy>().hp < 0)
            {
                Destroy(target);
            }
        }
    }

    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > 100) Destroy(gameObject);

        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);
        }



    }
}
