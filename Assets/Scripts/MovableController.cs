using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SelectableCharacterController))]
    internal class MovableController : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _agent;
        private float _savedSpeed;
        private SelectableCharacterController _selectableCharacterController;

        public bool IsStopped { get; private set; }

        private void Update()
        {
            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
                _agent.destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var agentVelocity = _agent.velocity;
            if (agentVelocity.magnitude < 1 && !IsStopped)
            {
                //_agent.destination = gameObject.transform.position;
                IsStopped = true;
            }
            else if (agentVelocity.magnitude >= 1)
            {
                _animator.SetInteger("Direction", agentVelocity.MainDirection());
                IsStopped = false;
            }
            _animator.SetBool("Walk", !IsStopped);
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _selectableCharacterController = GetComponent<SelectableCharacterController>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
            _savedSpeed = _agent.speed;
        }

        public void Stop()
        {
            if (Math.Abs(_agent.speed) > 0.00001)
            {
                _savedSpeed = _agent.speed;
                _agent.speed = 0;
            }
        }

        public void Run()
        {
            if (Math.Abs(_agent.speed) < 0.00001)
            {
                _agent.destination = gameObject.transform.position;
                _agent.speed = _savedSpeed;
            }
        }
    }
}