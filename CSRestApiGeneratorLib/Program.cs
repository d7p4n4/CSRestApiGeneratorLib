using CSAc4yClass.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSRestApiGeneratorLib
{
    public class Program
    {

        #region constant


        #endregion // constants

        #region base functions


        #endregion // base functions

        public static void MainMethod(string _inpath, string _outpath, string _defaultNamespace, string templatesFolder)
        {

            //Date: 2019. 11. 09. 18:30

            if (!Directory.Exists(_outpath + "RestService"))
                Directory.CreateDirectory(_outpath + "RestService");



            string[] files =
                 Directory.GetFiles(_inpath, "*.xml", SearchOption.TopDirectoryOnly);

            List<Ac4yClass> list = new List<Ac4yClass>();

            foreach (var _file in files)
            {
                string _filename = Path.GetFileNameWithoutExtension(_file);
                Console.WriteLine(_filename);
                if (_filename.EndsWith("Persistent"))
                {
                    ApiMethodGenerator.generateApiMethods(_defaultNamespace, DeserialiseMethod.deser(_file), _outpath, templatesFolder);
                }
            }

        }
    }
}