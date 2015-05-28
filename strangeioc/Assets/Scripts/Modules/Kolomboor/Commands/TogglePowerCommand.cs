using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class TogglePowerCommand : Command {

    [Inject]
    public KolomboorModel model { get; set; }

    [Inject]
    public ModelChangedSignal modelChangedSingel { get; set; }

    public override void Execute() {
        model.On = !model.On;

        modelChangedSingel.Dispatch(model);
    }
}
