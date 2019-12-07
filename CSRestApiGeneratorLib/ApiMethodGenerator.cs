﻿using CSAc4yClass.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSRestApiGeneratorLib
{
    public class ApiMethodGenerator
    {

        public static void generateApiMethods(string package, Ac4yClass anyType, string outputPath, string templatesFolder)
        {
            string className = anyType.Name;
            string[] text = readIn("Template", templatesFolder);

            List<Ac4yProperty> map = anyType.PropertyList;

            string replaced = "";
            string newLine = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("#getFirstBy#"))
                {/*
                    foreach (var pair in map)
                    {
                        newLine = text[i + 1].Replace("#Prop#", pair.Name.Substring(0, 1).ToUpper() + pair.Name.Substring(1))
                                                .Replace("#type#", pair.Type) + "\n" + text[i + 2] + "\n" + text[i + 3] + "\n\n";
                        newLine = newLine + text[i + 5].Replace("#className#", className)
                                                        .Replace("#Prop#", pair.Name.Substring(0, 1).ToUpper() + pair.Name.Substring(1)) + "\n";
                        newLine = newLine + "\n" + text[i + 6] + "\n" + text[i + 7] + "\n" + text[i + 8] + "\n" + text[i + 9]
                                            + "\n" + text[i + 10];
                        replaced = replaced + newLine + "\n\n";

                    }

                    i = i + 10;*/
                }
                else if (text[i].Equals("#getListBy#"))
                {/*
                    foreach (var pair in map)
                    {
                        newLine = text[i + 1].Replace("#Prop#", pair.Name.Substring(0, 1).ToUpper() + pair.Name.Substring(1))
                                                .Replace("#type#", pair.Type) + "\n" + text[i + 2] + "\n" + text[i + 3] + "\n";
                        newLine = newLine + text[i + 4].Replace("#className#", className)
                                                        .Replace("#Prop#", pair.Name.Substring(0, 1).ToUpper() + pair.Name.Substring(1)) + "\n";
                        newLine = newLine + "\n" + text[i + 6].Replace("#className#", className) + "\n" + text[i + 7] + "\n" + text[i + 8] + "\n" + text[i + 9]
                                            + "\n" + text[i + 10] + "\n" + text[i + 11] + "\n";
                        replaced = replaced + newLine + "\n\n";
                    }
                    i = i + 11;*/
                }
                else
                {
                    replaced = replaced + newLine + text[i] + "\n";
                }

                newLine = "";
            }
            replaced = replaced.Replace("#namespaceName#", package + "Api");
            replaced = replaced.Replace("#className#", className);

            writeOut(replaced, className, outputPath);

        }

        public static string[] readIn(string fileName, string templatesFolder)
        {

            string textFile = templatesFolder + "\\RestService\\" + fileName + "ApiEntityMethodsShort.csT";

            string[] text = File.ReadAllLines(textFile);

            return text;


        }

        public static void writeOut(string text, string fileName, string outputPath)
        {
            File.WriteAllText(outputPath + "\\RestService\\" + fileName + "RestService.cs", text);

        }
    }
}
