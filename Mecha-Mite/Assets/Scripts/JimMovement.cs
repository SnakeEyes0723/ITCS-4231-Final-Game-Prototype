using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimMovement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpPower = 6f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    bool isHovering;
    float maxFuelGauge = 5f;
    public double curFuelGauge;
    public float rotateSpeed = 1000f;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileVelocity = 10;
    double projectileTime;
    bool canShoot; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isHovering = false;
        curFuelGauge = 5f;
        projectileTime = 1f;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(curFuelGauge);


        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if(Input.GetButtonDown("Jump")){
            if(IsOnGround()){
                rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            }
            else{
                if ((curFuelGauge > 0) && isHovering == false){
                    rb.constraints = RigidbodyConstraints.FreezePositionY;
                    isHovering = true;
                }
                else {
                    rb.constraints = RigidbodyConstraints.None;
                    rb.constraints = RigidbodyConstraints.FreezeRotation;
                    isHovering = false;
                }
            }
        }

        if(Input.GetButtonDown("Fire") && projectileTime == 1f){
            var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = projectileSpawnPoint.forward * projectileVelocity;
            canShoot = false;
        }

        if(canShoot == false){
            projectileTime -= Time.deltaTime;
            if(projectileTime <= 0){
                canShoot = true;
                projectileTime = 1f;
            }
        }

        if(isHovering){
            curFuelGauge -= Time.deltaTime;
            if(curFuelGauge <= 0){
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                isHovering = false;
            }
        }

        if(IsOnGround() && (curFuelGauge < maxFuelGauge)){
            curFuelGauge += Time.deltaTime;
        }
        

    }

    bool IsOnGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
