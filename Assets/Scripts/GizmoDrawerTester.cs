using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class GizmoDrawerTester : MonoBehaviour
{
    internal void Start()
    {
        int count = 100;
        for (int i = 0; i < count; i++)
        {
            GizmoDrawer.Instance.DrawCube(Vector3.zero, Vector3.one);
            GizmoDrawer.Instance.DrawWireCube(Vector3.zero, Vector3.one);
            GizmoDrawer.Instance.DrawSphere(Vector3.zero, 1f);
            GizmoDrawer.Instance.DrawWireSphere(Vector3.zero, 1f);
        }
    }
}