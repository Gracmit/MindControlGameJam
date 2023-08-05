using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Keys")]
public class ControlsData : ScriptableObject
{
    public KeyCode Jump;
    public KeyCode Dash;
    public KeyCode Forward;
    public KeyCode Backwards;
    public KeyCode Right;
    public KeyCode Left;
    public KeyCode Shoot;
    public KeyCode Melee;

    public List<KeyCode> AvailableKeys;

    public void ChangeJump()
    {
        var temporary = Jump;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Jump = newKey;
    }
    
    public void ChangeDash()
    {
        var temporary = Dash;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Dash = newKey;
    }    
    
    public void ChangeForward()
    {
        var temporary = Forward;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Forward = newKey;
    }
    public void ChangeBackward()
    {
        var temporary = Backwards;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Backwards = newKey;
    }
    public void ChangeRight()
    {
        var temporary = Right;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Right = newKey;
    }
    public void ChangeLeft()
    {
        var temporary = Left;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Left = newKey;
    }

    public void ChangeShoot()
    {
        var temporary = Shoot;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Shoot = newKey;
    }
    
    public void ChangeMelee()
    {
        var temporary = Melee;
        var newKey = AvailableKeys[Random.Range(0, AvailableKeys.Count)];
        AvailableKeys.Remove(newKey);
        AvailableKeys.Add(temporary);
        Melee = newKey;
    }

    [ContextMenu("Reset Controls")]
    public void ResetControls()
    {
        Forward = KeyCode.W;
        Backwards = KeyCode.S;
        Right = KeyCode.D;
        Left = KeyCode.A;
        Jump = KeyCode.Space;
        Dash = KeyCode.LeftShift;
        Shoot = KeyCode.E;
        Melee = KeyCode.Q;

        AvailableKeys = new List<KeyCode>
        {
            KeyCode.Z,
            KeyCode.X,
            KeyCode.C,
            KeyCode.R,
            KeyCode.F,
            KeyCode.V,
            KeyCode.B,
            KeyCode.Tab,
            KeyCode.G
        };
    } 
}
