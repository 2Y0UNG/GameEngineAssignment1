using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GemEditorEvents
{
    public abstract Color GemEditorColor();
}

public class YellowMat : GemEditorEvents
{
    public override Color GemEditorColor()
    {
        return Color.yellow;
    }
}

public class GreenMat : GemEditorEvents
{
    public override Color GemEditorColor()
    {
        return Color.green;
    }
}