using UnityEngine;

public class Marble : MonoBehaviour
{
    public float y = 1.3f;
    public Line line;
    public float x;

    public void Start()
    {
        line = GameObject.FindAnyObjectByType<Line>();
        x = this.gameObject.transform.position.x;
    }
    public void CheckAround()
    {
        
        Collider[] m = Physics.OverlapSphere(transform.position, y);
        foreach (Collider c in m)
        {
            if(c.gameObject.tag != this.gameObject.tag)
            {
                Destroy(c.gameObject);
            }
        }
        
    }

}
