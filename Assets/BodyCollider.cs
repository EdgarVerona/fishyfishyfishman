using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    class BodyCollider : MonoBehaviour
    {
        public Fish parentFish = null;

        void OnTriggerEnter(Collider other)
        {
            parentFish.HandleBodyCollision(other.gameObject);
        }

    }
