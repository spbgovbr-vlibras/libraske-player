using UnityEngine;
using Lavid.Libraske.Avatar;

public class AvatarSelector : MonoBehaviour
{
	[SerializeField] private AvatarVLibras[] _avatars;

	private AvatarNameEnum _currentTempAvatar; // Preview before save to file

	private void Awake()
	{ 
		_currentTempAvatar = AvatarVLibrasSelectionSaveHandler.GetAvatarSaved();
		ChooseAvatar(_currentTempAvatar);
	}

	public int GetCurrentTempAvatarIndex()
    {
		for(int i = 0; i < _avatars.Length; i++)
        {
			if (_avatars[i].AvatarName == _currentTempAvatar)
				return i;
        }

		return -1;
    }
	public AvatarNameEnum GetCurrentTempAvatar() => _currentTempAvatar;
	public int QuantityOfAvatars => _avatars.Length;

	public void ChooseAt(int index) => ChooseAvatar(_avatars[index].AvatarName);
	private void ChooseAvatar(AvatarNameEnum avatar)
    {
		for(int i = 0; i < _avatars.Length; i++)
        {
			bool shouldEnable = avatar == _avatars[i].AvatarName;
			_avatars[i].transform.gameObject.SetActive(shouldEnable);
        }

		_currentTempAvatar = avatar;
	}

	public void SaveSelectionChoice()
	{
		AvatarVLibrasSelectionSaveHandler.EnableSaving(true);
		AvatarVLibrasSelectionSaveHandler.SelectAvatar(_currentTempAvatar);
		AvatarVLibrasSelectionSaveHandler.SaveData();
	}
}