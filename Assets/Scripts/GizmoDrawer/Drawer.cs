using System.Collections.Generic;
using GizmoDrawer.Drawables;
using System.Collections;
using UnityEngine;
using System;

namespace GizmoDrawer
{
    public class Drawer : MonoBehaviour
    {
        private struct DrawableAndTimePair : IEquatable<DrawableAndTimePair>
        {
            public readonly IDrawable Drawable;
            public readonly float Time;

            public DrawableAndTimePair(IDrawable drawable, float time)
            {
                Drawable = drawable;
                Time = time;
            }

            public bool Equals(DrawableAndTimePair other)
            {
                return other.Drawable.Equals(this.Drawable) && other.Time.Equals(this.Time);
            }

            public bool Equals(object other)
            {
                return other is DrawableAndTimePair dtp && dtp.Drawable.Equals(this.Drawable) && dtp.Time.Equals(this.Time);
            }
        }

        private static Drawer _instance;
        private List<DrawableAndTimePair> _timedDrawable;

        public static Drawer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Drawer>();
                    if (_instance == null)
                    {
                        GameObject gizmoDrawerGO = new GameObject();
                        gizmoDrawerGO.name = "Gizmo Drawer";
                        gizmoDrawerGO.transform.position = Vector3.zero;
                        gizmoDrawerGO.transform.rotation = Quaternion.identity;
                        _instance = gizmoDrawerGO.AddComponent(typeof(Drawer)) as Drawer;
                    }
                }
                return _instance;
            }
        }

        internal void Awake()
        {
            if (_timedDrawable == null)
                _timedDrawable = new List<DrawableAndTimePair>();
        }

        internal void OnDrawGizmos()
        {
            DrawDrawables();
        }

        public void DrawCube(Vector3 origin, Vector3 size, Quaternion rotation = new Quaternion(), Color color = new Color(), float time = 1f)
        {
            color = color == default(Color) ? Gizmos.color : color;
            rotation = rotation.Equals(default(Quaternion)) ? Quaternion.identity : rotation;
            GizmoCube gizmoCube = new GizmoCube(origin, size, rotation, color);
            Add(gizmoCube, time);
        }

        public void DrawWireCube(Vector3 origin, Vector3 size, Quaternion rotation = new Quaternion(), Color color = new Color(), float time = 1f)
        {
            color = color == default(Color) ? Gizmos.color : color;
            rotation = rotation.Equals(default(Quaternion)) ? Quaternion.identity : rotation;
            GizmoWireCube gizmoWireCube = new GizmoWireCube(origin, size, rotation, color);
            Add(gizmoWireCube, time);
        }

        public void DrawSphere(Vector3 center, float radius, Quaternion rotation = new Quaternion(), Color color = new Color(), float time = 1f)
        {
            color = color == default(Color) ? Gizmos.color : color;
            rotation = rotation.Equals(default(Quaternion)) ? Quaternion.identity : rotation;
            GizmoSphere gizmoSphere = new GizmoSphere(center, radius, rotation, color);
            Add(gizmoSphere, time);
        }

        public void DrawWireSphere(Vector3 center, float radius, Quaternion rotation = new Quaternion(), Color color = new Color(), float time = 1f)
        {
            color = color == default(Color) ? Gizmos.color : color;
            rotation = rotation.Equals(default(Quaternion)) ? Quaternion.identity : rotation;
            GizmoWireSphere gizmoWireSphere = new GizmoWireSphere(center, radius, rotation, color);
            Add(gizmoWireSphere, time);
        }

        private void DrawDrawables()
        {
            if (_timedDrawable != null)
            {
                DrawableAndTimePair[] timedDrawableCopy = new DrawableAndTimePair[_timedDrawable.Count];
                _timedDrawable.CopyTo(timedDrawableCopy);
                foreach (DrawableAndTimePair dtp in timedDrawableCopy)
                {
                    dtp.Drawable.Draw();
                }
            }
        }

        private void Add(IDrawable drawable, float time)
        {
            DrawableAndTimePair timedDrawable = new DrawableAndTimePair(drawable, time);
            if (_timedDrawable != null && !_timedDrawable.Contains(timedDrawable))
            {
                _timedDrawable.Add(timedDrawable);
                StartCoroutine(RemoveDrawableCountdownCoroutine(timedDrawable));
            }
        }

        private IEnumerator RemoveDrawableCountdownCoroutine(DrawableAndTimePair dtp)
        {
            yield return new WaitForSeconds(dtp.Time);
            _timedDrawable.Remove(dtp);
        }
    }
}
