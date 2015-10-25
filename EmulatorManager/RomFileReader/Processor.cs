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
                long startingPosition = mRomFile.Position;
                int numBytesRead = mRomFile.Read(tmpArray, 0, mChunkSize);
                long endingPosition = mRomFile.Position;
                totalBytesRead.AddRange(tmpArray);

                StringBuilder bldr = new StringBuilder(numBytesRead);
                foreach(byte readByte in tmpArray)
                {
                    char readChar = (char)readByte;
                    bldr.Append(readChar);
                }
                Console.WriteLine(String.Format("Read {0} bytes from rom file from {1} to {2}",numBytesRead,startingPosition,endingPosition));
                Console.WriteLine(String.Format("[{0}]", bldr.ToString()));

                input = printCommandsAndWaitForInput();
                processCommand(input);
            }
        }

        private void processCommand(string input)
        {
            switch(input)
            {
                case "f":
                    SaveToFile();
                    break;
                case "file":
                    SaveToFile();
                    break;
                default:
                    break;
            }
        }

        private void SaveToFile()
        {

        }

        private string printCommandsAndWaitForInput()
        {
            Console.WriteLine("Enter Command:");
            Console.WriteLine("(e)xit: Terminate the program");
            Console.WriteLine("(c)ontinue: Read in the next chunk");
            Console.WriteLine("(f)ile: Save the read-in Rom contents to file");

            string input = "";
            while(String.IsNullOrEmpty(input))
            {
                input = Console.ReadLine();
            }
            Console.WriteLine();
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
