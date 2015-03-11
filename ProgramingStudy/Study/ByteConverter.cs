using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public class ByteConverter
    {
        public byte[] GetByteFromFile(string fileName)
        {
            var result = new List<byte>();

            using (var sr = new StreamReader(fileName))
            {
                int byteStream = 0;

                while ((byteStream = sr.BaseStream.ReadByte()) != -1)
                {
                    var intByteList = BitConverter.GetBytes(byteStream);

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(intByteList);
                    }

                    if (intByteList.All(b => b == 0))
                    {
                        result.Add(0);
                        continue;
                    }

                    var LeadingZero = true;

                    foreach (var byteValue in intByteList)
                    {
                        if (byteValue == 0 && LeadingZero)
                        {
                            LeadingZero = true;
                        }
                        else
                        {
                            result.Add(byteValue);
                            LeadingZero = false;
                        }
                    }
                }
            }
            
            return result.ToArray();
        }
   

    }
}
