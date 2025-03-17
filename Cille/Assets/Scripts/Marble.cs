using UnityEngine;

public class Marble : MonoBehaviour
{
    public float x = 1.3f;
    public Line line;

    public void Start()
    {
        line = GameObject.FindAnyObjectByType<Line>();
    }
    public void CheckAround()
    {
        Collider[] m = Physics.OverlapSphere(transform.position, x);
        foreach (Collider c in m)
        {
            if(c.gameObject.tag != this.gameObject.tag)
            {
                Destroy(c.gameObject);
            }
        }
    }

}
