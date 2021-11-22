using UnityEngine;

public class ForceTextCase : TextUIEffect
{
    enum CaseToApply { UpperCase, LowerCase }
    [SerializeField] CaseToApply _caseToApply;

    public override string HandleText(string valueToHandle)
    {
        return (_caseToApply) switch
        {
            CaseToApply.LowerCase => valueToHandle.ToLower(),
            CaseToApply.UpperCase => valueToHandle.ToUpper(),
            _ => valueToHandle
        };
    }
}
