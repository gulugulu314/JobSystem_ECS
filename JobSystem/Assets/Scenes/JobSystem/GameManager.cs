using UnityEngine;
using Unity.Jobs;
using UnityEngine.Jobs;


namespace JobSystem {
    public class GameManager : MonoBehaviour {

        [Header("Enermy Setting")]
        public GameObject enermyshipObj;
        public float enermySpeed = 1f;

        [Header("Simulation Setting")]
        public float topBoundary = 11.3f;
        public float bottomBoundary = -12.5f;
        public float leftBoundary = -19.6f;
        public float rightBoundary = 19.6f;

        [Header("SpawnSetting")]
        public int enermyShipCount = 1;
        public int enermyShipIncrement = 1;

        FPS fps;
        int totalCount;

        TransformAccessArray transforms;
        MoveMentJob MoveMentJob;
        JobHandle JobHandle;



        public void Awake() {
            fps = GetComponent<FPS>();
            transforms = new TransformAccessArray(0);

            AddShips(enermyShipCount);
        }

        public void OnDestroy() {
            JobHandle.Complete();
            transforms.Dispose();
        }


        public void Update() {

            JobHandle.Complete();

            if (Input.GetKeyDown(KeyCode.Space)) {
                AddShips(enermyShipIncrement);
            }

            MoveMentJob = new MoveMentJob() {
                moveSpeed = enermySpeed,
                topBound = topBoundary,
                bottomBound = bottomBoundary,
                deltaTime = Time.deltaTime
            };

            JobHandle = MoveMentJob.Schedule(transforms);
            JobHandle.ScheduleBatchedJobs();
        }


        void AddShips(int count) {

            JobHandle.Complete();

            transforms.capacity = transforms.length + count;

            for (int i = 0; i < count; i++) {
                float xVal = Random.Range(leftBoundary, rightBoundary);
                float zVal = Random.Range(0, 10f);

                Vector3 pos = new Vector3(xVal, 0, zVal);
                Quaternion rot = Quaternion.Euler(0, 180, 0);

                var obj = Instantiate(enermyshipObj, pos, rot) as GameObject;

                transforms.Add(obj.transform);
            }
            totalCount += count;
            fps.SetCount(totalCount);
        }




    }
}