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
        public bool Attack { get; private set; }

        private void Start()
        {
            _selectableCharacterController = GetComponent<SelectableCharacterController>();
            _movableController = GetComponent<MovableController>();
            _animator = GetComponent<Animator>();
            _timer = AttackPeriod;
        }

        private void Update()
        {
            if (_target == null) Attack = false;

            if (_selectableCharacterController.Selected && Input.GetMouseButtonDown(1))
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                    Mathf.Infinity, 1 << 8);
                if (hit)
                {
                    if (GetComponent<HPController>().isEnemy !=
                        hit.collider.transform.gameObject.GetComponent<HPController>().isEnemy)
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
                    spell.transform.position = transform.position;
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
    }
}