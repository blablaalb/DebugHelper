using System;
using UnityEngine;

namespace GizmoDrawer.Drawables
{
    [Serializable]
    internal class GizmoSphere : IDrawable
    {
        private readonly Color _color;

        public readonly Vector3 Center;
        public readonly float Radius;

        public GizmoSphere(Vector3 center, float radius, Color color)
        {
            _color = color;
            Center = center;
            Radius = radius;
        }

        public void Draw()
        {
            Color previousColor = Gizmos.color;
            Gizmos.color = _color;
            Gizmos.DrawSphere(Center, Radius);
            Gizmos.color = previousColor;
        }

        public bool Equals(IDrawable other)
        {
            return other is GizmoSphere otherGC && otherGC.Center.Equals(this.Center) && otherGC.Radius.Equals(this.Radius);
        }

        public override bool Equals(object other)
        {
            return other is GizmoSphere otherGC && otherGC.Center.Equals(this.Center) && otherGC.Radius.Equals(this.Radius);
        }
    }
}
