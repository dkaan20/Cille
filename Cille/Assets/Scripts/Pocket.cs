using UnityEngine;
using UnityEngine.UI;

public class Pocket : MonoBehaviour
{
    public int p1 = 10;
    public int p2 = 10;
    public TMPro.TMP_Text p1_text;
    public TMPro.TMP_Text p2_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1_text.text = "In Pocket: " + p1.ToString();
        p2_text.text = "In Pocket: " + p2.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
