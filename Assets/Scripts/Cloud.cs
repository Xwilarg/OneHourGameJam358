using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cloud : MonoBehaviour
{
    public static Cloud Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [SerializeField]
    private TMP_Text _sec;

    private int layer;

    private void Start()
    {
        _sec.text = "Security layer: 0 / 10";
    }

    public void UpSecurity()
    {
        layer++;
        if (layer == 10)
        {
            SceneManager.LoadScene("GameOver");
        }
        _sec.text = $"Security layers: {layer} / 10";
    }
}
