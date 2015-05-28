using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

[RequireComponent(typeof(Collider))]
public class SliderHandleScript : MonoBehaviour {

    public Signal OnHandleReleasedSignal = new Signal();

    public bool IsMovable;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void OnMouseDown() {
        if (IsMovable) {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
        }
        
    }

    private void OnMouseDrag() {
        if (IsMovable) {
            Vector3 curScreenPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
        }
    }

    private void OnMouseUp() {
        if (IsMovable) {
            OnHandleReleasedSignal.Dispatch();
        }
    }
}
