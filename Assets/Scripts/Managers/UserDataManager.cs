using System;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{

    #region Fields 
    private static UserDataManager _instance = null;

    /// <summary>
    /// Get the singleton instance of the UserDataManager.
    /// </summary>
    public static UserDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UserDataManager>();

                if (_instance == null)
                {
                    _instance = new GameObject("UserDataManager").AddComponent<UserDataManager>();
                }
            }
            return _instance;
        }
    }

    private UserData _userData;

    public UserData UserData
    {
        get { return _userData; }
        set { _userData = value; }
    }

    #endregion

    #region LifeCycle Methods

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _userData = FileManager.LoadUserData();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Debug.Log("Destroy user data manager");
            // If the instance doesn't exist, destroy the current instance
            Destroy(gameObject);
        }
    }


    #endregion

    #region Public Methods

    /// <summary>
    /// Save the user data using the FileManager.
    /// </summary>
    public void SaveUserData()
    {
        FileManager.SaveUserData(_userData);
    }


    #endregion
}


[Serializable]
public class UserData
{

    public int BestScore { set; get; } = 0;
   
}
