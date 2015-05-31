using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class KolomboorContext : ModuleContext {

    public KolomboorContext(ModuleRoot view)
        : base(view) {

    }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<KolomboorModel>().ToSingleton();
        
        mediationBinder.Bind<KolomboorView>().To<KolomboorMediator>();
    }

    protected override void addCoreComponents() {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
}
