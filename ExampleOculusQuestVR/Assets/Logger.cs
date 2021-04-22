using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Runtime.CompilerServices;
using System;
using System.IO;
using Newtonsoft.Json;
public class Logger : MonoBehaviour
{
    static Logger logger;
    public Text debugText;
    static string log_prefix = ""+DateTime.Now.Ticks;
    // Start is called before the first frame update
    void Awake(){
        logger = this;
        
    }
    public static void log(string text){
        logger.debugText.text = text + "\n" + logger.debugText.text;
        if(logger.debugText.text.Length > 5000){
            logger.debugText.text = logger.debugText.text.Substring(0,2500);
        }
        Debug.Log(text);
    }
   
    private static void logEvent(string eventType, string message)
    {
        
        string logpath = Application.persistentDataPath + "/" + eventType + log_prefix + ".csv";
        StreamWriter stream = File.AppendText(logpath);
        stream.WriteLine(message);
        stream.Flush();
        stream.Close();
    }

    public static void logHeadPosition(float x, float y, float z)
    {

        HeadLogData data = new HeadLogData();
        data.headPos = new Vector3(x, y, z);
        log(JsonConvert.SerializeObject(data));
        logEvent("HeadPos", x + "," + y + "," + z);
        
    }
    
    
}

public class HeadLogData
{
    public Vector3 headPos;
}
