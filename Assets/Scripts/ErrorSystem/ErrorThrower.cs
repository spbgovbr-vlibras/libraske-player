using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorThrower : MonoBehaviour
{
    [SerializeField] InGameError _errorToThrow;
    [SerializeField] bool _throwError;

    private void LateUpdate()
    {
        if (_throwError)
        {
            GameObject.FindObjectOfType<ErrorSystem>(true).ThrowError(_errorToThrow);
        }
    }

}
