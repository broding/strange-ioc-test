using UnityEngine;
using System.Collections;
using System.ComponentModel;

public class KolomboorModel : IModuleModel {
    public bool On;
    public float Speed;

    public string Serialize() {
        return "hallo";
    }

    public void Deserialize(string serializedData) {

    }
}
