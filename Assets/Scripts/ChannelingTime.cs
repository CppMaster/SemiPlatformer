using UnityEngine;

public class ChannelingTime : MonoBehaviour {

    public float timeLeft = 120f;
    UnityEngine.UI.Text text;
    public GameObject victoryScreen;

    void Start ()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }
    
    void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0f)
        {
            timeLeft = 0f;
            victoryScreen.SetActive(true);
            enabled = false;
        }
        text.text = GetTimeStr(timeLeft);
    }

    public static string GetTimeStr(float time)
    {
        int seconds = Mathf.RoundToInt(time);
        string content = (seconds / 60).ToString();
        content += ":";
        seconds %= 60;
        if (seconds < 10)
            content += "0";
        content += seconds.ToString();
        return content;
    }
}
