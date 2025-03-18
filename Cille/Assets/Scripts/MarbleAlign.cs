using UnityEngine;
using UnityEngine.UI;

public class MarbleAlign : MonoBehaviour
{
    public InputField input;
    private int value;
    public GameObject marble;


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Align();
        }
    }
    public void Align()
    {
        int.TryParse(input.text, out value );
        for ( int i = 0; i < value; i++ )
        {
            if ( i == 0 )
            {
                Instantiate(marble, new Vector3(0, 1.5f, 10f), Quaternion.identity);
            }
            else if(i%2 == 0 && i != 0)
            {
                Instantiate(marble, new Vector3(1f * i/2, 1.5f, 10f), Quaternion.identity);
            }
            else if(i%2 == 1 && i != 0)
            {
                Instantiate(marble, new Vector3(-1f * (i+1)/2, 1.5f, 10f), Quaternion.identity);
            }
            
        }
        input.gameObject.SetActive(false);
    }
}
