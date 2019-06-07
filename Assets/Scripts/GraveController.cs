using UnityEngine;

namespace Assets.Scripts
{
    public class GraveController : MonoBehaviour
    {
        private float Timer { get; set; } = 0;
        public GameObject GeneratedPrefab;
        public float GenerateTime = 10;

        // Start is called before the first frame update
        void Start()
        {
            Timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            Timer += Time.deltaTime;
            if (Timer >= GenerateTime)
            {
                Timer -= GenerateTime;
                var target = Instantiate(GeneratedPrefab, transform);
                target.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        public void GenerateGhost()
        {
            var ghost = Resources.Load("prefab/ghost", typeof(GameObject)) as GameObject;
            var target = Instantiate(ghost, transform);
            target.transform.localPosition = new Vector3(0, 0, 0);
        }

        public void GenerateWeakZombie()
        {
            var ghost = Resources.Load("prefab/weakzombie", typeof(GameObject)) as GameObject;
            var target = Instantiate(ghost, transform);
            target.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
