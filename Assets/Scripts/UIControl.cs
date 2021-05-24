using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public GameObject betSelectionMenu;
    public GameObject resultsMenu;

    public Image resultBG;
    public Text resultTitle;
    public Text totalWinsText;
    public Text totalLossesText;

    void Start() {
        switchMenus(true, false);
    }

    public void setBet(string bet) => PlayerPrefs.SetString("kata4_current_bet", bet);
    public void playAgain() => SceneManager.LoadScene("Main");

    public void switchMenus(bool bmActive, bool rmActive) {
        betSelectionMenu.SetActive(bmActive);
        resultsMenu.SetActive(rmActive);
    }

    public void adjustResults() {
        if (PlayerPrefs.GetString("kata4_coin_flip_result") == PlayerPrefs.GetString("kata4_current_bet")) {
            resultBG.color = new Color(0, 255, 0, 0.5f);
            resultTitle.text = "You win :D";
            PlayerPrefs.SetInt("kata4_win_count", PlayerPrefs.GetInt("kata4_win_count") + 1);
        }
        else {
            resultBG.color = new Color(255, 0, 0, 0.5f);
            resultTitle.text = "You lose D:";
            PlayerPrefs.SetInt("kata4_lose_count", PlayerPrefs.GetInt("kata4_lose_count") + 1);
        }
        totalWinsText.text = "Total Wins: " + PlayerPrefs.GetInt("kata4_win_count");
        totalLossesText.text = "Total Losses: " + PlayerPrefs.GetInt("kata4_lose_count");
    }
}
