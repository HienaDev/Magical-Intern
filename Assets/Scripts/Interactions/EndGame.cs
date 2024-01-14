using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{

    [SerializeField] private UnityEvent _credits;


    public void PlayCredits() => _credits.Invoke();
}
