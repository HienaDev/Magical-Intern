using UnityEngine;

public class DisableObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsThatStartDisabled;
    void Start()
    {
        foreach( GameObject g in _objectsThatStartDisabled)
        {
            g.SetActive(false);
        }
    }
}
