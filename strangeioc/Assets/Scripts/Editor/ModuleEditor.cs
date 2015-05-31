using UnityEngine;
using System.Collections;
using UnityEditor;
using strange.extensions.context.impl;
using System.Collections.Generic;
using System;
using System.Linq;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using System.Reflection;

public class ModuleEditor : EditorWindow {

    [MenuItem("Window/Module Editor")]
    static void Init() {
        // Get existing open window or if none, make a new one:
        ModuleEditor window = (ModuleEditor)EditorWindow.GetWindow(typeof(ModuleEditor));
        window.Show();
    }

    private ModuleRoot moduleRoot;

    private int commandTypesIndex;
    private Type selectedCommand;

    private int signalIndex;
    private SignalField selectedSignalField;

    private void OnGUI() {
        if (Selection.activeTransform != null && Selection.activeTransform.GetComponent<ModuleRoot>() != null) {
            moduleRoot = Selection.activeTransform.GetComponent<ModuleRoot>();
            DrawSignalsList();
            DrawCommandList();
            DrawConnectButton();
        } else {
            GUILayout.Label("Please select a module");
        }
    }

    private void DrawConnectButton() {
        if (GUILayout.Button("Connect")) {
            ModuleRoot.CommandSignalConnection connection = new ModuleRoot.CommandSignalConnection();
            connection.CommandType = selectedCommand;
            connection.SignalField = selectedSignalField;

            Debug.Log(connection.SignalField.Field);

            moduleRoot.AddConnection(connection);
        }
    }

    private void DrawSignalsList() {

        IEnumerable<SignalsView> views = moduleRoot.GetComponentsInChildren<SignalsView>();
        List<SignalField> signals = views.SelectMany(s => GetSignal(s)).ToList();
        
        if (signals.Count <= 0) return;

        signalIndex = EditorGUILayout.Popup(signalIndex, signals.Select(s => s.Name).ToArray());
        selectedSignalField = signals[signalIndex];
    }

    private void DrawCommandList() {
        List<Type> commandTypes = GetTypesInNamespace(typeof(Command)).ToList();

        commandTypesIndex = EditorGUILayout.Popup(commandTypesIndex, commandTypes.Select(c => c.Name).ToArray());
        selectedCommand = commandTypes[commandTypesIndex];
    }

    private IEnumerable<Type> GetTypesInNamespace(Type type) {
        return AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));
    }

    private IEnumerable<SignalField> GetSignal(SignalsView view) {
        List<SignalField> signals = new List<SignalField>();

        foreach (FieldInfo field in view.GetType().GetFields()) {

            var attr = (ModuleSignal[])field.GetCustomAttributes(typeof(ModuleSignal), false);
            if (attr.Length > 0) {
                SignalField signalField = new SignalField();
                signalField.Name = view.name + "_" + attr[0].Name;
                signalField.Field = field;
                signalField.View = view;
                signals.Add(signalField);
            }
        }

        return signals;
    }
}
