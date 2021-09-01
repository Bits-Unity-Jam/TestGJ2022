using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mechanics.Paths
{
    public class StraightPaths : MonoBehaviour, IPath
    {
        

        [SerializeField] private Transform leftBorder, rightBorder;
        [SerializeField] private List<Segment> segments;    
        [SerializeField] private int segmentPoolCount;
        [SerializeField] private float startOffset;
        [SerializeField] private float forwardOffset;
        private Queue<Segment> segmentQueue = new Queue<Segment>();

        private Camera camera;
        private List<Segment> segmentsPool = new List<Segment>();


        private void StartSpawn()
        {
            var position = camera.transform.position;
            float currentZ = position.z - startOffset;
            float maxZ = position.z + forwardOffset;
            Vector3 currentPoint = transform.position;
            currentPoint.z = currentZ;
            while (currentPoint.z < maxZ)
            {
                currentPoint = SpawnSegmentOnPoint(currentPoint);
            }
        }

        Vector3 SpawnSegmentOnPoint(Vector3 currentPoint)
        {
            var segment = segmentsPool[Random.Range(0, segmentsPool.Count)];
            segmentsPool.Remove(segment);
            segment.gameObject.SetActive(true);
            Vector3 backPointVector = segment.transform.position - segment.BorderBack.transform.position;

            segment.transform.position = currentPoint + backPointVector;
            currentPoint.z = segment.BorderFront.position.z;
            segmentQueue.Enqueue(segment);
            return currentPoint;
        }
        private void Start()
        {
            StartSpawn();
        }

        private void Update()
        {
            Vector3 currentPos = camera.transform.position;
            Segment segmentLast = segmentQueue.ElementAt(segmentQueue.Count - 1);
            Vector3 lastFront = segmentLast.BorderFront.transform.position;
            float nextPos = currentPos.z + forwardOffset;
            while (nextPos > lastFront.z)
            {
                lastFront = SpawnSegmentOnPoint(lastFront);
            }
            var segmentFirst = segmentQueue.Peek();
            if (segmentFirst.BorderFront.position.z + startOffset < camera.transform.position.z)
            {
                segmentQueue.Dequeue();
                segmentFirst.gameObject.SetActive(false);
                segmentsPool.Add(segmentFirst);
            }
        }

        void Awake()
        {
            camera = Camera.main;
            Init();
        }

        void Init()
        {
            for (int i = 0; i < segmentPoolCount; i++)
            {
                Segment segment = Instantiate(segments[Random.Range(0, segments.Count)]);
                segment.gameObject.SetActive(false);
                segmentsPool.Add(segment);
            }
        }

        public Vector3 DirectionOnPoint(Vector3 point)
        {
            return transform.forward;
        }

        public Vector3 ClampPosition(Vector3 point)
        {
            Vector3 result = new Vector3(
                Mathf.Clamp(point.x, leftBorder.position.x, rightBorder.position.x),
                point.y,
                point.z
            );
            return result;
        }
    }
}