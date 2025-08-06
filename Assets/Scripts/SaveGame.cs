using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SaveGame : MonoBehaviour
{
    
    private float pontos;

    // Método para salvar o estado do jogo
    public void SalvarJogo(string fase, float pontos)
    {
        PlayerPrefs.SetInt(fase, 1);
        PlayerPrefs.SetFloat("Pontos", pontos);
        PlayerPrefs.Save();
    }
     
    public void SalvarCheckpoint(string fase, float pontos , Vector3 local)
    {
        PlayerPrefs.SetInt( "Check" + fase, 1);
        PlayerPrefs.SetFloat("Pontos", pontos);
        PlayerPrefs.SetFloat("CkeckPosX" + fase, local.x);
        PlayerPrefs.SetFloat("CkeckPosY" + fase, local.y);
        PlayerPrefs.SetFloat("CkeckPosZ" + fase, local.z);
        PlayerPrefs.Save();
    }

    public bool VerificarSaveChackPoint(string nomeFase)
        
    {
        bool temSave = PlayerPrefs.HasKey("Check" + nomeFase);
        return temSave;
    }

    // Método para carregar o estado do jogo
    public void CarregarJogo()
    {
        
        pontos = PlayerPrefs.GetFloat("Pontos");
    }

    //Verifica se tem save
    public bool VerificarSaveGame(string nomeFase)
    {
        bool temSave = PlayerPrefs.HasKey(nomeFase) && 
                            PlayerPrefs.HasKey("Pontos");
        return temSave;
    }

    // Métodos para obter os valores carregados
    
    public float GetPontos()
    {
        return pontos;
    }

    public void ResetarSave()
    {
        PlayerPrefs.DeleteAll();
        pontos = 0f;
        Debug.Log("Todos os saves foram resetados.");
    }
}
