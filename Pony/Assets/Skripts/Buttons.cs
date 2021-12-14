using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Image Image;


    public void playNext()
    {
        //Application.LoadScene();
        Debug.Log("Play Next");
    }
    public void Exit()
    {
       // Application.Quit();
        Debug.Log("EXIT");
    }

    public void Save()
    {

        byte[] bytes = Image.sprite.texture.EncodeToPNG();
        string filename = Image.sprite.name;

        string fileLocation = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllBytes(fileLocation, bytes);

        string myFolderLocation = Directory.GetCurrentDirectory()+"\\img";
        string myScreenshotLocation = myFolderLocation + filename+ ".png";

        System.IO.File.Move(fileLocation, myScreenshotLocation);

        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classMedia = new AndroidJavaClass("android.media.MediaScannerConnection");
        classMedia.CallStatic("scanFile", new object[4] { objActivity,
        new string[] { myScreenshotLocation },
        new string[] { "image/png" },
        null  });
    }


    public void Shere(string url)
    {
        Application.OpenURL(url);

    }

}
