using Lavid.Libraske.DataStruct;
using UnityEngine;

[CreateAssetMenu(fileName = "New Personalization Holder", menuName = "Libraske/Personalization/Personalization Holder")]
public class PersonalizationHolderSO : ScriptableObject
{
    [SerializeField] Wrapper<PersonalizationColor> _colors;
    [SerializeField] Wrapper<PersonalizationGroup> _groups;

    public void SetColors(Wrapper<PersonalizationColor> colors) => _colors = colors;
    public void SetGroups(Wrapper<PersonalizationGroup> groups) => _groups = groups;

    public Wrapper<PersonalizationColor> GetColors() => _colors;
    public Wrapper<PersonalizationGroup> GetGroups() => _groups;
}
