using Misc;
using UnityEngine;

[RequireComponent(typeof(CalebPlayerController))]
public class GlobalInputManager : MonoBehaviour
{
    public enum InputAction { Jump, Run, Interact, InventoryWheel, Attack1, Attack2, Ability1, Ability2, Left, Right, Crouch }
    public enum InputButton { LeftBumper, RightBumper, RightTrigger, LeftTrigger, LeftThumbButton, BottomThumbButton, RightThumbButton, TopThumbButton }

    public Animator DialogueAnimator;
    public DialogueManager DialogueManager;
    public CalebPlayerController PlayerController;

    private bool _jumpStillDown = false;
    private bool _inventoryStillDown = false;
    private bool _interactStillDown = false;

    private bool _bottomThumbButtonDown = false;
    private bool _topThumbButtonDown = false;
    private bool _leftThumbButtonDown = false;
    private bool _rightThumbButtonDown = false;

    void Start()
    {
        DataManager.Load();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _topThumbButtonDown = Input.GetButton("TopThumbButton");
        _leftThumbButtonDown = Input.GetButton("LeftThumbButton");
        _bottomThumbButtonDown = Input.GetButton("BottomThumbButton");
        _rightThumbButtonDown = Input.GetButton("RightThumbButton");

        var jump = GetButtonDown(InputAction.Jump);
        var interact = GetButtonDown(InputAction.Interact);
        var showInventory = GetButtonDown(InputAction.InventoryWheel);

        if (interact && !_interactStillDown)
        {
            if(DialogueAnimator.GetBool("IsOpen"))
            {
                DialogueManager.DisplayNextSentence();
            }
            else
            {
                PlayerController.Interact();
            }
        }

        if(showInventory && !_inventoryStillDown)
        {
            PlayerController.ShowWheel();
        }

        PlayerController.Running = GetButtonDown(InputAction.Run);

        if (jump && _jumpStillDown)
        {
            PlayerController.Jump();
        }

        PlayerController.HorizontalMove(horizontalInput);

        _inventoryStillDown = showInventory;
        _jumpStillDown = jump;
        _interactStillDown = interact;
    }

    private bool GetButtonDown(InputAction inputAction)
    {
        var key = Input.GetKey(DataManager.KeyboardBindings[inputAction]);

        if(key)
        {
            return true;
        }
        else if(inputAction == InputAction.Left || 
                inputAction == InputAction.Right ||
                inputAction == InputAction.Crouch)
        {
            return false;
        }

        var button = DataManager.ControllerBindings[inputAction];

        switch(button)
        {
            case InputButton.BottomThumbButton: return _bottomThumbButtonDown;
            case InputButton.TopThumbButton: return _topThumbButtonDown;
            case InputButton.RightThumbButton: return _rightThumbButtonDown;
            case InputButton.LeftThumbButton: return _leftThumbButtonDown;
            default: return false;
        }
    }
}
