using UnityEngine;
using UnityEngine.SceneManagement;

public class CF_Init : MonoBehaviour
{
    void Awake() {
        initializePlayerPrefs();
        SceneManager.LoadScene("1_CoinFlip");
    }

    private void initializePlayerPrefs() {
        /*
            permament PlayerPrefs
            INT cf_win_count: the amount of total wins.
            INT cf_lose_count: the amount of total losses. 
        */

        // STRING cf_current_bet: the currently selected bet, either heads or tails. Starts empty.
        PlayerPrefs.SetString("cf_current_bet", "");

        // STRING cf_coin_flip_result: the result of the coin flip, either heads or tails. Starts empty.
        PlayerPrefs.SetString("cf_coin_flip_result", "");
    }
}
