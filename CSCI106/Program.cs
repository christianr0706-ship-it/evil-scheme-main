namespace CSCI106
{
    internal class Program
    {

        static void Main()
        {
        int x = 0;  // establishing these here so that we can change them later
        int y = 0;  // because if I do it later everything hates me for some reason
        int width = 0;
        int height = 0;
        string input;
        string[] array;
        int[]? arr2 = null;

        bool Inputting = true;
        bool Building = false;
            
        while (Inputting == true)
            {
            Console.WriteLine("Input four numbers separated only by spaces.");
            Console.WriteLine("First number is your X-Coordinate,");
            Console.WriteLine("Second number is your Y-Coordinate,");
            Console.WriteLine("Third number is your rectangle width,");
            Console.WriteLine("And fourth number is your rectangle height.");
            Console.WriteLine();

            input = Console.ReadLine(); // here we get the numbers
            array = input.Split(' '); // here we split them up into a string array by the spaces
             
            arr2 = Array.ConvertAll(array, s => int.Parse(s)); // these strange glyphs convert it into an array of ints

            Inputting = false;
            }

        if (arr2.Length == 4)
        {
        x = arr2[0];       // declaring that the parameters in the array are actually the parameters
        y = arr2[1];
        width = arr2[2];
        height = arr2[3];

        Inputting = false;
        Building = true;

        }
        else
        {
        Console.WriteLine("Try again.");
        Inputting = true;

        // I'm done for today but some things need to be added/fixed.
        // - Combine the arr2.Length check with the checks below for one unified system, that way any error leads to the same reset
        // - also actually fix the reset. So any mistake in inputs actually lets the user redo it instead of breaking everything.

        }
    
            while (Building == true)
            {   
                if (x >= 0
                &&  x <= 500
                &&  y >= 0
                &&  y <= 500
                &&  width > 0
                &&  width < 500
                &&  height > 0
                &&  height < 500
                &&  x + width <= 500
                &&  y + height <= 500
                )

                // This is just making sure no individual paranmeter is negative or goes above 500 since that would
                // obviously be just a slight bit problematic in a 500x500 square.
                // > I also just combined the whole "rectangle too big" check into this.
                // And I don't know what happens when a square has 0 width / 0 height so im not letting that happen either.
                {

                        Console.WriteLine("(temporary message) Should work");

                        var svg = SvgBuilder.New((500, 500)).Rect(x, y, width, height).Build();

                        Console.Write("Absolute path to save SVG at: ");
                        var path = Console.ReadLine() ?? "";

                        using (var fileWriter = FileWriter.FromAbsolutePath(path))
                        fileWriter.WriteLine(svg);

                        break;
                }

                else
                {
                    Console.WriteLine("Error with parameters.");
                    
                    //Building = true;

                    break;
                    
                    // The break here is a bandaid over an issue I'd rather figure out later.
                    // This won't come back to bite me or anything though. hopefully.

                    // update: i forgot what the issue was
                }
            }
        }
    }
}

    // notes: svg is already called, should write the svg if you put in a valid path. i think.
    // only problem is actually making rectangles happen
    
    // WHERE IS MY SVG
    // figure out where to save where access isnt denied



