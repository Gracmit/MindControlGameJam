using TMPro;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ControlsManager : MonoBehaviour
{
    [SerializeField] private ControlsData _controls;
    [SerializeField] private TMP_Text _updatedText;

    private string _text;

    public void ChangeControls()
    {
        _text = $"Changed Controls: {Environment.NewLine}";
            
            if (ChangeControl())
            {
                _controls.ChangeForward();
                UpdateUI("Forward", _controls.Forward);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeBackward();
                UpdateUI("Backward", _controls.Backwards);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeRight();
                UpdateUI("Right", _controls.Right);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeLeft();
                UpdateUI("Left", _controls.Left);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeJump();
                UpdateUI("Jump", _controls.Jump);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeDash();
                UpdateUI("Dash", _controls.Dash);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeShoot();
                UpdateUI("Shoot", _controls.Shoot);
            }
            
            if (ChangeControl())
            {
                _controls.ChangeMelee();
                UpdateUI("Melee", _controls.Melee);
            }
            
            _updatedText.SetText(_text);
    }

    private void UpdateUI(string action, KeyCode key)
    {
        _text += $"{action} = {key.ToString()} {Environment.NewLine}";
    }

    private bool ChangeControl()
    {
        var random = Random.Range(0, 3);
        return random == 1;
    }

    public void ResetControls()
    {
        _controls.ResetControls();
    }
}
