using System;
using System.Collections.Generic;
using System.Text;

namespace speakersetup
{
    class Program
    {
        private static List<string> speakerModes = new List<string> { "hp", "1", "2", "4", "5", "5.1", "7.1" };
        private static void changeMode(string mode)
        {
            string strMode = "";
            Microsoft.DirectX.DirectSound.Device dev = new Microsoft.DirectX.DirectSound.Device(Guid.Empty);
            Microsoft.DirectX.DirectSound.Speakers s = new Microsoft.DirectX.DirectSound.Speakers();
            s.FivePointOne = false;
            s.GeometryMax = false;
            s.GeometryMin = false;
            s.GeometryNarrow = false;
            s.GeometryWide = false;
            s.Headphone = false;
            s.Mono = false;
            s.Quad = false;
            s.SevenPointOne = false;
            s.Stereo = false;
            s.Surround = false;
            switch (mode)
            {
                case "hp":
                    s.Headphone = true;
                    strMode = "Headphones";
                    break;
                case "1":
                    strMode = "Monophonic speaker (1.0)";
                    s.Mono = true;
                    break;
                case "2":
                    strMode = "Desktop stereo speakers (2.0)";
                    s.Stereo = true;
                    break;
                case "4":
                    strMode = "Quadraphonic speakers (4.0)";
                    s.Quad = true;
                    break;
                case "5":
                    strMode = "Surround sound speakers (5.0)";
                    s.Surround = true;
                    break;
                case "5.1":
                    strMode = "5.1 surround sound speakers";
                    s.FivePointOne = true;
                    break;
                case "7.1":
                    strMode = "7.1 speakers";
                    s.SevenPointOne = true;
                    s.Mono = true;
                    break;
            }
            dev.SpeakerConfig = s;
            dev.Dispose();
            Console.WriteLine(strMode + " mode successfully set");
        }

        static void Main(string[] args)
        {
            if ((args.Length == 1) && (speakerModes.Contains(args[0].ToLower())))
            {
                changeMode(args[0]);
            }
            else
            {
                Console.WriteLine("Homepage: http://vrokolos.blogspot.com/2008/03/change-speaker-mode-using-command-line.html");
                Console.WriteLine("This program changes the speaker settings under Control Panel -> Sound and Audio devices -> Advanced -> Speaker Settings using command line.");
                Console.WriteLine("");
                Console.WriteLine("Useage: speakersetup.exe [Speaker Mode]");
                Console.WriteLine("");
                Console.WriteLine("[Speaker Mode] can be one of the following:");
                Console.WriteLine("     hp: Stereo headphones");
                Console.WriteLine("      1: Monophonic speaker");
                Console.WriteLine("      2: Desktop stereo speakers (2.0)");
                Console.WriteLine("      4: Quadraphonic speakers (4.0)");
                Console.WriteLine("      5: Surround sound speakers (5.0)");
                Console.WriteLine("    5.1: 5.1 surround sound speakers");
                Console.WriteLine("    7.1: 7.1 speakers");
                Console.WriteLine("");
                Console.WriteLine("Examples:");
                Console.WriteLine("    \"speakersetup 5.1\" will switch to 5.1 surround sound speakers.");
                Console.WriteLine("    \"speakersetup hp\" will switch to headphones.");
            }
        }
    }
}
