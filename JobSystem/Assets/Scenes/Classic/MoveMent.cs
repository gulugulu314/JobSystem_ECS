using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classic {

    public class MoveMent : MonoBehaviour {

        void Update() {

            Vector3 pos = transform.position;
            pos += transform.forward * GameManager.GM.enermySpeed * Time.deltaTime;

            if (pos.z < GameManager.GM.bottomBoundary)
                pos.z = GameManager.GM.topBoundary;

            transform.position = pos;
        }
    }
}