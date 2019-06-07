using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class SpellController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        public float Speed = 1000;
        public GameObject Target;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Target != null)
            {
                var direction = (Target.transform.position - transform.position).normalized;
                _rigidbody2D.velocity = direction * Speed * Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (Target == collision.transform.gameObject)
            {
                var hp = Target.GetComponent<HPController>();
                hp.HP -= 3;
                Destroy(gameObject);
            }
        }
    }
}