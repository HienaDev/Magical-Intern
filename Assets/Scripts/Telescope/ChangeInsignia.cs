using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInsignia : MonoBehaviour
{

    private bool _shining;

    [SerializeField] private Material _blueBallDefault;
    [SerializeField] private Material _blueBallShining;

    [SerializeField] private GameObject _ball;
    private MeshRenderer _ballMesh;

    private AudioSource _shineSound;
    private float _defaultVolume;

    [SerializeField] private PutIngredientsOnCauldron _cauldron;

    // Start is called before the first frame update
    void Start()
    {
        _shining = false;

        _ballMesh = _ball.GetComponent<MeshRenderer>();

        _shineSound = GetComponent<AudioSource>();
        _defaultVolume = _shineSound.volume;
    }

    // Update is called once per frame
    void Update()
    {

        if (_shining && !_cauldron.GetSolved())
        {
            _shineSound.volume = _defaultVolume;
            _ballMesh.material = _blueBallShining;
        }
        else
        {
            _shineSound.volume = 0f;
            _ballMesh.material = _blueBallDefault;
        }


        _shining = false;
    }

    public void ActivateShine() => _shining = true;

    public Material GetMaterial() => _ballMesh.material;



}
