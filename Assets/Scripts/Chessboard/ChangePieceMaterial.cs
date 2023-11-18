using UnityEngine;

public class ChangePieceMaterial : MonoBehaviour
{
    [SerializeField] private Material _material;

    public void ChangeMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = _material;
    }
}
