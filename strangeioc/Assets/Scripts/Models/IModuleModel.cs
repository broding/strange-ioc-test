using UnityEngine;
using System.Collections;

public interface IModuleModel {
    string Serialize();
    void Deserialize(string serializedData);
}