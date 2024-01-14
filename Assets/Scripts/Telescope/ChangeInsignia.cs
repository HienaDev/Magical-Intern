using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInsignia : MonoBehaviour
{

    private bool shining;

    [SerializeField] private Material blueBallDefault;
    [SerializeField] private Material blueBallShining;

    [SerializeField] private GameObject ball;
    private MeshRenderer ballMesh;

    private AudioSource _shineSound;
    private float _defaultVolume;

    [SerializeField] private PutIngredientsOnCauldron _cauldron;

    // Start is called before the first frame update
    void Start()
    {
        shining = false;

        ballMesh = ball.GetComponent<MeshRenderer>();

        _shineSound = GetComponent<AudioSource>();
        _defaultVolume = _shineSound.volume;
    }

    // Update is called once per frame
    void Update()
    {

        if (shining && !_cauldron.GetSolved())
        {
            _shineSound.volume = _defaultVolume;
            ballMesh.material = blueBallShining;
        }
        else
        {
            _shineSound.volume = 0f;
            ballMesh.material = blueBallDefault;
        }


        shining = false;
    }

    public void ActivateShine() => shining = true;

    public Material GetMaterial() => ballMesh.material;



}
