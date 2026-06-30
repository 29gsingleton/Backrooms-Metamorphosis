using UnityEngine;

public class Bat : Weapon, ICanDamage
{
   public float damage { get;} = 4f;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
 void Start()
 {
        

 }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public override void Use() { }  

}
