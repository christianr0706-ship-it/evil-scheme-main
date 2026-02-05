namespace CSCI106
{
    internal class Program
    {
        static void Main()
        {
            var svg = SvgBuilder.New((500, 500)).Rect(10, 10, 100, 100).Build();

            Console.Write("Absolute path to save SVG at: ");
            var path = Console.ReadLine() ?? "";            

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg);
        }

    }

    // notes: svg is already called, should write the svg if you put in a valid path. i think.
    // only problem is actually making rectangles happen
}


