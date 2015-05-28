using strange.extensions.command.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class RecordStepCommand : Command {

    [Inject]
    public ModelChangedSignal ModelChangedSignal { get; set; }

    [Inject]
    public IModuleModel ModuleModel { get; set; }

    public override void Execute() {
        Debug.Log("Saved model: " + ModuleModel.Serialize());
    }

}
