using UnityEngine;

namespace Entity
{
    public class enemyBullet
    {
        public Enemy enemy { get; set; }
        public Direction Direction { get; set; }

        public Vector3 InitialPosition { get; set; }
    }
}