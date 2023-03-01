using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private GameObject _turret;
    private GameObject _gun;
    // Start is called before the first frame update
    void Start()
    {
        _turret = gameObject;
        _gun = _turret.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        RotateGunBarrel();
        MoveTheTurretByGunBarrelDirection();
    }
    
    void RotateGunBarrel()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        // Rotate gun barrel by pressing keyboard A, D
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = 200 * Time.deltaTime;

            // Rotate to the left (Press D)
            if (rotationInput > 0)
            {
                rotationAmount *= -1;
            }

            // Rotate gun barrel around the sentry (1st param is pivot to rotate around )
            _gun.transform.RotateAround(_turret.transform.position, Vector3.forward, rotationAmount);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform gunBarrelTransform = _gun.transform;
            Instantiate(bulletPrefab, gunBarrelTransform.position, gunBarrelTransform.rotation);
            // AudioManager.Play(AudioClipName.BurgerShot);
        }
    }


    void MoveTheTurretByGunBarrelDirection()
    {
        float moveForwardInput = Input.GetAxis("Vertical");

        if (moveForwardInput > 0)
        {
            Vector3 currentTurretPosition = _turret.transform.position;
            Vector3 currentGunBarrelPosition = _gun.transform.position;
            Vector3 newGunBarrelDirection =
                Vector3.MoveTowards(currentTurretPosition, currentGunBarrelPosition, 6f * Time.deltaTime);


            // bool horizontalWithinScreen = newGunBarrelDirection.x >= ScreenUtils.ScreenLeft &&
            //                               newGunBarrelDirection.x <= ScreenUtils.ScreenRight;
            //
            // bool verticallWithinScreen = newGunBarrelDirection.y >= ScreenUtils.ScreenBottom &&
            //                              newGunBarrelDirection.y <= ScreenUtils.ScreenTop;

            // if (horizontalWithinScreen && verticallWithinScreen)
            // {
            //     _turret.transform.position = newGunBarrelDirection;
            // }
        }
    }
    
}
