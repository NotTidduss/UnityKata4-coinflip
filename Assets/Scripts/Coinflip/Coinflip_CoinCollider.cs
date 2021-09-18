using UnityEngine;

public class CF_CoinCollider : MonoBehaviour
{
    [Header("Coin Collider Properties")]
    [SerializeField] private string winningSide;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Table") {
            PlayerPrefs.SetString("cf_coin_flip_result", winningSide);
        }
    }
}
