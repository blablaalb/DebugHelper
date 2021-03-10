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
        GizmoDrawer.Instance.DrawCube(Vector3.zero, Vector3.one);
        int count = 2;
        for (int i = 0; i < 2; i++)
        {
        }
    }
}