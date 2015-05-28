using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class SetSpeedCommand : Command {

    [Inject]
    public KolomboorModel Model { get; set; }

    [Inject]
    public float SliderValue { get; set; }

    [Inject]
    public ModelChangedSignal ModelChangedSignal { get; set; }

    public override void Execute() {
        Model.Speed = SliderValue;

        ModelChangedSignal.Dispatch(Model);
    }
}
