using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(BoxCollider2D))]
    class MeleeCollideChildController:MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D;

        void Start()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _boxCollider2D.isTrigger = true;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            _boxCollider2D.attachedRigidbody.SendMessage("OnTriggerEnter2D", collision);
        }
    }
}
