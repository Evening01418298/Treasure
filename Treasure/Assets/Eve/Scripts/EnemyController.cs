using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator emAnim;
    private int animNum;

    //アニメーション番号
    private static readonly Dictionary<int, int> animTriggers = new()
    {
        { 0, Animator.StringToHash("Idle") },
        { 1, Animator.StringToHash("Walk") },
        { 2, Animator.StringToHash("Run")},
        { 3, Animator.StringToHash("Attack") },
        { 4, Animator.StringToHash("Hit")},
        { 5, Animator.StringToHash("Die")},
    };
    // Start is called before the first frame update
    void Start()
    {
        SetAnim(0);
        StartCoroutine(SwitchAnimationLoop());
    }

    private IEnumerator SwitchAnimationLoop()
    {
        yield return new WaitForSeconds(5f);
    }

    public void SetAnim(int newAnimNum)
    {
        if(animNum == newAnimNum)
        {
            return;
        }
        animNum = Random.Range(0, 6);
        emAnim.SetTrigger(animTriggers[animNum]);
    }

}
