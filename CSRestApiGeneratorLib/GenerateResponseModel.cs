using System;
using System.IO;

namespace CSRestApiGeneratorLib
{
    public class GenerateResponseModel
    {
        public static void generateResponseModel(string className, string outputPath, string templatesFolder)
        {
            string[] text = readIn("TemplateObjectResponseModel", templatesFolder);

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#namespaceName#", className);

            writeOut(replaced, className + "ResponseModel", outputPath);
        }

        public static string[] readIn(string fileName, string templatesFolder)
        {

            string textFile = templatesFolder + fileName + ".csT";

            string[] text = File.ReadAllLines(textFile);

            return text;
        }

        public static void writeOut(string text, string fileName, string outputPath)
        {
            File.WriteAllText(outputPath + fileName + ".cs", text);


        }
    }
}
