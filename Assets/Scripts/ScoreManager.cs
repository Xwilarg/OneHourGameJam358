
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
    {
    public static ScoreManager Instance { get; private set; }
    private bool _isOnGameOver = false;

    private void OnLevelWasLoaded(int level)
    {
        var score = GameObject.Find("Score");
        if (score != null)
        {
            score.GetComponent<TMP_Text>().text = "Score: " + _scoreInt;
            _isOnGameOver = true;
        }
    }

    private void Update()
    {
        if (_isOnGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    [SerializeField]
    private TMP_Text _score;

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private int _scoreInt;

public void IncScore()
    {
        _scoreInt++;
        _score.text = $"Score: {_scoreInt}";
}

    }