using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRound
{
    private static GameRound instance;
    private List<GameObject> enemies;
    private GameRound()
    {
        enemies = new List<GameObject>();
    }
    public static GameRound GetInstance()
    {
        if(instance == null)
        {
            instance = new GameRound();
        }
        return instance;
    }
    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
    public List<GameObject> GetEnemies()
    {
        return enemies;
    }
}
