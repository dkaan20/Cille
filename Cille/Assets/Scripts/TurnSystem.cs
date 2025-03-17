using System;
using System.Collections;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public TMPro.TMP_Text whichPlayer;
    [NonSerialized] public int player = 1;
    public GameObject playerPrefab;
    public IEnumerator Turn()
    {
        yield return new WaitForSeconds(3f);
        Destroy(GameObject.FindWithTag("Player"));
        Instantiate(playerPrefab);
        player *= -1;

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
}
