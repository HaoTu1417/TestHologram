﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alta.Plugin;
using System.IO;
using System;

public class DataLoader : MonoBehaviour
{

    public static DataLoader Instance { private set; get; }


    public XMLLanguageData XmlLanguageData { private set; get; }
    private string filePath;

    private void Awake()
    {
        Instance = this;
        filePath = Path.Combine(Application.streamingAssetsPath, "Data.xml");
        ReadXML();
    }

    private void ReadXML()
    {
        if (File.Exists(filePath))
        {
            XmlLanguageData = XmlExtention.Read<XMLLanguageData>(filePath);
        }
        else
        {
            XmlLanguageData = new XMLLanguageData() { };
            WriteToXML();
        }
    }

    private void WriteToXML()
    {
        XmlExtention.Write(XmlLanguageData, filePath);
    }

    public List<Data> GetData(string key)
    {
        foreach(LanguageData data in XmlLanguageData.languageDatas)
        {
            if(data.key == key)
            {
                return data.datas;
            }
        }
        return new List<Data> { };
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GetData("AnRong").Count; i++)
        {
            Debug.Log(GetData("AnRong")[i].langCode);
            Debug.Log(GetData("AnRong")[i].content);
        }
        
    }


    //TODO: lấy data theo key và load data từ XML lên
}
[System.Serializable]
public class Data
{
    public string langCode;
    public string content;
}
[System.Serializable]
public class LanguageData
{
    public string key;
    public List<Data> datas;
}
[System.Serializable]
public class XMLLanguageData
{
    public List<LanguageData> languageDatas;


}