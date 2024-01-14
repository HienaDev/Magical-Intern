using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{

    [SerializeField] private UnityEvent credits;

    public void PlayCredits() => credits.Invoke();
}
