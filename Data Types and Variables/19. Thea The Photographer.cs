using System;

namespace _01.TheaThePhotographer
{
    public class TheaThePhotographer
    {
        public static void Main()
        {
            var picturesTaken = long.Parse(Console.ReadLine());
            var filterTime = long.Parse(Console.ReadLine());
            var filterFactor = long.Parse(Console.ReadLine());
            var pictureUploadTime = long.Parse(Console.ReadLine());

            var filteredPictures = Math.Ceiling(picturesTaken * filterFactor / 100m);
            long totalFilterTime = picturesTaken * filterTime;
            long uploadTime = long.Parse((filteredPictures * pictureUploadTime).ToString());
            var totalSeconds = totalFilterTime + uploadTime;

            var output = TimeSpan.FromSeconds(double.Parse(totalSeconds.ToString()));
            var result = output.ToString("d':'hh':'mm':'ss");

            Console.WriteLine(result);
        }
    }
}