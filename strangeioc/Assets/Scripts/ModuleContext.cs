using UnityEngine;
using System.Collections;
using System.Reflection;
using strange.extensions.context.impl;
using System;
using System.Linq;
using strange.extensions.command.impl;
using System.Collections.Generic;

public class ModuleContext : MVCSContext {

    public ModuleContext(ContextView view)
        : base(view) {

    }

    protected override void mapBindings() {
        base.mapBindings();

        IEnumerable<Type> types = GetTypesInNamespace(typeof(Command));

        foreach (Type type in types) {
            Debug.Log(type);
        }
    }

    private IEnumerable<Type> GetTypesInNamespace(Type type) {
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));
    }
}

