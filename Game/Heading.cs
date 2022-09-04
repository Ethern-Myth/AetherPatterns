namespace Game
{
    internal class Heading
    {
        public void WelcomeScreen(int option = 1)
        {
            Console.Title = "Mathematical Patterns";
            var footer = new Footer();
            string logo = @"
            __________         __    __                              
            \______   \_____ _/  |__/  |_  ___________  ____   ______
             |     ___/\__  \\   __\   __\/ __ \_  __ \/    \ /  ___/
             |    |     / __ \|  |  |  | \  ___/|  | \/   |  \\___ \ 
             |____|    (____  /__|  |__|  \___  >__|  |___|  /____  >
                            \/                \/           \/     \/ 
            ";
            Console.WriteLine(logo, Console.ForegroundColor = ConsoleColor.Green);
            Console.WriteLine("The Mathematical Pattern Solver", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.WriteLine("", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine(footer.Designer, Console.ForegroundColor = ConsoleColor.Cyan);
            Console.WriteLine("", Console.ForegroundColor = ConsoleColor.White);
        }
    }
}
