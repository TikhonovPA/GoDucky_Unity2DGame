using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private short score = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();

            if (PlayerPrefs.GetInt("score") < score)
                PlayerPrefs.SetInt("score", score);
        }
    }
}
