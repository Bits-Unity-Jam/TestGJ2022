
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mechanics.Paths
{
    public class Segment : MonoBehaviour
    {
        [SerializeField] private List<ObstaclesSpawnPoint> obstaclesSpawnPoints;
        [SerializeField] private List<CollectibleSpawnPoint> collectiblesSpawnPoints;

        
        
       public List<ObstaclesSpawnPoint> ObstaclesSpawnPoints { get => obstaclesSpawnPoints; }
       public List<CollectibleSpawnPoint> CollectiblesSpawnPoints { get => collectiblesSpawnPoints; }



        [SerializeField]
        private Transform frontPoint, backPoint;

        private bool initialized = false;

        public bool Initialized { get => initialized; set => initialized = value; }

        public Transform BorderFront { get => frontPoint; }
        public Transform BorderBack { get =>  backPoint; }

        private List<Obstacle> spawnedObstacles = new List<Obstacle>();
        private List<Gem> spawnedGems = new List<Gem>(); 
        private void OnEnable()
        {
            //перевірка чи ініціалізований сегмент (булівське поле, не забудь інкапсулювати в свойство)
            if(Initialized)
            Spawn();


        }
        private void OnDisable()
        {
            foreach (Obstacle obst in spawnedObstacles) if (obst != null) {
                    ObstacleSpawner.Instance.AddObstacle(obst);
                }
            foreach (Gem gem in spawnedGems) if (gem != null)
                {
                   CollectibleSpawner.Instance.AddGem(gem);
                }
        }

        void Spawn()
        {
            Obstacle obstacle2;
            Obstacle obstacle3;
            int chance = Random.Range(0, 2);
            Obstacle obstacle1 = ObstacleSpawner.Instance.getObstacle();            
            Vector3 position1 = ObstaclesSpawnPoints[Random.Range(0, ObstaclesSpawnPoints.Count)].transform.position;          
            obstacle1.transform.position = position1;          
            spawnedObstacles.Add(obstacle1);

            Vector3 position2 = ObstaclesSpawnPoints[Random.Range(0, ObstaclesSpawnPoints.Count)].transform.position;
            if (chance == 0)
            {
                obstacle2 = ObstacleSpawner.Instance.getObstacle();
                while (position2 == position1)
                    position2 = ObstaclesSpawnPoints[Random.Range(0, ObstaclesSpawnPoints.Count)].transform.position;
                obstacle2.transform.position = position2;
                spawnedObstacles.Add(obstacle2);
            }

            if(chance == 0 )
            {
                obstacle3 = ObstacleSpawner.Instance.getObstacle();
                Vector3 position3 = ObstaclesSpawnPoints[Random.Range(0, ObstaclesSpawnPoints.Count)].transform.position;
                while (position3 == position1 && position3 == position2)
                    position3 = ObstaclesSpawnPoints[Random.Range(0, ObstaclesSpawnPoints.Count)].transform.position;
                obstacle3.transform.position = position3;
                spawnedObstacles.Add(obstacle3);
            }
            Gem gem = CollectibleSpawner.Instance.getGem();
            gem.transform.position = CollectiblesSpawnPoints[Random.Range(0, CollectiblesSpawnPoints.Count)].transform.position;
            spawnedGems.Add(gem);
        }
    }
}
    