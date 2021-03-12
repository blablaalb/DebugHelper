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
            Vector3 position = transform.position;
            int count = 100;
            for (int i = 0; i < count; i++)
            {
                Drawer.Instance.DrawCube(position, Vector3.one, rotation, Color.gray, .1f);
                Drawer.Instance.DrawWireCube(position, Vector3.one, rotation, Color.white, 0.1f);
                Drawer.Instance.DrawSphere(position, 1f, rotation: rotation);
                Drawer.Instance.DrawWireSphere(position, 1f, rotation: rotation);
            }
        }
    }
}