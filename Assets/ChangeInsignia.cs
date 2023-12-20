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

    // Start is called before the first frame update
    void Start()
    {
        shining = false;

        ballMesh = ball.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (shining)
        {
            ballMesh.material = blueBallShining;
        }
        else
        {
            ballMesh.material = blueBallDefault;
        }


        shining = false;
    }

    public void ActivateShine() => shining = true;

}
