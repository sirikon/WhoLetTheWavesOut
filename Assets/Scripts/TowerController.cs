using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private MagnetismOrigin magnetismOrigin;
    GameObject panelesEmpty;
    GameObject panelesFull;
    Light light;
    Animator animator;
    private Renderer renderer;

    public bool Selected; 
    public CustomInputButton ActivationButton;

    //Martin
    GameObject player1, player2;
    PlayerStats player1Stats, player2Stats;

    // Use this for initialization
    void Start () {
        magnetismOrigin = GetComponent<MagnetismOrigin>();
        renderer = GetComponent<Renderer>();
        panelesEmpty = transform.Find("Torre_paneles_empty").gameObject;
        panelesFull = transform.Find("Torre_paneles_full").gameObject;
        light = GetComponentInChildren<Light>();
        animator = GetComponent<Animator>();

        //Martin
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player1Stats = player1.GetComponent<PlayerStats>();
        player2Stats = player2.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        var player1Input = CustomInput.GetButton(ActivationButton, 1) && player1Stats.powerLevel > 0;
        var player2Input = CustomInput.GetButton(ActivationButton, 2) && player2Stats.powerLevel > 0;

        if (player1Input)
        {
            magnetismOrigin.State = MagnetismOriginState.Enabled;
            player1Stats.powerLevel -= 2 * Time.deltaTime;
        }

        if (player2Input)
        {
            magnetismOrigin.State = MagnetismOriginState.Enabled;
            player2Stats.powerLevel -= 2 * Time.deltaTime;
        }

        if (!player1Input && !player2Input)
        {
            magnetismOrigin.State = MagnetismOriginState.Disabled;
        }

        updateColor();
        //updateShader();
    }

    private void updateColor()
    {
        var isEnabled = magnetismOrigin.State == MagnetismOriginState.Enabled;
        panelesEmpty.SetActive(!isEnabled);
        panelesFull.SetActive(isEnabled);
        light.enabled = isEnabled;
        animator.SetBool("isEnabled", isEnabled);
    }

    //private void updateShader()
    //{
    //    renderer.material.SetFloat("Outline", Selected ? 0.083F : 0);
    //    renderer.material.SetColor("OutlineColor", magnetismOrigin.ImpulseMode == ImpulseMode.Attract ? Color.green : Color.red);
    //}
}
