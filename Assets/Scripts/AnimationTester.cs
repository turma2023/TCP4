using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) animator.SetTrigger("Close");
        if (Input.GetKeyDown(KeyCode.O)) animator.SetTrigger("Open");
    }

}
