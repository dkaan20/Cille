using System;
using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    public TurnSystem turnSystem;
    public int player1Score = 0;
    public int player2Score = 0;

    public TMPro.TMP_Text text1;
    public TMPro.TMP_Text text2;
    public IEnumerator TakeMarble()
    {
        yield return new WaitForSeconds(3f);
        int x = 0;
        GameObject[] marble = GameObject.FindGameObjectsWithTag("Marble");
        foreach (GameObject mar in marble)
        {
            Marble mr = mar.GetComponent<Marble>();
            if (mar.gameObject.transform.position.z >= 10.2 || mar.gameObject.transform.position.z <= 9.8)
            {
                Destroy(mar);
                x++;
                Debug.Log(x);
            }
            else if(mr.x -1 >= mar.transform.position.x || mr.x + 1 <= mar.transform.position.x)
            {
                Destroy(mar);
                x++;
            }

            
        }
        if (turnSystem.player == 1)
        {
            player1Score += x;
            text1.text = "Player 1 \n" + player1Score.ToString();
        }
        else if (turnSystem.player == -1)
        {
            player2Score += x;
            text2.text = "Player 2 \n" + player2Score.ToString();
        }
        StartCoroutine(turnSystem.Turn());
    }
}
