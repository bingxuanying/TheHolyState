using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(SelectableCharacterController))]
    internal class MovableController : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private float _savedSpeed;

        private SelectableCharacterController _selectableCharacterController;

        private void Update()
        {
            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
                _agent.destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Awake()
        {
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