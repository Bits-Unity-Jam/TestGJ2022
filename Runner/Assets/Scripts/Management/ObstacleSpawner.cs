using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    static ObstacleSpawner instance;
    [SerializeField] List<Obstacle> obstacles;
    [SerializeField] int obstaclePoolCount;



    private List<Obstacle> obstaclePool = new List<Obstacle>();

    public static ObstacleSpawner Instance { get => instance; }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        Init();
    }


    void Init()
    {
        for (int i = 0; i < obstaclePoolCount; i++)
        {
            Obstacle obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Count)]);
            
            obstacle.gameObject.SetActive(false);
            obstaclePool.Add(obstacle);
            
        }
    }
        public void AddObstacle(Obstacle obstacle)
    {
        obstaclePool.Add(obstacle);
        obstacle.gameObject.SetActive(false);
        
    }

    public Obstacle getObstacle()
    {   
        Obstacle obstacle = obstaclePool[Random.Range(0, obstaclePool.Count)];// 
        obstacle.gameObject.SetActive(true);
        obstaclePool.Remove(obstacle);
        
        return obstacle;

    }

}
