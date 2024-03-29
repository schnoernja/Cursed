using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    //to store Players spawn-location after scene transition
    public Vector2 initialValue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize() 
    {
        initialValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
