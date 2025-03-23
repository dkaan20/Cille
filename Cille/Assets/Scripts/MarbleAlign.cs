using System;
using UnityEngine;
using UnityEngine.UI;

public class MarbleAlign : MonoBehaviour
{
    public InputField input;
    [NonSerialized] public int value;
    public GameObject marble;
    public Pocket pocket;
    public TMPro.TMP_Text error;


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            int.TryParse(input.text, out value);
            if (value%2 == 0)
            {
                if (pocket.p1 - (value / 2) < 0 && pocket.p2 - (value / 2) < 0)
                {
                    error.text = "Player 1 and Player 2 doesn't have enough marbles";
                }
                else if(pocket.p1 - (value / 2) < 0)
                {
                    error.text = "Player 1 doesn't have enough marbles";
                }
                else if (pocket.p2 - (value / 2) < 0)
                {
                    error.text = "Player 2 doesn't have enough marbles";
                }
                else
                {
                    Align();
                }
                   
            }
            else if (value%2 == 1)
            {
                error.text = "Please enter an even number";
            }
            
        }

        MarbleAlign mar = GameObject.FindAnyObjectByType<MarbleAlign>();
        Debug.Log(mar.gameObject.name);
    }
    public void Align()
    {
        pocket.p1 -= (value / 2);
        pocket.p2 -= (value / 2);
        pocket.p1_text.text = "In Pocket: " + pocket.p1.ToString();
        pocket.p2_text.text = "In Pocket: " + pocket.p2.ToString();
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
        error.text = "";
    }
}
