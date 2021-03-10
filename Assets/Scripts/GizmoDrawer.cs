using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class GizmoDrawer : MonoBehaviour
{
    private static GizmoDrawer _instance;
    private List<IDrawable> _drawables;

    public static GizmoDrawer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GizmoDrawer>();
                if (_instance == null)
                {
                    GameObject gizmoDrawerGO = new GameObject();
                    gizmoDrawerGO.name = "Gizmo Drawer";
                    gizmoDrawerGO.transform.position = Vector3.zero;
                    gizmoDrawerGO.transform.rotation = Quaternion.identity;
                    _instance = gizmoDrawerGO.AddComponent(typeof(GizmoDrawer)) as GizmoDrawer;
                }
            }
            return _instance;
        }
    }

    internal void Awake()
    {
        if (_drawables == null)
            _drawables = new List<IDrawable>();
    }

    internal void OnDrawGizmos()
    {
        DrawDrawables();
    }

    public void DrawCube(Vector3 origin, Vector3 size, Color color = new Color())
    {
        color = color == default(Color) ? Gizmos.color : color;
        GizmoCube gizmoCube = new GizmoCube(origin, size, color);
        Add(gizmoCube);
    }

    public void DrawWireCube(Vector3 origin, Vector3 size, Color color = new Color())
    {
        color = color == default(Color) ? Gizmos.color : color;
        GizmoWireCube gizmoWireCube = new GizmoWireCube(origin, size, color);
        Add(gizmoWireCube);
    }

    public void DrawSphere(Vector3 center, float radius, Color color = new Color())
    {
        color = color == default(Color) ? Gizmos.color : color;
        GizmoSphere gizmoSphere = new GizmoSphere(center, radius, color);
        Add(gizmoSphere);
    }

    public void DrawWireSphere(Vector3 center, float radius, Color color = new Color())
    {
        color = color == default(Color) ? Gizmos.color : color;
        GizmoWireSphere gizmoWireSphere = new GizmoWireSphere(center, radius, color);
        Add(gizmoWireSphere);
    }

    private void DrawDrawables()
    {
        if (_drawables != null)
            foreach (IDrawable drawable in _drawables)
            {
                drawable.Draw();
            }
    }

    private void Add(IDrawable drawable)
    {
        if (_drawables != null && !_drawables.Contains(drawable)) _drawables.Add(drawable);
    }
}
