using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Configuration;

namespace ConsoleApp1
{
    public class PodConverter
    {
        /*
         * TODO: 
         *  >Check for existing filenames (temp & final); deal w/ if found
         *  >For that matter, check that the source file exists!
         *  >Verify that file is actually an MP3
         */


        string tempDirectory;
        string targetDirectory;

        public PodConverter(string tempDirectory = @"C:\Medias\temp\", string targetDirectory = @"C:\Medias\target\")
        {
            AppSettingsReader ar = new AppSettingsReader();
            
            this.tempDirectory = tempDirectory;
            this.targetDirectory = targetDirectory;
        }

        public void TheWholeDamnThing(string sourceFile, string targetFileName, TimeSpan begin, TimeSpan end)
        {
            string tempPath = GetTempPath(sourceFile);
            SplitFile(sourceFile, tempPath, begin, end);
            ConvertToWav(tempPath, Path.Combine(targetDirectory, targetFileName));
        }

        /// <summary>
        /// Copy the given Mp3 file to the working directory, and trim the copy to the specified times
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        public void SplitFile(string sourceFile, string targetFile, TimeSpan begin, TimeSpan end)
        {
            using (var reader = new Mp3FileReader(sourceFile))
            using (var writer = File.Create(targetFile))
            {
                Mp3Frame frame;
                while((frame= reader.ReadNextFrame()) != null)
                {
                    if (reader.CurrentTime >= begin )
                    {
                        if (reader.CurrentTime <= end)
                        {
                            writer.Write(frame.RawData, 0, frame.RawData.Length);
                            //TODO: Can we search for the next /silent/ bit?
                        }
                        else break;
                    }
                }
            }
        }

        /// <summary>
        /// Create a .wav copy of the given MP3 file
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        public void ConvertToWav(string sourceFile, string targetFile)
        {
            using (var reader = new Mp3FileReader(sourceFile))
            {
                WaveFileWriter.CreateWaveFile(targetFile, reader);
            }
        }

        private string GetTempPath(string sourceFile)
        {
            string filename = Path.GetFileName(sourceFile);
            return Path.Combine(tempDirectory,filename);
        }
    }
}
