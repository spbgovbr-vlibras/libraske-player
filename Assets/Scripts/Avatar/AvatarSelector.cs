using UnityEngine;
using Lavid.Libraske.Avatar;

public class AvatarSelector : MonoBehaviour
{	
    [SerializeField] private AvatarVLibras _icaro;
	[SerializeField] private AvatarVLibras _hozana;
	
	public void ChooseIcaro()
    {
		_icaro.transform.gameObject.SetActive(true);
		_hozana.transform.gameObject.SetActive(false);
	}

	public void ChooseHozana()
	{
		_icaro.transform.gameObject.SetActive(false);
		_hozana.transform.gameObject.SetActive(true);
	}
}
