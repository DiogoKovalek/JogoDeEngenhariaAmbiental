using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ManagerInputs
{
    public static InputPlayer inputPlayer = new InputPlayer();

    public static void ActiveALLInput() {
        inputPlayer.Enable();
    }

    public static void DesactiveALLInput() {
        inputPlayer.Disable();
    }
}
