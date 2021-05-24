using System.Collections;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public GameObject focusObject;

    private Vector3 cameraOffset;

    void Start() {
        cameraOffset = gameObject.transform.position - focusObject.transform.position;

        StartCoroutine("MoveWithFocus");
    }

    IEnumerator MoveWithFocus() {
        while(true) {
            gameObject.transform.position = focusObject.transform.position + cameraOffset;
            yield return null;
        }
    }
}
