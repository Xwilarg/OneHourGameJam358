using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject Target { set; get; }
    [SerializeField]
    private GameObject _file;

    [SerializeField]
    private float _spawnDelayMin, _spawnDelayMax;

    public int FileCount { get; set; }
    public int Sent, Received;

    private float timerSpawn;
    private void Start()
    {
        timerSpawn = Random.Range(_spawnDelayMin, _spawnDelayMax);
        FileCount = Random.Range(5, 15);
    }

    private void Update()
    {
        timerSpawn -= Time.deltaTime;

        if (timerSpawn < 0f && Sent < FileCount)
        {
            var go = Instantiate(_file, transform.position, Quaternion.identity);
            var gf = go.GetComponent<GameFile>();
            gf.Target = Target;
            gf.Parent = this;
            timerSpawn = Random.Range(_spawnDelayMin, _spawnDelayMax);
            Sent++;
        }
    }
}