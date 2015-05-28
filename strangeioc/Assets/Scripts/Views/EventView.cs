using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class SignalView<T> : View where T : new() {

    public T Signal { get; private set; }

    private void Awake(){
        Signal = new T();
    }
}
