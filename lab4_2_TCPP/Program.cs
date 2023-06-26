using System;
using System.Collections.Generic;
using System.IO;

namespace CityDatabase
{
    class City
    {
        private string name;
        private string address;
        private string chiefLastName;
        private int numberOfSubbuildings;
        private string district;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string ChiefLastName
        {
            get { return chiefLastName; }
            set { chiefLastName = value; }
        }

        public int NumberOfSubbuildings
        {
            get { return numberOfSubbuildings; }
            set { numberOfSubbuildings = value; }
        }

        public string District
        {
            get { return district; }
            set { district = value; }
        }

        public City()
        {
        }

        public City(string name, string address, string chiefLastName, int numberOfSubbuildings, string district)
        {
            Name = name;
            Address = address;
            ChiefLastName = chiefLastName;
            NumberOfSubbuildings = numberOfSubbuildings;
            District = district;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nChief's Last Name: {ChiefLastName}\nNumber of Subbuildings: {NumberOfSubbuildings}\nDistrict: {District}\n";
        }
    }

    class CityDatabase
    {
        private List<City> cities;
        private string filePath;

        public CityDatabase(string filePath)
        {
            this.filePath = filePath;
            cities = new List<City>();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    City city = new City(data[0], data[1], data[2], int.Parse(data[3]), data[4]);
                    cities.Add(city);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Database file not found. Creating a new database.");
                File.Create(filePath).Close();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while loading the database: {e.Message}");
            }
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (City city in cities)
                    {
                        string line = $"{city.Name};{city.Address};{city.ChiefLastName};{city.NumberOfSubbuildings};{city.District}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while saving the database: {e.Message}");
            }
        }

        public void AddCity(City city)
        {
            cities.Add(city);
            SaveData();
            Console.WriteLine("City added successfully.");
        }

        public void EditCity(int index, City updatedCity)
        {
            if (index >= 0 && index < cities.Count)
            {
                cities[index] = updatedCity;
                SaveData();
                Console.WriteLine("City updated successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index. City not found.");
            }
        }

        public void DeleteCity(int index)
        {
            if (index >= 0 && index < cities.Count)
            {
                cities.RemoveAt(index);
                SaveData();
                Console.WriteLine("City deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid index. City not found.");
            }
        }

        public void DisplayCities()
        {
            if (cities.Count == 0)
            {
                Console.WriteLine("No cities found in the database.");
            }
            else
            {
                foreach (City city in cities)
                {
                    Console.WriteLine(city);
                }
            }
        }

        public void SearchByDistrict(string district)
        {
            List<City> matchedCities = cities.FindAll(city => city.District.Equals(district, StringComparison.OrdinalIgnoreCase));

            if (matchedCities.Count == 0)
            {
                Console.WriteLine("No cities found in the specified district.");
            }
            else
            {
                foreach (City city in matchedCities)
                {
                    Console.WriteLine(city);
                }
            }
        }

        public void SortByName()
        {
            cities.Sort((x, y) => x.Name.CompareTo(y.Name));
            Console.WriteLine("Cities sorted by name.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "database.txt";
            CityDatabase cityDatabase = new CityDatabase(filePath);

            while (true)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("City Database");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Add City");
                Console.WriteLine("2. Edit City");
                Console.WriteLine("3. Delete City");
                Console.WriteLine("4. Display Cities");
                Console.WriteLine("5. Search by District");
                Console.WriteLine("6. Sort by Name");
                Console.WriteLine("7. Exit");
                Console.WriteLine("------------------------------");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter city details:");
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Chief's Last Name: ");
                        string chiefLastName = Console.ReadLine();
                        Console.Write("Number of Subbuildings: ");
                        int numberOfSubbuildings = int.Parse(Console.ReadLine());
                        Console.Write("District: ");
                        string district = Console.ReadLine();
                        City newCity = new City(name, address, chiefLastName, numberOfSubbuildings, district);
                        cityDatabase.AddCity(newCity);
                        break;
                    case "2":
                        Console.WriteLine("Enter the index of the city to edit: ");
                        int editIndex = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter updated city details:");
                        Console.Write("Name: ");
                        string updatedName = Console.ReadLine();
                        Console.Write("Address: ");
                        string updatedAddress = Console.ReadLine();
                        Console.Write("Chief's Last Name: ");
                        string updatedChiefLastName = Console.ReadLine();
                        Console.Write("Number of Subbuildings: ");
                        int updatedNumberOfSubbuildings = int.Parse(Console.ReadLine());
                        Console.Write("District: ");
                        string updatedDistrict = Console.ReadLine();
                        City updatedCity = new City(updatedName, updatedAddress, updatedChiefLastName, updatedNumberOfSubbuildings, updatedDistrict);
                        cityDatabase.EditCity(editIndex, updatedCity);
                        break;
                    case "3":
                        Console.WriteLine("Enter the index of the city to delete: ");
                        int deleteIndex = int.Parse(Console.ReadLine());
                        cityDatabase.DeleteCity(deleteIndex);
                        break;
                    case "4":
                        cityDatabase.DisplayCities();
                        break;
                    case "5":
                        Console.Write("Enter the district to search: ");
                        string searchDistrict = Console.ReadLine();
                        cityDatabase.SearchByDistrict(searchDistrict);
                        break;
                    case "6":
                        cityDatabase.SortByName();
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
