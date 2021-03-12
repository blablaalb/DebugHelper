using UnityEngine;
using GizmoDrawer;

namespace Tests
{
    public class GizmoDrawerTester : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _rotationVector;

        internal void LateUpdate()
        {
            Quaternion rotation = Quaternion.Euler(_rotationVector);
            int count = 100;
            for (int i = 0; i < count; i++)
            {
                Drawer.Instance.DrawCube(Vector3.zero, Vector3.one, rotation, Color.gray, .1f);
                Drawer.Instance.DrawWireCube(Vector3.zero, Vector3.one, rotation, Color.white, 0.1f);
                Drawer.Instance.DrawSphere(Vector3.zero, 1f);
                Drawer.Instance.DrawWireSphere(Vector3.zero, 1f);
            }
        }
    }
}