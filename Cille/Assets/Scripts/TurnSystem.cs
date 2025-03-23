using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{
    public Pocket pocket;
    public Line line;
    public GameObject panel;
    public TMPro.TMP_Text winner;
    public InputField input;
    public TMPro.TMP_Text whichPlayer;
    [NonSerialized] public int player = 1;
    public GameObject playerPrefab;
    public IEnumerator Turn()
    {
        yield return new WaitForSeconds(2f);
        Destroy(GameObject.FindWithTag("Player"));
        Instantiate(playerPrefab);
        player *= -1;

        GameObject[] marble = GameObject.FindGameObjectsWithTag("Marble");
        if(marble.Length <= 0)
        {
            pocket.p1 += line.player1Score;
            pocket.p2 += line.player2Score;
            pocket.p1_text.text = "In Pocket: " + pocket.p1.ToString();
            pocket.p2_text.text = "In Pocket: " + pocket.p2.ToString();
            line.player1Score = 0;
            line.player2Score = 0;
            line.text1.text = "Player 1 \n" + line.player1Score.ToString();
            line.text2.text = "Player 1 \n" + line.player2Score.ToString();

            if (pocket.p1 <= 0)
            {
                panel.SetActive(true);
                winner.text = "Player 2 won";
            }
            else if (pocket.p2 <= 0)
            {
                panel.SetActive(true);
                winner.text = "Player 1 won";
            }
            else
            {
                input.gameObject.SetActive(true);
            } 
        }

        if (player == 1)
        {
            whichPlayer.text = "Player 1";
            whichPlayer.color = Color.blue;
        }
        else if (player == -1)
        {
            whichPlayer.text = "Player 2";
            whichPlayer.color = Color.red;
        }
    }

    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
