using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class CraftRoot : ContextView {

    private void Awake() {
        context = new RecordingContext(this);
    }
}
