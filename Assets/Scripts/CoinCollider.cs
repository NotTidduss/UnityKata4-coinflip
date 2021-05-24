using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    public string winningSide;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Table") {
            PlayerPrefs.SetString("kata4_coin_flip_result", winningSide);
        }
    }
}
