using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
   

    //add camera, fix rots
  [Header("Statistics")]
    public float PlayerHealth = 10;

    [Header("Controllers")]
    public int ControllerCount;
    public Gamepad Controller { get; set; }

    [Header("Items")]
    public Item activeItem;


    float speed = 7.0f;
    float cameraspeed = 100.0f;

    Vector3 Startpos;
    Quaternion StartRot;

    public Transform hand;
    bool dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(activeItem);
        Vector3 Startpos = transform.position;
        Quaternion StartRot = transform.rotation;
        OnItemEquiped();

    }


   
    // Update is called once per frame
    void Update()
    {
        //Controller Check -> Move to Assigner
        if (Controller == null) { Controller = Gamepad.current; }
        if (Controller == null) { Debug.Log("Controller Lost Connection"); }
        ControllerCount = Gamepad.all.Count;

        if (activeItem != null) { if (Controller.buttonEast.wasPressedThisFrame) { activeItem.Use(); } }
        if (activeItem != null) { if (Controller.buttonSouth.wasPressedThisFrame) 
            { transform.Translate((Vector3.up) * 40 * Time.deltaTime); }
        }
       
        

        Vector2 FWDmovement = Controller.leftStick.ReadValue();
         float FWDx = FWDmovement.x;
         float FWDy = FWDmovement.y;
        transform.Translate(new Vector3(FWDy, 0, -FWDx) * speed * Time.deltaTime);

       
        Vector2 ROTmovement = Controller.rightStick.ReadValue();
        float ROTx = ROTmovement.x * cameraspeed;
        float ROTy = ROTmovement.y * cameraspeed;

    
        Vector3 rotationInput = new Vector3(-ROTy, ROTx, 0);
        transform.Rotate(rotationInput * Time.deltaTime, Space.Self);

        // 3. Debug reset
        if (Controller.buttonNorth.wasPressedThisFrame)
        {
            if (dead == false)
            {
                transform.position = Startpos;
                transform.rotation = StartRot;
            }
            else
             Instantiate(gameObject, Startpos, StartRot); dead = true;
        }




    }
   
    void OnItemEquiped() 
        {if(activeItem != null) Instantiate(activeItem, hand.transform.position, hand.transform.rotation, hand); }

   void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Weapon"))
        {
            if (other.TryGetComponent<ICanDamage>(out var CanDamage)) 
            {
                DamageInflicted(CanDamage.damage);
            }
            else { Debug.Log("Weapon missing damage/ICanDamage"); }
        }
            
   }

    void DamageInflicted(float damage)
    { 
        PlayerHealth -= damage;
        Debug.Log("Damage taken:" + damage);
        if (PlayerHealth <= 0) { KillPlayer(); Debug.Log("Killed Payer"); } 
    }

    void KillPlayer() { }
}  
