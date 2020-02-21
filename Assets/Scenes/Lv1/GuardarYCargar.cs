using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarYCargar : MonoBehaviour
{
    const string PositionKey = "PlayerPosition";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            SavePosition();
        }
        if (Input.GetKeyDown(KeyCode.C)){
            LoadPosition();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            Reset();
        }
    }

    public void SavePosition()
    {
        PositionData d = new PositionData(transform.position, transform.rotation);
        PlayerPrefs.SetString(PositionKey, JsonUtility.ToJson(d));
    }

    public void LoadPosition()
    {
        PositionData d = JsonUtility.FromJson<PositionData>(PlayerPrefs.GetString(PositionKey));
        if(d != null){
            transform.position = d.Position;
            transform.rotation = d.Rotation;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [System.Serializable]
    public class PositionData
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public PositionData () { }
        public PositionData(Vector3 pos, Quaternion rot)
        {
            Position = pos;
            Rotation = rot;
        }
    }
}
