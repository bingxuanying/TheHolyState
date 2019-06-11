using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SelectableCharacterController))]
    class GatheringController : MonoBehaviour
    {
        private Animator _animator;
        private SelectableCharacterController _selectableCharacterController;
        private GameObject _target;
        private float _timer;
        public float GatheringPeriod = 1;
        public bool Gathering { get; private set; }

        private void Start()
        {
            _selectableCharacterController = GetComponent<SelectableCharacterController>();
            _animator = GetComponent<Animator>();
            _timer = 0;
        }

        private void Update()
        {
            if (_target == null) Gathering = false;

            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    Mathf.Infinity, 1 << 13);
                if (hit)
                {
                    _target = hit.collider.transform.gameObject;
                }
                else
                {
                    _target = null;
                    Gathering = false;
                }
            }

            if (Gathering)
            {
                _animator.SetBool("Attack", true);
                var faceVector = _target.transform.position - transform.position;
                _animator.SetInteger("Direction", faceVector.MainDirection());

                _timer += Time.deltaTime;
                if (_timer >= GatheringPeriod)
                {
                    if (_target.CompareTag("Water"))
                    {
                        GlobalVars.Water += 1;
                        _timer -= GatheringPeriod;
                    }

                    if (_target.CompareTag("Wood"))
                    {
                        GlobalVars.Water += 1;
                        GlobalVars.Wood += 1;
                        Destroy(_target);
                        Gathering = false;
                    }
                }
            }
            else
            {
                _animator.SetBool("Attack", false);
                _timer = 0;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (_target == collision.gameObject)
                Gathering = true;
        }
    }
}
