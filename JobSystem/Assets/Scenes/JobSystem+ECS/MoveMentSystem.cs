using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.Jobs;



namespace JobSystem_ECS {
    public class MoveMentSystem : JobComponentSystem {

        //Filter
        struct MovementJob : IJobProcessComponentData<Position, Rotation, Movespeed> {

            public float topBound;
            public float bottomBound;
            public float deltaTime;

            public void Execute(ref Position pos, ref Rotation rot, ref Movespeed movespeed) {
                float3 value = pos.Value;

                value += deltaTime * movespeed.value * math.forward(rot.Value);

                if (value.z < bottomBound)
                    value.z = topBound;

                pos.Value = value;
            }
        }


        protected override JobHandle OnUpdate(JobHandle inputDeps) {

            MovementJob moveJob = new MovementJob {
                topBound = GameManager.GM.topBoundary,
                bottomBound = GameManager.GM.bottomBoundary,
                deltaTime = Time.deltaTime
            };

            JobHandle moveHandle = moveJob.Schedule(this, inputDeps);
            return moveHandle;
        }
    }
}