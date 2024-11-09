using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Entities;

namespace Lesson1M.Assets
{
    public class MoveSystem: ComponentSystem
    {
        private EntityQuery _query;

        protected override void OnCreate()
        {
            _query = GetEntityQuery(ComponentType.ReadOnly<MoveComponent>());
        }
        protected override void OnUpdate()
        {
            Entities.With(_query).ForEach((Entity entity, Transform transform, MoveComponent move) =>
            {
                var p = transform.position;
                p.y += (move.moveSpeed/1000);
                transform.position = p;
            });
        }
    }
}