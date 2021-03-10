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

    public void DrawCube(Vector3 origin, Vector3 size)
    {
        GizmoCube gizmoCube = new GizmoCube(origin, size);
        if (!_drawables.Contains(gizmoCube))
        {
            _drawables.Add(gizmoCube);
        }
    }

    private void DrawDrawables()
    {
        if (_drawables != null)
            foreach (IDrawable drawable in _drawables)
            {
                drawable.Draw();
            }
    }
}
