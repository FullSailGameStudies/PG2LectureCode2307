using Newtonsoft.Json;

namespace Day10
{

    /*
        ╔══════════╗ 
        ║ File I/O ║
        ╚══════════╝ 

        3 things are required for File I/O:
        1) Open the file
        2) read/write to the file
        3) close the file


        TIPS:
            use File.ReadAllText to open,read,close the file in 1 statement
            the using() statement can ensure that the file is closed

    */
    public enum Powers
    {
        Money, Jumping, Speed, Strength, Swimming
    }
    class Superhero
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public Powers Power { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                ╔══════════╗ 
                ║ File I/O ║
                ╚══════════╝ 

                [  Open the file  ]
                [  Write to the file  ]
                [  Close the file  ]
             
                you need the path to the file
                    use full path ( drive + directories + filename )
                    or use relative path ( directories + filename )
                    or current directory ( filename )


                
                using (StreamWriter sw = new StreamWriter(filePath)) // this line opens the file to write to it
                {                
                    //these lines write to the file
                    sw.Write("Batman");
                    sw.Write(54);
                    sw.Write(13.7);
                    sw.Write(true);

                }//this closes the file

            */

            string directories = @"C:\temp\2307"; //use @ in front of the string to ignore escape sequences inside the string
            string fileName = "tempFile.txt";
            string fullfilePath = Path.Combine(directories, fileName); //use Path.Combine to get the proper directory separators


            //1. OPEN the file
            //  where? fullfilepath
            //  how to open? WRITE/OVERWRITE

            string myPath = @"C:\temp\2307";
            char delimiter = '^';
            using (StreamWriter sw = new StreamWriter(fullfilePath))
            {
                //2. Write the data
                sw.Write("Batman rules!");
                sw.Write(delimiter);
                sw.Write(15);
                sw.Write(delimiter);
                sw.Write(true);
                sw.Write(delimiter);
                sw.Write(23.078);
            }//3. CLOSES the file

            /*
                CHALLENGE 1:
                    Create a List of Superhero.
                    Write the list to a CSV file             
            */
            List<Superhero> jla = new List<Superhero>();
            jla.Add(new Superhero() { Name = "Batman", Secret = "Bruce Wayne", Power = Powers.Money });
            jla.Add(new Superhero() { Name = "Wonder Woman", Secret = "Diana Prince", Power = Powers.Strength });
            jla.Add(new Superhero() { Name = "Superman", Secret = "Clark Kent", Power = Powers.Jumping });
            string jlaFile = "jla.csv";
            fullfilePath = Path.Combine(directories, jlaFile);
            using (StreamWriter sw = new StreamWriter(fullfilePath))
            {
                sw.WriteLine($"Name{delimiter}Secret{delimiter}Power");
                foreach (var hero in jla)
                {
                    //add the \n as the hero delimiter
                    sw.WriteLine($"{hero.Name}{delimiter}{hero.Secret}{delimiter}{hero.Power}");
                }
            }


            /*
                ╔═══════════════════╗ 
                ║ Splitting Strings ║
                ╚═══════════════════╝ 

                taking 1 string a separating it into multiple pieces of data

                use the string's Split method

            */
            string csvString = "Batman;Bruce Wayne;Bats;The Dark Knight";
            string[] data = csvString.Split(';');

            fullfilePath = Path.Combine(directories, fileName);
            //File.ReadAllText
            //  does all 3 steps: Open, Read, Close
            string csvData = File.ReadAllText(fullfilePath);
            Console.WriteLine(csvData);
            //string Split returns a string[]
            string[] batData = csvData.Split(delimiter);
            foreach (var item in batData)
            {
                Console.WriteLine(item);
            }
            string catchPhrase = batData[0];
            int age = int.Parse(batData[1]);
            bool isTheBest = bool.Parse(batData[2]);
            double grade = double.Parse(batData[3]);
            Console.WriteLine($"{catchPhrase}\t{age}\t{isTheBest}\t{grade}");

            /*
                CHALLENGE 2:

                    Open the CSV file and read the data into a new list of superheroes

                read the text from the file
                split to get each row (\n is the delimiter)
                skip the first line (header row)
                for the other lines
                    skip any empty lines
                    split the line to get the hero data
                    create a new superhero and fill in the data using the hero data
                    add the superhero to the list
             
            */
            fullfilePath = Path.Combine(directories, jlaFile);
            string heroText = File.ReadAllText(fullfilePath);
            string[] heroLines = heroText.Split('\n');
            List<Superhero> DC = new();
            for (int i = 1; i < heroLines.Length-1; i++) //skip the first and last lines
            {
                string[] heroData = heroLines[i].Split(delimiter);
                Superhero hero = new()
                {
                    Name = heroData[0],
                    Secret = heroData[1],
                    Power = Enum.Parse<Powers>(heroData[2])
                };
                DC.Add(hero);
            }





            /*
                ╔═════════════╗ 
                ║ Serializing ║
                ╚═════════════╝ 

                Saving the state (data) of objects

            */
            Superhero hero1 = new Superhero() { Name = "Garrett", Secret = "Batman", Power = Powers.Swimming };
            fullfilePath = Path.Combine(directories, "garrett.json");
            using (StreamWriter sw = new StreamWriter(fullfilePath))
            {
                using(JsonTextWriter  jsonWriter = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(jsonWriter, hero1);//write json data to the file
                }
            }
            //OR...
            File.WriteAllText(fullfilePath, JsonConvert.SerializeObject(hero1, Formatting.Indented));


            /*
             * Challenge 3:
                Serialize (write) the list of superheroes to a json file
            */
            jlaFile = Path.ChangeExtension(jlaFile, "json");
            fullfilePath = Path.Combine(directories, jlaFile);
            File.WriteAllText(fullfilePath, JsonConvert.SerializeObject(jla, Formatting.Indented));




            /*
                ╔═══════════════╗ 
                ║ Deserializing ║
                ╚═══════════════╝ 

                Recreating the objects from the saved state (data) of objects

            */
            fullfilePath = Path.Combine(directories, "garrett.json");
            // Program DEFENSIVELY
            if (File.Exists(fullfilePath))
            {
                string garrettText = File.ReadAllText(fullfilePath);
                try
                {
                    Superhero theBest = JsonConvert.DeserializeObject<Superhero>(garrettText);
                    Console.WriteLine($"The BEST! {theBest.Name} aka {theBest.Secret}. He can do {theBest.Power}!");

                }
                catch(JsonSerializationException)
                {
                    Console.WriteLine("The file is the wrong format.");
                }
                catch (Exception)
                {
                }            
            }
            else
                Console.WriteLine($"{fullfilePath} does not exists!");

            /*
             
                Challenge 4: deserialize the jla.json file into a list of superheroes

            */

            fullfilePath = Path.Combine(directories, jlaFile);
            try
            {
                List<Superhero> DC2 = JsonConvert.DeserializeObject<List<Superhero>>(File.ReadAllText(fullfilePath));
                Console.WriteLine("   DC2 List   ");
                foreach (var hero in DC2)
                {
                    Console.WriteLine($"{hero.Name} aka {hero.Secret}. I can do {hero.Power}!");
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine($"{fullfilePath} does not exists!");
            }
            catch (JsonSerializationException)
            {
                Console.WriteLine("The file is the wrong format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}