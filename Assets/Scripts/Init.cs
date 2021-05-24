using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Awake() {
        resetPlayerPrefs();
        SceneManager.LoadScene("Main");
    }

    void resetPlayerPrefs() {
        PlayerPrefs.DeleteAll();

        // STRING kata4_current_bet: the currently selected bet, either heads or tails. Starts empty.
        PlayerPrefs.SetString("kata4_current_bet", "");

        // STRING kata4_coin_flip_result: the result of the coin flip, either heads or tails. Starts empty.
        PlayerPrefs.SetString("kata4_coin_flip_result", "");

        // INT kata4_win_count: the amount of total wins.
        // INT kata4_lose_count: the amount of total losses. 
    }
}
