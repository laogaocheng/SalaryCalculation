using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using YiKang;

namespace Hwagain
{
    public class FileCode
    {
        public static string ByteArrayToString(byte[] arrInput, EncodeStyle encode)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            if (EncodeStyle.Base64 == encode)
            {
                return Convert.ToBase64String(arrInput);
            }
            for (i = 0; i < arrInput.Length; i++)
            {
                switch (encode)
                {
                    case EncodeStyle.Dig:
                        //encode to decimal with 3 digits so 7 will be 007 (as range of 8 bit is 127 to -128)
                        sOutput.Append(arrInput[i].ToString("D3"));
                        break;
                    case EncodeStyle.Hex:
                        sOutput.Append(arrInput[i].ToString("X2"));
                        break;
                }
            }
            return sOutput.ToString();
        }

        public static string SHA1HashEncode(string filePath, EncodeStyle encode)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                int tryTimes = 20; //允许尝试次数
                do
                {
                    try
                    {
                        FileStream fs = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        byte[] buffer = new byte[fs.Length];
                        fs.Seek(0, SeekOrigin.Begin);
                        fs.Read(buffer, 0, (int)fs.Length);
                        fs.Close();

                        string sha1 = FileCode.SHA1HashEncode(buffer, EncodeStyle.Hex);

                        tryTimes = 0;

                        return sha1;
                    }
                    catch (IOException)
                    {
                        tryTimes--;
                        Thread.Sleep(100);
                    }
                } while (tryTimes > 0);
            }
            return null;
        }
        static string SHA1HashEncode(StreamReader sr, EncodeStyle encode)
        {
            SHA1 a = new SHA1CryptoServiceProvider();
            byte[] arr = new byte[60];
            arr = a.ComputeHash(sr.BaseStream);
            return ByteArrayToString(arr, encode);
        }

        public static string SHA1HashEncode(byte[] data, EncodeStyle encode)
        {
            byte[] arr = new byte[60];
            string hash = "";
            MemoryStream ms = new MemoryStream(data);
            using (StreamReader sr = new StreamReader(ms))
            {
                hash = SHA1HashEncode(sr, encode);
            }
            return hash;
        }
    }
}
