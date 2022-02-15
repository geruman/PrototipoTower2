using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletMovement : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position,2*Time.deltaTime);
            if (Vector2.Distance(transform.position, target.transform.position) < 0.5f)
            {
                Destroy(gameObject);
                Destroy(this);
                target.GetComponent<EnemyMovement>().Die();
            }
        }
        else
        {
            Destroy(gameObject);
            Destroy(this);
        }
        
    }
}
