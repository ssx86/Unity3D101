using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Load the prefab from the Resources folder
    public Transform prefab = null;
    public float fireCountDown = 0.5f;

    public List<GameObject> enemies = new();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    void Update()
    {


        fireCountDown -= Time.deltaTime;
        if (fireCountDown < 0)
        {
            fireCountDown = 0.5f;

            GameObject nearestEnemy = null;


            // Iterate through the overlapping colliders and check if the object is present
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i])
                {
                    if (nearestEnemy == null)
                    {
                        nearestEnemy = enemies[i];
                    }
                    else if (UnityEngine.Vector3.Distance(enemies[i].transform.position, gameObject.transform.position)
                    < UnityEngine.Vector3.Distance(nearestEnemy.transform.position, gameObject.transform.position))
                    {
                        nearestEnemy = enemies[i];
                    }
                }
            }
            if (nearestEnemy)
            {

                Transform bullet = Instantiate(prefab, transform.position, transform.rotation);
                bullet.GetComponent<Bullet>().target = nearestEnemy;
            }
        }


    }

}

public class MyComparer : IComparer<GameObject>
{
    public GameObject center;
    public MyComparer(GameObject center)
    {
        this.center = center;
    }


    public int Compare(GameObject x, GameObject y)
    {
        return UnityEngine.Vector3.Distance(x.transform.position, center.transform.position)
        .CompareTo(UnityEngine.Vector3.Distance(y.transform.position, center.transform.position));
    }
}