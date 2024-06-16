using System;
using System.Collections.Generic;
using System.Linq;

class Program

    static void Main()
    {
        // Initialize a dictionary to store keys and their corresponding list of values.
        Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        
        // Boolean flag to control the loop for user interactions.
        bool continueProgram = true;

        // Loop to continuously prompt user for input until they choose to quit.
        while (continueProgram)
        {
            // Display menu options to the user.
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("a. Populate the Dictionary");
            Console.WriteLine("b. Display Dictionary Contents");
            Console.WriteLine("c. Remove a Key");
            Console.WriteLine("d. Add a New Key and Value");
            Console.WriteLine("e. Add a Value to an Existing Key");
            Console.WriteLine("f. Sort the Keys");
            Console.WriteLine("q. Quit");
            Console.Write("Enter your choice: ");
            
            // Read user input.
            string choice = Console.ReadLine();

            // Switch statement to handle the user's choice.
            switch (choice)
            {
                case "a":
                    // Call method to populate the dictionary with user input.
                    PopulateDictionary(dictionary);
                    break;
                case "b":
                    // Call method to display the contents of the dictionary.
                    DisplayDictionaryContents(dictionary);
                    break;
                case "c":
                    // Call method to remove a specified key from the dictionary.
                    RemoveKey(dictionary);
                    break;
                case "d":
                    // Call method to add a new key-value pair to the dictionary.
                    AddNewKeyValue(dictionary);
                    break;
                case "e":
                    // Call method to add a value to an existing key in the dictionary.
                    AddValueToExistingKey(dictionary);
                    break;
                case "f":
                    // Call method to sort the keys of the dictionary.
                    SortKeys(dictionary);
                    break;
                case "q":
                    // Set the flag to false to exit the loop and end the program.
                    continueProgram = false;
                    break;
                default:
                    // Handle invalid choices.
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

    }

    // Method to populate the dictionary with a key-value pair entered by the user.
    static void PopulateDictionary(Dictionary<string, List<string>> dict)
    {
        // Prompt the user to enter a key.
        Console.Write("Enter key: ");
        string key = Console.ReadLine();
        
        // Prompt the user to enter a value for the key.
        Console.Write("Enter value: ");
        string value = Console.ReadLine();

        // Check if the key already exists in the dictionary.
        if (!dict.ContainsKey(key))
        {
            // If the key doesn't exist, add a new entry with the key and an empty list of values.
            dict[key] = new List<string>();
        }
        
        // Add the entered value to the list of values for the specified key.
        dict[key].Add(value);
        Console.WriteLine("Entry added.");
    }

    // Method to display the contents of the dictionary.
    static void DisplayDictionaryContents(Dictionary<string, List<string>> dict)
    {
        // Check if the dictionary is empty.
        if (dict.Count == 0)
        {
            // If empty, inform the user.
            Console.WriteLine("The dictionary is empty.");
        }
        else
        {
            // If not empty, iterate through each key-value pair in the dictionary.
            foreach (var kvp in dict)
            {
                // Display the key and its associated list of values.
                Console.WriteLine($"Key: {kvp.Key}, Values: {string.Join(", ", kvp.Value)}");
            }
        }
    }

    // Method to remove a specified key from the dictionary.
    static void RemoveKey(Dictionary<string, List<string>> dict)
    {
        // Prompt the user to enter the key to be removed.
        Console.Write("Enter the key to remove: ");
        string key = Console.ReadLine();

        // Attempt to remove the key from the dictionary.
        if (dict.Remove(key))
        {
            // If removal is successful, inform the user.
            Console.WriteLine("Key removed.");
        }
        else
        {
            // If the key does not exist, inform the user.
            Console.WriteLine("Key not found.");
        }
    }

    // Method to add a new key-value pair to the dictionary.
    static void AddNewKeyValue(Dictionary<string, List<string>> dict)
    {
        // Prompt the user to enter a new key.
        Console.Write("Enter new key: ");
        string key = Console.ReadLine();
        
        // Prompt the user to enter a value for the new key.
        Console.Write("Enter value: ");
        string value = Console.ReadLine();

        // Check if the key already exists in the dictionary.
        if (!dict.ContainsKey(key))
        {
            // If the key doesn't exist, add a new entry with the key and a list containing the entered value.
            dict[key] = new List<string> { value };
            Console.WriteLine("New key-value pair added.");
        }
        else
        {
            // If the key already exists, inform the user.
            Console.WriteLine("Key already exists.");
        }
    }

    // Method to add a value to an existing key in the dictionary.
    static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
    {
        // Prompt the user to enter an existing key.
        Console.Write("Enter existing key: ");
        string key = Console.ReadLine();

        // Check if the key exists in the dictionary.
        if (dict.ContainsKey(key))
        {
            // Prompt the user to enter a value to add to the existing key.
            Console.Write("Enter value to add: ");
            string value = Console.ReadLine();
            
            // Add the entered value to the list of values for the specified key.
            dict[key].Add(value);
            Console.WriteLine("Value added to existing key.");
        }
        else
        {
            // If the key does not exist, inform the user.
            Console.WriteLine("Key not found.");
        }
    }

    // Method to sort the keys in the dictionary.
    static void SortKeys(Dictionary<string, List<string>> dict)
    {
        // Create a new sorted dictionary based on the keys.
        var sortedDict = dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        // Inform the user that the keys have been sorted.
        Console.WriteLine("Dictionary keys sorted.");
        
        // Display the sorted dictionary contents.
        foreach (var kvp in sortedDict)
        {
            Console.WriteLine($"Key: {kvp.Key}, Values: {string.Join(", ", kvp.Value)}");
        }
    }
}