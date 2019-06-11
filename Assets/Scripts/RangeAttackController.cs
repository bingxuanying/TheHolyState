using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SelectableCharacterController))]
    public class RangeAttackController : MonoBehaviour
    {
        private Animator _animator;
        private MovableController _movableController;
        private SelectableCharacterController _selectableCharacterController;
        private GameObject _target;
        private float _timer;
        public float AttackPeriod = 2;
        public GameObject SpellPrefab;
        private HPController _hpController;
        public bool Attack { get; private set; }
        private bool _aiSearching = false;

        private void Start()
        {
            _selectableCharacterController = GetComponent<SelectableCharacterController>();
            _movableController = GetComponent<MovableController>();
            _animator = GetComponent<Animator>();
            _timer = AttackPeriod;
            _hpController = GetComponent<HPController>();
        }

        private void Update()
        {
            if (_target == null) Attack = false;

            if (!_hpController.isEnemy)
                SelfFindAttackTarget();
            else
            {
                if (!_aiSearching)
                    StartCoroutine(AISetAttackTarget());
            }

            if (Attack)
            {
                _animator.SetBool("Attack", true);
                var faceVector = _target.transform.position - transform.position;
                _animator.SetInteger("Direction", faceVector.MainDirection());

                _movableController?.Stop();
                _timer += Time.deltaTime;
                if (_timer >= AttackPeriod)
                {
                    var spell = Instantiate(SpellPrefab);
                    spell.transform.position = transform.position + Vector3.up * 0.5f;
                    spell.transform.position +=
                        (_target.transform.position - transform.position).MainDirectionVec() * 0.6f;
                    spell.GetComponent<SpellController>().Target = _target;
                    _timer -= AttackPeriod;
                }
            }
            else
            {
                _animator.SetBool("Attack", false);
                _movableController?.Run();
                _timer = AttackPeriod;
            }
        }

        private void SelfFindAttackTarget()
        {
            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    Mathf.Infinity, 1 << 8);
                if (hit)
                {
                    var enemyHpController = hit.collider.transform.gameObject.GetComponent<HPController>();
                    if (enemyHpController != null && enemyHpController.isEnemy != _hpController.isEnemy)
                    {
                        Attack = true;
                        _target = hit.collider.transform.gameObject;
                    }
                }
                else
                {
                    Attack = false;
                }
            }
        }

        public IEnumerator AISetAttackTarget()
        {
            _aiSearching = true;
            var enemyList = HPController.AttackableGameObjects.Where(t => t.Item2 != _hpController.isEnemy)
                .Select(t => new
                {
                    GameObject = t.Item1,
                    DestLen = (gameObject.transform.position - t.Item1.transform.position).magnitude
                })
                .OrderBy(t => t.DestLen).Select(t=>t.GameObject);
            foreach (var enemy in enemyList)
            {
                if (enemy == null) continue;
                var dest = enemy.transform.position;
                dest.x += Random.Range(-4, 4);
                dest.y += Random.Range(-4, 4);
                if (_movableController.SetDestination(dest))
                {
                    while (enemy != null && (gameObject.transform.position - enemy.transform.position).magnitude > 5)
                    {
                        yield return new WaitForSeconds(5);
                    }

                    if (enemy != null)
                    {
                        Attack = true;
                        _target = enemy;
                    }
                }
            }
            _aiSearching = false;
        }
    }
}