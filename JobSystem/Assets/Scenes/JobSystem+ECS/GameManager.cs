using Unity.Entities;
using UnityEngine;
using Unity.Collections;
using Unity.Transforms;
using Unity.Mathematics;

namespace JobSystem_ECS {

    public class GameManager : MonoBehaviour {

        public static GameManager GM;

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

        EntityManager manager;

        public void Awake() {
            if (GM == null)
                GM = new GameManager();

            fps = GetComponent<FPS>();

            manager = World.Active.GetOrCreateManager<EntityManager>();

            AddShips(enermyShipCount);
        }


        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                AddShips(enermyShipIncrement);
            }
        }


        void AddShips(int count) {

            NativeArray<Entity> entities = new NativeArray<Entity>(count, Allocator.Temp);
            manager.Instantiate(enermyshipObj, entities);

            for (int i = 0; i < count; i++) {
                float xVal = UnityEngine.Random.Range(leftBoundary, rightBoundary);
                float zVal = UnityEngine.Random.Range(0, 10f);

                manager.SetComponentData(entities[i], new Position { Value = new float3(xVal, 0, topBoundary + zVal) });
                manager.SetComponentData(entities[i], new Rotation { Value = new quaternion(0, 1, 0, 0) });
                manager.SetComponentData(entities[i], new Movespeed { value = enermySpeed });

            }

            entities.Dispose();

            totalCount += count;
            fps.SetCount(totalCount);
        }
    }
}