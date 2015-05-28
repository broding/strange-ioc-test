using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ButtonView : SignalView<Signal> {

    void OnMouseDown() {
        Signal.Dispatch();
    }

}
