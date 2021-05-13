using Lavid.Libraske.Color;
using System;

// Class that stores the personalization settings of the avatar
[Serializable]
public class AvatarProperties
{
    private CustomColor _cabelo;
    private CustomColor _calca;
    private CustomColor _camisa;
    private CustomColor _corpo;
    private CustomColor _iris;
    private CustomColor _olhos;
    private CustomColor _sombrancelhas;

    public AvatarProperties (
                        CustomColor cabelo, 
                        CustomColor calca,
                        CustomColor camisa,
                        CustomColor corpo,
                        CustomColor iris,
                        CustomColor olhos,
                        CustomColor sombrancelhas
    )
    {
        _cabelo = cabelo;
        _calca = calca;
        _camisa = camisa;
        _corpo = corpo;
        _iris = iris;
        _olhos = olhos;
        _sombrancelhas = sombrancelhas;
    }
}