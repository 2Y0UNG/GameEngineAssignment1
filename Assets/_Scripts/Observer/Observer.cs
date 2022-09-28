using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer
{
    public abstract void OnNotify();
}

public class Gem : Observer
{
    GameObject gemObject;
    GemEditorEvents gemEvent;

    public Gem(GameObject gemObject, GemEditorEvents gemEvent)
    {
        this.gemObject = gemObject;
        this.gemEvent = gemEvent;
    }

    public override void OnNotify()
    {
        gemColor(gemEvent.GemEditorColor());
    }

    void gemColor(Color mat)
    {
        gemObject.GetComponent<Renderer>().materials[0].color = mat;
    }
} 
