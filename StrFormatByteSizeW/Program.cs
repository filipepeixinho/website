using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StrFormatByteSizeW
{
    class Program
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern long StrFormatByteSize(
        long fileSize
        , [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer
        , int bufferSize);


        static void Main(string[] args)
        {
			
			//This programs receives an integer number from command line and passes it to StrFormatByteSize function
			//e.g. StrFormatByteSizeW.exe 1234566
			
            if (!long.TryParse(args[0], out long valor))
            {
                throw new ArgumentNullException("tamanho");
            }

            StringBuilder sb = new StringBuilder(12);
            StrFormatByteSize(valor, sb, sb.Capacity);

            Console.WriteLine(sb.ToString());

            Console.ReadLine();

        }
    }
}
