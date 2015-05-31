using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Field |AttributeTargets.Property, AllowMultiple = false)]

public class ModuleSignal : Attribute {
    private string name;

    public ModuleSignal(string name) {
        this.name = name;
    }

    public string Name {
        get {
            return name;
        }
    }
}
