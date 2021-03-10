using UnityEngine;
using GizmoDrawer;

namespace Tests
{
    public class GizmoDrawerTester : MonoBehaviour
    {
        internal void Start()
        {
            int count = 100;
            for (int i = 0; i < count; i++)
            {
                Drawer.Instance.DrawCube(Vector3.zero, Vector3.one);
                Drawer.Instance.DrawWireCube(Vector3.zero, Vector3.one);
                Drawer.Instance.DrawSphere(Vector3.zero, 1f);
                Drawer.Instance.DrawWireSphere(Vector3.zero, 1f);
            }
        }
    }
}