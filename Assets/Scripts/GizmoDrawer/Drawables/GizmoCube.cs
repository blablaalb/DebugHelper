using System;
using UnityEngine;

namespace GizmoDrawer.Drawables
{
    [Serializable]
    internal class GizmoCube : IDrawable
    {
        private readonly Color _color;

        public readonly Vector3 Origin;
        public readonly Vector3 Size;

        public GizmoCube(Vector3 origin, Vector3 size, Color color)
        {
            _color = color;
            Origin = origin;
            Size = size;
        }

        public void Draw()
        {
            Color previousColor = Gizmos.color;
            Gizmos.color = _color;
            Gizmos.DrawCube(Origin, Size);
            Gizmos.color = previousColor;
        }

        public bool Equals(IDrawable other)
        {
            GizmoCube otherGC = other as GizmoCube;
            return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
        }

        public override bool Equals(object other)
        {
            GizmoCube otherGC = other as GizmoCube;
            return otherGC != null && otherGC.Origin.Equals(this.Origin) && otherGC.Size.Equals(this.Size);
        }
    }
}