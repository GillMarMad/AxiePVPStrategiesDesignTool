using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class DataManager
{
    public string folderName;
    public string fileName;
    private string separator = ";";
    public string[] headers;

    public DataManager(string folderName, string fileName, string[] headers)
    {
        this.folderName = folderName;
        this.fileName = fileName;
        this.headers = headers;
        this.CreateReport();
    }
    public List<AxieCard> ReadFile()
    {
        List<AxieCard> AxieCards = new List<AxieCard>();
        int cont = 0 ;
        using(var reader = new StreamReader(GetFilePath()))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var cols = line.Split(';');
                if(cont == 0)
                {
                    // Debug.Log("Headers");
                    cont++;
                }
                else
                {
                    // Debug.Log(cols[0]+"-"+cols[1]+"-"+cols[2]+"-"+cols[3]+"-"+cols[4]+"-"+cols[5]+"-"+cols[6]+"-"+cols[7]+"-"+cols[8]+"-"+cols[9]);
                    AxieCard card = new AxieCard(cols[0], cols[1], cols[2], Int32.Parse(cols[3]), (attackType)Enum.Parse(typeof(attackType),cols[4]) , Int32.Parse(cols[5]), Int32.Parse(cols[6]), cols[7],(axieType)Enum.Parse(typeof(axieType),cols[8]), cols[9]);
                    AxieCards.Add(card);
                }
            }
        }
        // Debug.Log("File read");
        return AxieCards;
    }
    public void CreateReport()
    {
        VerifyFolder();
        if (VerifyFile())
            return;
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string FString = "";
            for (int i = 0; i < headers.Length; i++)
            {
                if (FString != "")
                {
                    FString += separator;
                }
                FString += headers[i];
            }
            // FString += separator + "Last Update";
            sw.WriteLine(FString);
        }
    }
    public void VerifyFolder()
    {
        string dir = GetFolderPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    public bool VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
        return true;
    }
    public string GetFilePath()
    {
        return GetFolderPath() + "/" + fileName;
    }
    public string GetFolderPath()
    {
        return Application.dataPath + "/" + folderName;
    }
}
