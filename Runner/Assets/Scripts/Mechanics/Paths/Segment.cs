
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mechanics.Paths
{
    public class Segment : MonoBehaviour
    {
        [SerializeField] private List<ObstaclesSpawnPoint> obstaclesSpawnPoints;
        
        
       public List<ObstaclesSpawnPoint> ObstaclesSpawnPoints { get => obstaclesSpawnPoints; }
        

        [SerializeField]
        private Transform frontPoint, backPoint;

        public Transform BorderFront { get => frontPoint; }
        public Transform BorderBack { get =>  backPoint; }

        private List<Obstacle> spawnedObstacles = new List<Obstacle>();
        private void OnEnable()
        {

            Spawn();


        }
        void Spawn()
        {
            Obstacle obstacle = ObstacleSpawner.Instance.getObstacle();
            obstacle.transform.position = ObstaclesSpawnPoints[0].transform.position;
        }
      

    }
}
    