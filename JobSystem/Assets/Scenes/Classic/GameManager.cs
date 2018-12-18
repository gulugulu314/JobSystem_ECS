using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classic {

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

        public void Awake() {
            if (GM == null)
                GM = new GameManager();

            fps = GetComponent<FPS>();
            AddShips(enermyShipCount);
        }


        void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
                AddShips(enermyShipIncrement);
            }
        }


        void AddShips(int count) {
            for (int i = 0; i < count; i++) {
                float xVal = Random.Range(leftBoundary, rightBoundary);
                float zVal = Random.Range(0, 10f);

                Vector3 pos = new Vector3(xVal, 0, zVal);
                Quaternion rot = Quaternion.Euler(0, 180, 0);

                var obj = Instantiate(enermyshipObj, pos, rot) as GameObject;
            }
            totalCount += count;
            fps.SetCount(totalCount);
        }
    }
}