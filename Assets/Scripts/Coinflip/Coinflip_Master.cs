using System.Collections;
using UnityEngine;

public class Coinflip_Master : MonoBehaviour
{
    [Header("Scene References")]
    [SerializeField] private Coinflip_UI ui;
    [SerializeField] private GameObject coin;

    [Header("Settings")]
    [SerializeField] private float pushForceFactor = 1f;

    private Coinflip_GameState gameState;
    private Vector3 mousePos;
    private Vector3 pushForce = new Vector3(0, 0, 0);
    private bool isCoinFlipable = false;
    private float randomPushForceAmplifier;

    void Start() {
        PlayerPrefs.SetString("cf_current_bet", "");
        PlayerPrefs.SetString("cf_coin_flip_result", "");
        randomPushForceAmplifier = Random.Range(5, 51);
        ui.initialize();
        setGameState(Coinflip_GameState.BETTING);

        StartCoroutine("StateControl");
    }

    IEnumerator StateControl() {
        while(true) {
            switch (gameState) {
                case Coinflip_GameState.BETTING:
                    if (PlayerPrefs.GetString("cf_current_bet") != "") setGameState(Coinflip_GameState.FLIPPING);
                    break;
                case Coinflip_GameState.FLIPPING:
                    if (PlayerPrefs.GetString("cf_coin_flip_result") != "") setGameState(Coinflip_GameState.FINISHING);
                    if (isCoinFlipable) {
                        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        if (Input.GetMouseButtonDown(0)) pushForce += new Vector3(0, 0, randomPushForceAmplifier * pushForceFactor);
                        if (Input.GetMouseButtonUp(0)) flipCoin();
                    }
                    break;
            }
            yield return null;
        }
    }

    private void setGameState(Coinflip_GameState state) {
        gameState = state; 

        switch (gameState) {
            case Coinflip_GameState.FLIPPING:
                ui.hideAllMenus();
                isCoinFlipable = true;
                break;
            case Coinflip_GameState.FINISHING:
                ui.hideAllMenus();
                ui.showResults();
                break;
        }
    }

    private void flipCoin() {
        coin.GetComponent<Rigidbody>().AddForceAtPosition(pushForce, mousePos);
        isCoinFlipable = false;
    }
}
