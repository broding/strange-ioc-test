﻿using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SliderView : SignalView<Signal<float>> {

    public SliderHandleScript Handle;

    private void Awake() {
        Handle = transform.FindChild("r_Handle").GetComponent<SliderHandleScript>();
        Handle.OnHandleReleasedSignal.AddListener(OnHandleReleased);
    }

    private void OnHandleReleased() {
        Signal.Dispatch(UnityEngine.Random.Range(0, 100));
    }
}
