using Mechanics.Obstacles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Management;

namespace Mechanics.Paths
{
    public class Segment : MonoBehaviour
    {
        [SerializeField] private List<ObstacleSpawnPoint> obstaclesSpawnPoints;
        //private List<Obstacle> spawnedObstacles;
        
       // public List<ObstaclesSpawnPoint> ObstaclesSpawnPoints { get => obstaclesSpawnPoints; }
        

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
            spawnedObstacles.Add(Management.ObstacleSpawner.Instance.GetObstacle());
        }

    }
}
    