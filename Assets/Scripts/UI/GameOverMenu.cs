using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public void SetScore(int score)
    {
        _score.text = score.ToString();
    }
}
