using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private Menus _menusScript;
    private Animator _animator;

    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("credits");
    }

    public void Finished()
    {
        _menusScript.CloseCredits();
        _menusScript.GoToMainMenu();
        _menusScript.EndOfFinalCredits();
    }
}
