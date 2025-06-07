using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private int _number = 0;
    private bool _isSuspended = true;
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    public event Action<int> Changed;

    public int StartedNumber => _number;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Switch();
        }
    }

    private void Switch()
    {
        _isSuspended = !_isSuspended;

        if (_isSuspended == false)
        {
            _coroutine = StartCoroutine(ChangeNumber());
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private IEnumerator ChangeNumber()
    {
        while (_isSuspended == false)
        {
            yield return _wait; 
            _number++;
            Changed?.Invoke(_number);
        }
    }
}