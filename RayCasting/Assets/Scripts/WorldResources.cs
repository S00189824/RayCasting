using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using UnityEngine;


[Serializable]

public class WorldResources
{

    public ResourceType Resource;
    public Color resourceColorPixel;

    
}

[Serializable]
public enum ResourceType
{
    Soil,
    Water,
    Coal,
    Gold
}
