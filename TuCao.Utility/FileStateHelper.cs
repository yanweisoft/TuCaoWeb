using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuCao.Utility
{
    public class FileStateHelper
    {
        public static FileStateEnum GetFileStateEnum(string filePath) 
        {
            if (!System.IO.File.Exists(filePath)) // The path might also be invalid.
            {
                return FileStateEnum.NotExist;
            }

            try
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
                {
                    return FileStateEnum.ExistAndNotUse;
                }
            }
            catch
            {
                return FileStateEnum.ExistAndUse;
            }
        }
    }
    public enum FileStateEnum
    {
        NotExist = 0,
        ExistAndUse = 1,
        ExistAndNotUse = 2
    }
}
