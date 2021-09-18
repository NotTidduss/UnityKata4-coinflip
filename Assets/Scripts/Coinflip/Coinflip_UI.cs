using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coinflip_UI : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private Text resultText;
    [SerializeField] private Text totalWinsText;
    [SerializeField] private Text totalLossesText;

    [Header("Images")]
    [SerializeField] private Image resultBG;

    [Header("Menus")]
    [SerializeField] private GameObject betMenu;
    [SerializeField] private GameObject resultMenu;

    public void initialize() {
        hideAllMenus();
        showBetMenu();
    }

    public void showResults() {
        showResultMenu();
        if (PlayerPrefs.GetString("cf_coin_flip_result") == PlayerPrefs.GetString("cf_current_bet")) {
            resultBG.color = new Color(0, 255, 0, 0.5f);
            setResultText("You win :D");
            PlayerPrefs.SetInt("cf_win_count", PlayerPrefs.GetInt("cf_win_count") + 1);
        }
        else {
            resultBG.color = new Color(255, 0, 0, 0.5f);
            setResultText("You lose D:");
            PlayerPrefs.SetInt("cf_lose_count", PlayerPrefs.GetInt("cf_lose_count") + 1);
        }
        updateStatsTexts();
    }

    #region Text
    private void setText(Text t, string s) => t.text = s;
    private void setResultText(string newText) => setText(resultText, newText);
    private void updateStatsTexts() {
        setText(totalWinsText, "Total Wins: " + PlayerPrefs.GetInt("cf_win_count"));
        setText(totalLossesText, "Total Losses: " + PlayerPrefs.GetInt("cf_lose_count"));
    } 
    #endregion

    #region Menu
    public void hideAllMenus() {
        betMenu.SetActive(false);
        resultMenu.SetActive(false);
    }
    public void showBetMenu() => betMenu.SetActive(true);
    public void showResultMenu() => resultMenu.SetActive(true);
    #endregion

    #region Button
    public void setBet(string bet) => PlayerPrefs.SetString("cf_current_bet", bet);
    public void playAgain() => SceneManager.LoadScene("1_CoinFlip");
    #endregion
}
