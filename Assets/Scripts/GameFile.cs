using UnityEngine;

public class GameFile : MonoBehaviour
{
    public GameObject Target { set; get; }
    public Computer Parent { set; get; }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, 10f * Time.deltaTime);
        if (Vector2.Distance(Target.transform.position, transform.position) < .1f)
        {
            Parent.Received++;
            Parent.UpdateText();
            if (Parent.Received + Parent.Lost == Parent.FileCount)
            {
                Destroy(Parent.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Parent.Lost++;
        Parent.UpdateText();
        if (Parent.Received + Parent.Lost == Parent.FileCount)
        {
            Destroy(Parent.gameObject);
        }
        Destroy(gameObject);
    }
}