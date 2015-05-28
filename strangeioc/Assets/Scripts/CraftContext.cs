using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class CraftContext : MVCSContext {

    public CraftContext(MonoBehaviour view)
        : base(view) {
    }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<ModelChangedSignal>().ToSingleton().CrossContext();
    }

    protected override void addCoreComponents() {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
}
