using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface HasController
{
    Gamepad controller { get; set; }
}
