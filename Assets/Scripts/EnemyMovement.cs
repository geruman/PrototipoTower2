using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWaypoint;
    int life = 3;
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.05f)
        {
            currentWaypoint++;
        }
        if (currentWaypoint >= waypoints.Length)
        {
            GameRound.GetInstance().RemoveEnemy(gameObject);
            Destroy(gameObject);
            Destroy(this);
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, 1 * Time.deltaTime);
    }
    public void Die()
    {
        life--;
        if (life <= 0)
        {
            GameRound.GetInstance().RemoveEnemy(gameObject);
            Destroy(gameObject);
            Destroy(this);
        }
    }
    public int GetLife()
    {
        return life;
    }
}
