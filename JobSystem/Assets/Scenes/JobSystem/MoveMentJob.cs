using UnityEngine.Jobs;
using UnityEngine;
using Unity.Jobs;

namespace JobSystem {

    public struct MoveMentJob : IJobParallelForTransform {

        //data：定义需要处理的data
        //struct:data的类型为struct
        //interface:实现job接口

        public float moveSpeed;
        public float topBound;
        public float bottomBound;
        public float deltaTime;

        public void Execute(int index, TransformAccess transform) {

            Vector3 pos = transform.position;
            pos += moveSpeed * deltaTime * (transform.rotation * new Vector3(0, 0, 1));

            if (pos.z < bottomBound)
                pos.z = topBound;

            transform.position = pos;
        }
    }
}


public struct job2 : IJobParallelForFilter {
    public bool Execute(int index) {
        return false;
    }
}

public struct job3 : IJobParallelForBatch {
    public void Execute(int startIndex, int count) {
        throw new System.NotImplementedException();
    }
}