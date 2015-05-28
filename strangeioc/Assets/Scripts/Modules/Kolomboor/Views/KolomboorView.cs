using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class KolomboorView : View {

    public bool IsSpinning { get; set; }
    public float MotorSpeed { get; set; }
    public SliderView RPMMeter { get; private set; }

    private Renderer light { get; set; }
    private Transform boor;

    private void Start() {
        boor = transform.FindChild("r_Boor");
        RPMMeter = transform.FindChild("r_RPMMeter").GetComponent<SliderView>();
        light = transform.FindChild("r_Light").GetComponent<Renderer>();
    }
	
	private void Update () {
        if (IsSpinning) {
            boor.Rotate(0.1f * MotorSpeed, 0, 0.1f * MotorSpeed);
        }
	}

    public void SetLight(bool on) {
        if (on) {
            light.material.color = Color.green;
        } else {
            light.material.color = Color.red;
        }
    }
}
