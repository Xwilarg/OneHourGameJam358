using UnityEngine;

namespace Assets.Scripts
{
    public class ComputerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject Target;
        public static ComputerManager Instance { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        [SerializeField]
        private GameObject _computer;

        [SerializeField]
        private float _spawnDelayMin, _spawnDelayMax;

        private float timerSpawn;

        [SerializeField]
        private float _maxX = 7f;
        [SerializeField]
        private float _minY = 4f;

        private void Start()
        {
            timerSpawn = Random.Range(_spawnDelayMin, _spawnDelayMax);
        }

        private void Update()
        {
            timerSpawn -= Time.deltaTime;

            if (timerSpawn < 0f)
            {
                var go = Instantiate(_computer, new Vector2(Random.Range(-_maxX, _maxX), Random.Range(-_minY, 0f)), Quaternion.identity);
                go.GetComponent<Computer>().Target = Target;
                timerSpawn = Random.Range(_spawnDelayMin, _spawnDelayMax);
            }
        }
    }
}
