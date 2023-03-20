using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;

    // Get keyboard inputs here
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        input = new Vector2(inputX, inputY).normalized;
        onInput?.Invoke(input);
    }
}
