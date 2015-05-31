using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ButtonView : SignalsView {

    [ModuleSignal("OnButtonPressed")]
    public Signal OnButtonPressedSignal = new Signal();

    void OnMouseDown() {
        OnButtonPressedSignal.Dispatch();
    }

}
