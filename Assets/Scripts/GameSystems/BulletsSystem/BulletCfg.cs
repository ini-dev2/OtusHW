using UnityEngine;
using Scripts.Common;

namespace Scripts.BulletSystem
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletsFixed/New BulletConfig")]
    public sealed class BulletCfg : ScriptableObject
    {
        [SerializeField]
        public PhysicsLayer physicsLayer;

        [SerializeField]
        public Color color;

        [SerializeField]
        public int damage;

        [SerializeField]
        public float speed;
    }
}