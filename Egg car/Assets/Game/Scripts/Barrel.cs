using UnityEngine;

public class Barrel : MonoBehaviour
{
    private bool hasFallen = false; // To ensure life is deducted only once

    private Rigidbody rb_Barrel;

    //private bool onTruck = true;

    private void Start()
    {
        rb_Barrel = gameObject.GetComponent<Rigidbody>();
    }

    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        rb_Barrel.constraints = RigidbodyConstraints.FreezeAll; // Freeze all movement & rotation
    //    }
    //    else
    //    {
    //        rb_Barrel.constraints = RigidbodyConstraints.None; // Remove all constraints
    //    }
    //}

    

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasFallen && collision.gameObject.CompareTag("Ground"))
        {
            hasFallen = true; // Prevent multiple life deductions
            GameManager.instance.ReduceLife();
        }
    }
}
