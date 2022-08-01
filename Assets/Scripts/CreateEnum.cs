using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateEnum
{
   [Serializable]
    public class EnumHandler
    {
        public string enumName;
        public List<string> names;

        public EnumHandler(string enumName, List<string> names)
        {
            this.enumName = enumName;
            this.names = names;
        }
    }

    private static void AddEnumInFile(StreamWriter streamWriter, string enumName, List<string> names)
    {
        streamWriter.WriteLine("public enum " + enumName);
        streamWriter.WriteLine("{");
        for (int i = 0; i < names.Count; i++)
        {
            streamWriter.WriteLine("\t" + names[i] + ",");
        }
        streamWriter.WriteLine("}");
    }

    public static void CreateEnumsFile(string filepath, params EnumHandler[] enums)
    {
        using (StreamWriter streamWriter = new StreamWriter(filepath))
        {
            foreach (var e in enums)
            {
                AddEnumInFile(streamWriter, e.enumName, e.names);
            }
        }
        AssetDatabase.Refresh();
    }

}
