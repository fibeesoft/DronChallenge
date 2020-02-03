using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class FileManager : MonoBehaviour
{
    [SerializeField] Image img;
    string url = "http://fibeesoft.com/wp-content/uploads/2019/10/fsLogo240.png";
    IEnumerator Start(){  

        WWW www = new WWW(url);
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
        //www.LoadImageIntoTexture(img.mainTexture as Texture2D);
    } 

     
}

