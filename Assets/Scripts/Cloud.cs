using TMPro;
using UnityEngine;

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

    private void Update()
    {
        _sec.text = "Security layers: 0 / 10";
    }

    public void UpSecurity()
    {
        layer++;
        _sec.text = $"Security layers: {layer} / 10";
    }
}
