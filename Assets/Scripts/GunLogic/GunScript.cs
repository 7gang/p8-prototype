using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

[Serializable]
public class GunGrabEvent : UnityEvent<Scenario> { }

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(AudioSource))]
public class GunScript : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform bulletSource = null;
    [SerializeField]
    private float projectileSpeed = 5.0f;
    [SerializeField]
    private Animator anim;
    private bool grabbed = false;
    private SteamVR_Input_Sources isource;
    private Simulation simulation;
    private ReloadScript reload;

    public int gunType = 1;
    public SteamVR_Action_Boolean input;
    public SteamVR_Action_Boolean input2;
    public bool grabbable = false;

    public AudioClip reloadSound;
    public AudioClip shootSound;
    
    public GunGrabEvent OnGrab = new GunGrabEvent();

    protected void Start()
    {
        simulation = GameObject.FindGameObjectWithTag("Simulator").GetComponent<Simulation>();
        reload = gameObject.GetComponentInChildren<ReloadScript>();
    }

    private void Update()
    {
        Hand localHand = gameObject.GetComponent<Interactable>().hoveringHand;
        if (localHand == null) return;

        if (!grabbed) 
            isource = gameObject.GetComponent<Interactable>().hoveringHand.handType;

        if(input.GetStateDown(isource) && !grabbed)
        {
            attachToHand();
            this.OnGrab.Invoke(new Scenario());
            Logger.Log(Classifier.Gun.GunPickup, this.transform);
        }
        else
        {
            if (input2.GetStateDown(isource) && grabbed && reload.isLoaded)
            {
                shoot();
            }
            else return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

    }
    void shoot()
    {
        //this.simulation.OnShot.Invoke(new Scenario());
        //Logger.Log(Classifier.Gun.GunShot, this.transform);
        reload.isLoaded = false;
        //Debug.Log("Shoot!");
        
        //var projectile = Instantiate(projectilePrefab, bulletSource.position, bulletSource.rotation);
        var projectile = this.simulation.SpawnCell(CellType.Antibody, bulletSource.position, bulletSource.rotation);
        projectile.GetComponentInChildren<Rigidbody>().AddRelativeForce(Vector3.forward * projectileSpeed, ForceMode.Impulse);

        this.simulation.OnShot.Invoke(new Scenario());  // TODO: replace placeholder Scenario
        Logger.Log(Classifier.Gun.GunShot, this.transform);
        
        this.GetComponent<AudioSource>().PlayOneShot(this.shootSound);
        anim.SetTrigger("Shoot");
    }

    void attachToHand()
    {
        gameObject.transform.parent = GetComponent<Interactable>().hoveringHand.transform;
        gameObject.transform.localPosition = new Vector3(0f, -0.35f, -0.08f);  // 0f, -0.15f, 0.15f
        gameObject.transform.localRotation = Quaternion.Euler(0f, -90f, -40f);
        grabbed = true;
        
        this.simulation.OnPickup.Invoke(new Scenario());
        Logger.Log(Classifier.Gun.GunReload, this.transform);
    }
}