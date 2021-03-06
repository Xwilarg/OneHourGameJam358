using UnityEngine;

public class GameFile : MonoBehaviour
{
    public GameObject Target { set; get; }
    public Computer Parent { set; get; }
    public bool IsSec { set; get; }

    [SerializeField]
    private AudioSource _source;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, 5f * Time.deltaTime);
        if (Vector2.Distance(Target.transform.position, transform.position) < .1f)
        {
            Parent.Received++;
            Parent.UpdateText();
            if (IsSec)
            {
                Cloud.Instance.UpSecurity();
            }
            if (Parent.Received + Parent.Lost == Parent.FileCount)
            {
                Destroy(Parent.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (!IsSec)
        {

            ScoreManager.Instance.IncScore();
        }
        _source.Play();
        Parent.Lost++;
        Parent.UpdateText();
        ComputerManager.Instance.StartUserInter();
        if (Parent.Received + Parent.Lost == Parent.FileCount)
        {
            Destroy(Parent.gameObject);
        }
        Destroy(gameObject);
    }
}