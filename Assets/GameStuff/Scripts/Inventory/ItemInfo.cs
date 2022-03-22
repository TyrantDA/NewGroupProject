using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemInfo : ScriptableObject
{
    // this is a scriptable object use the ScriptableObject instead of MonoBehaviour
    public string title, description;
    public Sprite icon;
}
