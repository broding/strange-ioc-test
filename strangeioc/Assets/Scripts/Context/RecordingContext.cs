using strange.extensions.context.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RecordingContext : CraftContext {
    public RecordingContext(ContextView view)
        : base(view) {

    }

    protected override void mapBindings() {
        base.mapBindings();

        commandBinder.Bind<ModelChangedSignal>().To<RecordStepCommand>();
    }
}
