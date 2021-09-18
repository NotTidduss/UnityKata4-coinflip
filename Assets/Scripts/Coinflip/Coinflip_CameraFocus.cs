using System.Collections;
using UnityEngine;

public class CF_CameraFocus : MonoBehaviour
{
    [Header("Focused Object")]
    [SerializeField] private GameObject focusObject;

    private Vector3 cameraOffset;

    void Start() {
        cameraOffset = transform.position - focusObject.transform.position;

        StartCoroutine("MoveWithObject");
    }

    IEnumerator MoveWithObject() {
        while(true) {
            transform.position = focusObject.transform.position + cameraOffset;
            yield return null;
        }
    }
}
