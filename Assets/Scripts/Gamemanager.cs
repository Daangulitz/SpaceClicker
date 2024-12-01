using TMPro;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoretext;
    
    private int score;
    void Start()
    {
        score = 0;
        
        scoretext.text = "score: " + score;
    }

    // Update is called once per frame
    public void AddScore(int amount)
    {
        score = score + amount;
        
        scoretext.text = "score: " + score;
    }
}
