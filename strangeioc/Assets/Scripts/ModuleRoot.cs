using strange.extensions.context.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

[Serializable]
public class ModuleRoot : ContextView {

    [SerializeField]
    private List<CommandSignalConnection> connections = new List<CommandSignalConnection>();

    public ICollection<CommandSignalConnection> Connections {
        get {
            return connections;
        }
    }

    public void AddConnection(CommandSignalConnection connection) {
        connections.Add(connection);
    }

    [Serializable]
    public struct CommandSignalConnection {
        public SignalField SignalField;
        public Type CommandType;
    }
}
