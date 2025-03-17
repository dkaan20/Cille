using System;
using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    public TurnSystem turnSystem;
    private int player1Score = 0;
    private int player2Score = 0;

    private int y = 0;

    public TMPro.TMP_Text text1;
    public TMPro.TMP_Text text2;
    public IEnumerator TakeMarble()
    {
        yield return new WaitForSeconds(4f);
        int x = 0;
        GameObject[] marble = GameObject.FindGameObjectsWithTag("Marble");
        foreach (GameObject mar in marble)
        {
            if(mar.gameObject.transform.position.z >= 0.03 || mar.gameObject.transform.position.y <= -0.03)
            {
                Destroy(mar);
                x++;
                Debug.Log(x);
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
