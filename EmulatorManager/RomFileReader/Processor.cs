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
                Console.WriteLine("USAGE: RomFileReader.exe -File <path/to/file> -ChunkSize <Size to read in in bytes>");
                return false;
            }

            return true;
        }

        public void Run()
        {

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
