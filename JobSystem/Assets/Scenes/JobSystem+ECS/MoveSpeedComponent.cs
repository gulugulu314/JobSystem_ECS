using System;
using Unity.Entities;

namespace JobSystem_ECS {

    [Serializable]
    public struct Movespeed : IComponentData {

        public float value;
    }

    public class MoveSpeedComponent : ComponentDataWrapper<Movespeed> { }
}