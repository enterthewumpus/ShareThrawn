using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using NUnit.Framework;

namespace ShareThrawn.Tests
{
    [TestFixture]
    public class SplitTest
    {

        const string tempDirectory = @"C:\Medias\temp\";
        const string targetDirectory = @"C:\Medias\target\";
        //const string sourceFile = @"C:\Medias\source\FattWiH22.mp3";
        //const string targetFile = @"C:\Medias\target\TestShouts.mp3";
        //TimeSpan startTime = new TimeSpan(1, 24, 50);
        //TimeSpan endTime = new TimeSpan(1, 25, 20);

        const string testFileTemp = @"C:\Medias\temp\TestShouts.mp3";
        const string targetFileTemp = @"C:\Medias\target\TestShouts.mp3";

        [SetUp]
        public void SetUp()
        {
            File.Delete(testFileTemp);
            File.Delete(targetFileTemp);
        }

        [Test]
        public async Task OkaySplitAEmPeeThree()
        {
            const string sourceFile = @"C:\Medias\source\FatT134He29.mp3";
            const string targetFile = @"C:\Medias\target\TestShouts.mp3";
            TimeSpan startTime = new TimeSpan(1, 24, 50);
            TimeSpan endTime = new TimeSpan(1, 25, 22);

            PodConverter c = new PodConverter(tempDirectory, targetDirectory);
            //await c.SplitFile(sourceFile, targetFile, startTime, endTime);
            c.SplitFile(sourceFile, targetFile, startTime, endTime);
        }

        [Test]
        public void ConvertEm()
        {
            const string sourceFile = @"C:\Medias\source\TestShouts.mp3";
            const string targetFile = @"C:\Medias\target\TestShouts.wav";
            PodConverter pc = new PodConverter(tempDirectory, targetDirectory);
            pc.ConvertToWav(sourceFile, targetFile);
        }

        [Test]
        public async Task NowTheWholeThing()
        {
            const string sourceFile = @"C:\Medias\source\TestShouts.mp3";
            const string targetFile = @"EverySinglePersonInHere.wav";
            TimeSpan startTime = new TimeSpan(0, 0, 20);
            TimeSpan endTime = new TimeSpan(0, 0, 28);
            PodConverter pc = new PodConverter(tempDirectory, targetDirectory);
            //await pc.TheWholeDamnThing(sourceFile, targetFile, startTime, endTime);
            pc.TheWholeDamnThing(sourceFile, targetFile, startTime, endTime);
        }

        [Test]
        public void Grace()
        {
            const string sourceFile = @"C:\Medias\source\FatT076CW43.mp3";
            const string targetFile = @"Nothing Wrong With Her.wav";
            TimeSpan startTime = new TimeSpan(0, 20, 56);
            TimeSpan endTime = new TimeSpan(0, 22, 20);
            PodConverter pc = new PodConverter(tempDirectory, targetDirectory);
            //await pc.TheWholeDamnThing(sourceFile, targetFile, startTime, endTime);
            pc.TheWholeDamnThing(sourceFile, targetFile, startTime, endTime);
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    File.Delete(testFileTemp);
        //}
    }
}
