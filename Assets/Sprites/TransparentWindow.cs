using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class TransparentWindow : Node
{

  

    public override void _Ready()
    {
        GetWindow().Transparent = true;
        GetWindow().TransparentBg = true;
    }




}
