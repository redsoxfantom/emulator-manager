using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomFileReader
{
    public class Processor
    {
        private int mChunkSize;

        private FileStream mRomFile;

        private String mRomFileName;

        public Processor()
        {
            mChunkSize = -1;
            mRomFileName = null;
        }

        public bool Initialize(string[] args)
        {
            parseArguments(args);

            if(mChunkSize == -1 || mRomFileName == null)
            {
                Console.WriteLine("USAGE: RomFileReader.exe -File <path/to/file> -ChunkSize <Size to read in bytes>");
                return false;
            }

            try
            {
                mRomFile = File.OpenRead(mRomFileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Failed to open provided Rom File path");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }

            return true;
        }

        public void Run()
        {
            string input = "";
            List<byte> totalBytesRead = new List<byte>();

            while(input != "exit" || input != "e")
            {
                byte[] tmpArray = new byte[mChunkSize];
                int numBytesRead = mRomFile.Read(tmpArray, 0, mChunkSize);
                totalBytesRead.AddRange(tmpArray);

                input = printCommandsAndWaitForInput();
            }
        }

        private string printCommandsAndWaitForInput()
        {
            Console.WriteLine("Enter Command:");
            Console.WriteLine(" (e)xit: Terminate the program");
            Console.WriteLine(" (c)ontinue: Read in the next chunk");

            string input = "";
            while(String.IsNullOrEmpty(input))
            {
                input = Console.ReadLine();
            }
            return input;
        }

        private void parseArguments(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                if(args[i] == "-File")
                {
                    i++;
                    mRomFileName = args[i];
                }
                if(args[i] == "-ChunkSize")
                {
                    i++;
                    mChunkSize = int.Parse(args[i]);
                }
            }
        }
    }
}
