using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if((volume >= 0f) && (volume <= 1f))
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.Log("Master volume out of range");
        }
    }
    
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if(level <= SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        } else
        {
            Debug.LogError("TRying to unlock level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= 0 || level >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Index out of BuildIndex");
            return false;
        }
        else
        {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty >= 1 && difficulty <= 3)
        {
            PlayerPrefs.SetFloat(DIFICULTY_KEY, difficulty);
        } else
        {
            Debug.LogError("1>difficulty<3 ");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFICULTY_KEY);
    }
}
