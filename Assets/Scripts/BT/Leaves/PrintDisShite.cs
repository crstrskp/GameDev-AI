using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintDisShite : Leaf<Context>
{
    string message;
    public PrintDisShite(string message)
    {
        this.message = message;
    }

    public override Result Run(Context context) 
    {
        Debug.Log(message);
        return Result.SUCCESS;
    }
}