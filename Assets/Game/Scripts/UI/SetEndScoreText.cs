using TMPro;
using UnityEngine;
using Variables;

public class SetEndScoreText : MonoBehaviour
{
    [SerializeField] private IntVariable _asteroidsDestroyed;

    public void OnGameOver()
    {
        GetComponentInChildren<TMP_Text>().text = "You lost! \n \n Your Score: " + _asteroidsDestroyed.CurrentValue;
        gameObject.SetActive(true);
    }
}
