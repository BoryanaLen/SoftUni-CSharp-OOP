using P01.Stream_Progress.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable streamMusic = new Music("Artist", "Album", 1, 10);

            IStreamable streamVideo = new Video("Space", 30, 500);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(streamMusic);

            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());

            streamProgressInfo = new StreamProgressInfo(streamVideo);

            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}
