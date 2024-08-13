//*****************************************************************************
//** Directory Listing                                                       **
//** The program will create a file named directory_listing.txt in the same  **
//** directory as the executable, containing the listing of all files and 
//** directories.                                                            **
//*****************************************************************************


using System;
using System.IO;

namespace DirectoryListing
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string outputFilePath = "directory_listing.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine($"Listing files in directory: {currentDirectory}\n");
                    ListFiles(currentDirectory, writer);
                }

                Console.WriteLine($"Directory listing has been saved to {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void ListFiles(string directory, StreamWriter writer)
        {
            // List all files in the current directory
            foreach (string file in Directory.GetFiles(directory))
            {
                writer.WriteLine(file);
            }

            // List all subdirectories and recurse into them
            foreach (string subdirectory in Directory.GetDirectories(directory))
            {
                writer.WriteLine(subdirectory);
                ListFiles(subdirectory, writer);
            }
        }
    }
}