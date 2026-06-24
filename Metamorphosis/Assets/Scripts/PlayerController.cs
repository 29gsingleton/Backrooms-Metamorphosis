using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour


    //add camera, fix rots
{
    [Header("Controllers")]
    public int ControllerCount;
    public Gamepad Controller1 = Gamepad.current;

    [Header("Items")]
    public Item activeItem;


    float speed = 7.0f;
    float cameraspeed = 100.0f;

    Vector3 Startpos;
    Quaternion StartRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(activeItem);
        Vector3 Startpos = transform.position;
        Quaternion StartRot = transform.rotation;


    }


    void FixedUpdate()
    {     
        Vector2 ROTmovement = Controller1.rightStick.ReadValue();
        float ROTx = ROTmovement.x;
        float ROTy = ROTmovement.y;

        Vector3 rotationInput = new Vector3(ROTy, ROTx, 0) * cameraspeed;

        transform.Rotate(rotationInput * Time.deltaTime, Space.Self);

        // 3. Debug reset
        if (Controller1.buttonNorth.wasPressedThisFrame)
        {
            transform.position = Startpos;
            transform.rotation = StartRot;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Controller Check -> Move to Assigner
        if (Controller1 == null) { Controller1 = Gamepad.current; }
        if (Controller1 == null) { Debug.Log("Controller1 Lost Connection"); }
        ControllerCount = Gamepad.all.Count;

        if (activeItem != null) { if (Controller1.buttonEast.wasPressedThisFrame) { activeItem.Use(); } }
        if (activeItem != null) { if (Controller1.buttonSouth.wasPressedThisFrame) 
            { transform.Translate((Vector3.up) * 40 * Time.deltaTime); }
        }
       
        

        Vector2 FWDmovement = Controller1.leftStick.ReadValue();
         float FWDx = FWDmovement.x;
         float FWDy = FWDmovement.y;
        transform.Translate(new Vector3(FWDy, 0, -FWDx) * speed * Time.deltaTime);

        


      
    }
}  
