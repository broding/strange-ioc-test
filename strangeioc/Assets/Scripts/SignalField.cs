using System;
using System.Reflection;

[Serializable]
public struct SignalField {
    public string Name;
    public FieldInfo Field;
    public SignalsView View;
}