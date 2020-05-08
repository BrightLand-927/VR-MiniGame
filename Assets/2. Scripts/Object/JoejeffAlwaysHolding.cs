using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoejeffAlwaysHolding : MonoBehaviour
{
    public Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hold()
    {
        _animator.SetBool("Holding", true);
    }

    public void Release()
    {
        _animator.SetBool("Holding", false);
    }
}
