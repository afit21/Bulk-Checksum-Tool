using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LargeHashClassTest
{
    class MultithreadingChecksumCommands
    {
        //Options: 0 = MD5, 1 = SHA256

        //Returns Checksums as strings for all files with their file paths in a dictionary
        public static Dictionary<int, string[]> DirectorysToChecksumStringArray(string[] dirs, int option)
        {
            var Hashdict = GetCheckSumforAll(dirs, option);
            object padlock = new object();

            Dictionary<int, string[]> returnDict = new Dictionary<int, string[]>(dirs.Length);
            Parallel.For(0, dirs.Length, i =>
            {
                var Hashstring = BitConverter.ToString(Hashdict[i]).Replace("-", "").ToLowerInvariant();
                lock (padlock)
                {
                    returnDict.Add(i, new string[2] { dirs[i], Hashstring });
                }
            });
            return returnDict;
        }

        //Returns A Dictionary of Byte Arrays that corrispond to the key of the file path provided
        public static Dictionary<int, Byte[]> GetCheckSumforAll(string[] filePaths, int option)
        {
            Dictionary<int, Byte[]> Checksumdict = new Dictionary<int, byte[]>();
            object padlock = new object();

            Parallel.For(0, filePaths.Count(), i =>
            {
                byte[] checksum = GetChecksumofFile(filePaths[i], option);
                lock (padlock) {
                    Checksumdict.Add(i, checksum);
                }
            });
            return Checksumdict;
        }

        //Returns a Checksum as a byte array based off of option provided
        public static byte[] GetChecksumofFile(string file, int option)
        {
            byte[] hash = new byte[0];
            using var stream = File.OpenRead(file);

            //MD5 Checksum
            if (option == 0)
            {
                using var md5 = MD5.Create();
                hash = md5.ComputeHash(stream);
            }
            //SHA256 Checksum
            else if (option == 1)
            {
                using var SHA256 = SHA256Managed.Create();
                hash = SHA256.ComputeHash(stream);
            }
            //SHA1
            else if (option == 2)
            {
                using var SHA1 = SHA1Managed.Create();
                hash = SHA1.ComputeHash(stream);
            }
            else if (option == 3)
            {
                using var SHA512 = SHA512Managed.Create();
                hash = SHA512.ComputeHash(stream);
            }
            return hash;
        }
    }
}
