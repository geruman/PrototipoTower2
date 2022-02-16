using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    private float shootDelay = 1f;
    private float shootIn = 0;
    public float turretRange = 4f;
    [SerializeField] GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (shootIn <= 0 && GameRound.GetInstance().GetEnemies().Count > 0)
        {
            GameObject enemy = GetClosestEnemy();
            if (enemy != null) {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<TurretBulletMovement>().target = enemy;
                shootIn = shootDelay;
            }   
        }
        shootIn -= Time.deltaTime;
    }
    private GameObject GetClosestEnemy()
    {
         GameObject closest = null;
         foreach (GameObject enemy in GameRound.GetInstance().GetEnemies())
         {

             if (Vector3.Distance(gameObject.transform.position,enemy.transform.position)<turretRange)
             {
                 if (closest == null)
                 {
                     closest = enemy;
                 }
                 else
                 {
                     float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
                     float distanceToClosest = Vector2.Distance(transform.position, closest.transform.position);
                     if ( distanceToEnemy < distanceToClosest )
                     {
                         closest = enemy;
                     }
                 }
             }
         }
         return closest;
        
    }
}
