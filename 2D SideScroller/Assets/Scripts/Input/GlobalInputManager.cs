using System.Collections.Generic;
using UnityEngine;

public class GlobalInputManager : MonoBehaviour
{
    public enum InputAction { Jump, Run, Interact, InventoryWheel, Attack1, Attack2, Ability1, Ability2 }
    public enum InputButton { LeftBumper, RightBumper, RightTrigger, LeftTrigger, LeftThumbButton, BottomThumbButton, RightThumbButton, TopThumbButton }

    public Animator DialogueAnimator;
    public DialogueManager DialogueManager;
    public CalebPlayerController PlayerController;

    private float _lastJumpInput = 0;

    private float _bottomThumbButtonInput = 0;
    private float _topThumbButtonInput = 0;
    private float _leftThumbButtonInput = 0;
    private float _rightThumbButtonInput = 0;

    private Dictionary<InputAction, InputButton> Bindings = new Dictionary<InputAction, InputButton>();

    // Start is called before the first frame update
    void Start()
    {
        Bindings.Add(InputAction.Jump, InputButton.BottomThumbButton);
        Bindings.Add(InputAction.Interact, InputButton.LeftThumbButton);
        Bindings.Add(InputAction.InventoryWheel, InputButton.RightThumbButton);
        Bindings.Add(InputAction.Run, InputButton.TopThumbButton);
        Bindings.Add(InputAction.Ability1, InputButton.LeftBumper);
        Bindings.Add(InputAction.Attack1, InputButton.LeftTrigger);
        Bindings.Add(InputAction.Ability2, InputButton.RightBumper);
        Bindings.Add(InputAction.Attack2, InputButton.RightTrigger);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        _topThumbButtonInput = Input.GetAxis("TopThumbButton");
        _leftThumbButtonInput = Input.GetAxis("LeftThumbButton");
        _bottomThumbButtonInput = Input.GetAxis("BottomThumbButton");
        _rightThumbButtonInput = Input.GetAxis("RightThumbButton");

        var jumpInput = GetInput(InputAction.Jump);
        var interactInput = GetInput(InputAction.Interact);
        var inventoryInput = GetInput(InputAction.InventoryWheel);
        var runInput = GetInput(InputAction.Run);

        if (_leftThumbButtonInput != 0)
        {
            if(DialogueAnimator.GetBool("IsOpen"))
            {
                DialogueManager.DisplayNextSentence();
            }
            else
            {
                //PlayerController?.Interact();
            }
        }

        PlayerController.Running = runInput > 0;
        PlayerController.HorizontalMove(horizontalInput);

        if (jumpInput != 0 && _lastJumpInput == 0)
        {
            PlayerController.Jump(jumpInput);
        }

        _lastJumpInput = jumpInput;
    }

    private float GetInput(InputAction inputAction)
    {
        var button = Bindings[inputAction];

        switch(button)
        {
            case InputButton.BottomThumbButton: return _bottomThumbButtonInput;
            case InputButton.TopThumbButton: return _topThumbButtonInput;
            case InputButton.RightThumbButton: return _rightThumbButtonInput;
            case InputButton.LeftThumbButton: return _leftThumbButtonInput;
            default: return 0;
        }
    }
}
