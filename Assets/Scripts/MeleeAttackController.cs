using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SelectableCharacterController))]
    class MeleeAttackController : MonoBehaviour
    {
        private Animator _animator;
        private SelectableCharacterController _selectableCharacterController;
        private GameObject _target;
        private float _timer;
        public float AttackPeriod = 1;
        public float Damage = 5;
        public bool Attack { get; private set; }

        private void Start()
        {
            _selectableCharacterController = GetComponent<SelectableCharacterController>();
            _animator = GetComponent<Animator>();
            _timer = AttackPeriod;
        }

        private void Update()
        {
            if (_target == null) Attack = false;

            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    Mathf.Infinity, (1 << 8) + (1 << 14));
                if (hit)
                {
                    var hpController = hit.collider.transform.gameObject.GetComponent<HPController>();
                    if (hpController != null && GetComponent<HPController>().isEnemy != hpController.isEnemy)
                        _target = hit.collider.transform.gameObject;
                }
                else
                {
                    _target = null;
                    Attack = false;
                }
            }

            if (Attack)
            {
                _animator.SetBool("Attack", true);
                var faceVector = _target.transform.position - transform.position;
                _animator.SetInteger("Direction", faceVector.MainDirection());

                _timer += Time.deltaTime;
                if (_timer >= AttackPeriod)
                {
                    _target.GetComponent<HPController>().Hurt(Damage);
                    _timer -= AttackPeriod;
                }
            }
            else
            {
                _animator.SetBool("Attack", false);
                _timer = AttackPeriod;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (_target == collision.gameObject)
                Attack = true;
        }
    }
}
