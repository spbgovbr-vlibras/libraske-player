using UnityEngine;

public class GameObjectScaler : MonoBehaviour
{
    [SerializeField] GameObject _objectToScale;

    public void SetScale(float value) => _objectToScale.transform.localScale = new Vector3(value, value, value);
    public void SetXScale(float value) => _objectToScale.transform.localScale = new Vector3(value, _objectToScale.transform.localScale.y, _objectToScale.transform.localScale.z);
    public void SetYScale(float value) => _objectToScale.transform.localScale = new Vector3(_objectToScale.transform.localScale.x, value, _objectToScale.transform.localScale.z);
    public void SetZScale(float value) => _objectToScale.transform.localScale = new Vector3(_objectToScale.transform.localScale.x, _objectToScale.transform.localScale.y, value);
}