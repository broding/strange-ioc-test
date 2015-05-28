using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class KolomboorMediator : Mediator {

    [Inject]
    public KolomboorModel Model { get; set; }

    [Inject]
    public ModelChangedSignal ModelChangedSignal { get; set; }

    [Inject]
    public KolomboorView View { get; set; }

    public override void OnRegister() {
        base.OnRegister();

        ModelChangedSignal.AddListener(onModelChanged);
    }

    private void onModelChanged(IModuleModel model) {
        if (model != Model)
            return;

        View.IsSpinning = Model.On;
        View.MotorSpeed = Model.Speed;
        View.RPMMeter.Handle.IsMovable = !Model.On;
        View.SetLight(Model.On);
    }
}
