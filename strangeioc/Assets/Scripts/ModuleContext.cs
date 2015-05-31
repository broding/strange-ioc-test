using UnityEngine;
using System.Collections;
using System.Reflection;
using strange.extensions.context.impl;
using System;
using System.Linq;
using strange.extensions.command.impl;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using System.Reflection.Emit;
using System.Threading;
using System.Linq;
using strange.extensions.signal.impl;
using System.Collections.ObjectModel;

public class ModuleContext : MVCSContext {

    public ModuleContext(ModuleRoot view)
        : base(view) {
    }

    protected override void postBindings()
    {
        base.postBindings();

        ModuleRoot moduleRoot = (contextView as GameObject).GetComponent<ModuleRoot>();

        foreach (ModuleRoot.CommandSignalConnection con in moduleRoot.Connections) {
            Debug.Log(con.SignalField.Field);
            Type newType = CreateSignalType(con.SignalField.Field.FieldType, con.SignalField.Name);
            BaseSignal newSignal = (BaseSignal)Activator.CreateInstance(newType);
            ReplaceSignal(con.SignalField.View, con.SignalField.Field.GetValue(con.SignalField.View) as BaseSignal, newSignal);
            Debug.Log(newSignal.GetType());
        }



        /*
        List<BaseSignal> signals = new List<BaseSignal>();

        foreach (SignalsMediator mediator in mediators)
        {
            foreach (KeyValuePair<string, BaseSignal> pair in mediator.Signals) {
                Type type = CreateSignalType(pair.Value.GetType(), mediator.gameObject.name + "_" + pair.Key);

                BaseSignal newSignal = (BaseSignal)Activator.CreateInstance(type);
                if (ReplaceSignal(mediator, pair.Value, newSignal)) {
                    signals.Add(newSignal);
                }else{
                    throw new Exception("Could not replace the newly created signal called: " + newSignal.GetType().Name);
                }
            }
        }
         */
    }

    private bool ReplaceSignal(SignalsView view, BaseSignal oldSignal, BaseSignal newSignal) {
        foreach (FieldInfo field in view.GetType().GetFields()) {
            if (field.GetValue(view) == oldSignal) {
                field.SetValue(view, newSignal);
                return true;
            }
        }

        return false;
    }

    private Type CreateSignalType(Type signalType, string name) {
        AssemblyName assemblyName = new AssemblyName();
        assemblyName.Name = "tmpAssembly";
        AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
        ModuleBuilder module = assemblyBuilder.DefineDynamicModule("tmpModule");
        TypeBuilder typeBuilder = module.DefineType(name, TypeAttributes.Public | TypeAttributes.Class, signalType);

        Type generatedType = typeBuilder.CreateType();
        return generatedType;
    }
}

