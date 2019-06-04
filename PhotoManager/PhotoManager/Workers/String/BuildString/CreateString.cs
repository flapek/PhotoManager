using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.Workers.String.BuildString
{
    class CreateString
    {
        #region String builder

        public static async Task<string> StringManyPhotoName(string[] fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string s = string.Empty;
            for (int i = 0; i < fileName.Length; i++)
            {
                s = fileName[i];
                if (i != fileName.Length - 1)
                {
                    stringBuilder.Append(s + ", ");
                }
                else
                {
                    stringBuilder.Append(s);
                }
            }

            return stringBuilder.ToString();
        }

        #endregion

    }
}
