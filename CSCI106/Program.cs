namespace CSCI106
{
    internal class Program
    {

        static void Main()
        {
            int x = 10;
            int y = 10;
            int width = 100;
            int height = 100;

            bool Building = true;

            while (Building == true)
            {
                var svg = SvgBuilder.New((500, 500)).Rect(x, y, width, height).Build();

                Console.Write("Absolute path to save SVG at: ");
                var path = Console.ReadLine() ?? "";
                
                if (x >= 0 && x <= 500 && y >= 0 && y <= 500 && width > 0 && width < 500 && height > 0 && height < 500)
                // This is just making sure no individual paranmeter is negative or goes above 500 since that would
                // obviously be just a slight bit problematic in a 500x500 square.
                // And I don't know what happens when a square has 0 width / 0 height so im not letting that happen either.
                {
                    if (x + width <= 500 && y + height <= 500)
                    // now we're making sure the two sides of the square aren't too long once paired with x/y vals.
                    {
                        Console.WriteLine("(temporary message) Should work");

                        using (var fileWriter = FileWriter.FromAbsolutePath(path))
                        fileWriter.WriteLine(svg);

                        break;
                    }

                    else
                    {
                    Console.WriteLine("bad evil vibes. Your rectangle goes outside the parameters.");
                    Building = true;
                    }
                }

                else
                {
                    Console.WriteLine("terrible misfortune. Your rectangle doesn't even start in bounds.");
                    Building = true;
                    // I let it repeat in case parameters are user-inputed in the future.
                    // But for now I can just code them in.
                }
            }
        }
    }
}

    // notes: svg is already called, should write the svg if you put in a valid path. i think.
    // only problem is actually making rectangles happen
    
    // WHERE IS MY SVG
    // figure out where to save where access isnt denied



