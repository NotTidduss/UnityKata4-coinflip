using System.Collections;
using UnityEngine;

public class Master : MonoBehaviour
{
    public GameObject coin;
    public float pushForceFactor = 1f;

    private GameState gs;
    private UIControl uiRef;
    private Vector3 mousePos;
    private Vector3 pushForce = new Vector3(0, 0, 0);
    private bool flipable = false;
    private float randomPushForceAmplifier;

    void Start() {
        PlayerPrefs.SetString("kata4_current_bet", "");
        PlayerPrefs.SetString("kata4_coin_flip_result", "");

        uiRef = GameObject.Find("UI").GetComponent<UIControl>();
        randomPushForceAmplifier = Random.Range(5, 51);
        switchState(GameState.BETTING);

        StartCoroutine("StateControl");
    }

    IEnumerator StateControl() {
        while(true) {
            switch (gs) {
                case GameState.BETTING:
                    if (PlayerPrefs.GetString("kata4_current_bet") != "") switchState(GameState.FLIPPING);
                    break;
                case GameState.FLIPPING:
                    if (PlayerPrefs.GetString("kata4_coin_flip_result") != "") switchState(GameState.FINISHING);
                    if (flipable) {
                        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        if (Input.GetMouseButtonDown(0)) pushForce += new Vector3(0, 0, randomPushForceAmplifier * pushForceFactor);
                        if (Input.GetMouseButtonUp(0)) flipCoin();
                    }
                    break;
            }
            yield return null;
        }
    }

    private void switchState(GameState state) {
        gs = state; 
        switch (gs) {
            case GameState.FLIPPING:
                uiRef.switchMenus(false, false);
                flipable = true;
                break;
            case GameState.FINISHING:
                uiRef.switchMenus(false, true);
                uiRef.adjustResults();
                break;
        }
    }

    private void flipCoin() {
        coin.GetComponent<Rigidbody>().AddForceAtPosition(pushForce, mousePos);
        flipable = false;
    }
}
