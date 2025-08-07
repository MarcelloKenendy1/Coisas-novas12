using System;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private SaveGame saveGame;
    [SerializeField] private GameObject continuaButton;
    [SerializeField] private Vector3 localCheckPoint;
    private SistemaDeAudio sAudio;
    [Header("Som do Button")]
    [SerializeField] private AudioClip Som;
    private void Awake()
    {
        if(SceneManager.GetActiveScene().name == "MenuPrincipal")
        {
         if (saveGame.VerificarSaveGame("Fase1") && continuaButton != null || saveGame.VerificarSaveChackPoint("Fase1") && continuaButton != null)
                continuaButton.GetComponent<Button>().interactable = true;
          

        
        }
       
        sAudio = FindAnyObjectByType<SistemaDeAudio>();
    }
    public void MudarFase(string nome)
        
    {    
        TocarBotao();
        if(sAudio != null)
        {
            sAudio.PlaySoundEffects(Som);
        }

        SceneManager.LoadScene(nome);
    }

    public void SalvarFase()
    {
        TocarBotao();
        if (saveGame != null)
        {
            saveGame.SalvarJogo(SceneManager.GetActiveScene().name, 0f);
            Debug.Log("Fase salva com sucesso.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void SalvarCheckpoint()
    {
        TocarBotao();
        if (saveGame != null)
        {
            saveGame.SalvarCheckpoint(SceneManager.GetActiveScene().name, 100, localCheckPoint);
            Debug.Log("Fase salva com sucesso, no checkpoint.");
        }
        else
        {
            Debug.LogError("SaveGame não está atribuído.");
        }
    }

    public void NovoJogo()
    {
        TocarBotao();
        if (saveGame != null)
        {
            saveGame.ResetarSave();
        }
    }


    private void TocarBotao()
    {
        if(sAudio != null)
        {
            sAudio.PlaySoundEffects(Som);
        }

    }

}
