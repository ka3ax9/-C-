using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HousingCommunalServices
{
    class Program
    {
        static List<CityService> services;
        static string filePath = "database.txt";

        static void Main(string[] args)
        {
            services = LoadDataFromFile(filePath);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add record");
                Console.WriteLine("2. Edit record");
                Console.WriteLine("3. Delete record");
                Console.WriteLine("4. Display all records");
                Console.WriteLine("5. Search by city district");
                Console.WriteLine("6. Sort by name");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecord();
                        break;
                    case "2":
                        EditRecord();
                        break;
                    case "3":
                        DeleteRecord();
                        break;
                    case "4":
                        DisplayRecords();
                        break;
                    case "5":
                        SearchByCityDistrict();
                        break;
                    case "6":
                        SortByName();
                        break;
                    case "7":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

            SaveDataToFile(filePath, services);
        }

        static void AddRecord()
        {
            Console.WriteLine("Add a new record:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Head: ");
            string head = Console.ReadLine();
            Console.Write("Number of reporting buildings: ");
            int numBuildings = int.Parse(Console.ReadLine());
            Console.Write("City district: ");
            string district = Console.ReadLine();

            CityService newService = new CityService(name, address, head, numBuildings, district);
            services.Add(newService);

            Console.WriteLine("Record added successfully.");
        }

        static void EditRecord()
        {
            Console.WriteLine("Edit a record:");
            Console.Write("Enter the name of the service to edit: ");
            string name = Console.ReadLine();

            CityService service = services.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (service == null)
            {
                Console.WriteLine("Record not found.");
                return;
            }

            Console.WriteLine("Enter new data for the record (leave empty for no change):");
            Console.Write("Name: ");
            string newName = Console.ReadLine();
            Console.Write("Address: ");
            string newAddress = Console.ReadLine();
            Console.Write("Head: ");
            string newHead = Console.ReadLine();
            Console.Write("Number of reporting buildings: ");
            string numBuildingsInput = Console.ReadLine();
            Console.Write("City district: ");
            string newDistrict = Console.ReadLine();

            if (!string.IsNullOrEmpty(newName))
                service.Name = newName;

            if (!string.IsNullOrEmpty(newAddress))
                service.Address = newAddress;

            if (!string.IsNullOrEmpty(newHead))
                service.Head = newHead;

            if (!string.IsNullOrEmpty(numBuildingsInput))
            {
                if (int.TryParse(numBuildingsInput, out int newNumBuildings))
                    service.NumBuildings = newNumBuildings;
                else
                    Console.WriteLine("Invalid number of reporting buildings. The value was not changed.");
            }

            if (!string.IsNullOrEmpty(newDistrict))
                service.District = newDistrict;

            Console.WriteLine("Record edited successfully.");
        }

        static void DeleteRecord()
        {
            Console.WriteLine("Delete a record: ");
            Console.Write("Enter the name of the service to delete: ");
            string name = Console.ReadLine();
            CityService service = services.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (service == null)
            {
                Console.WriteLine("Record not found.");
                return;
            }

            services.Remove(service);
            Console.WriteLine("Record deleted successfully.");
        }

        static void DisplayRecords()
        {
            if (services.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            Console.WriteLine("Records:");
            foreach (CityService service in services)
            {
                Console.WriteLine(service.ToString());
            }
        }

        static void SearchByCityDistrict()
        {
            Console.WriteLine("Search by city district:");
            Console.Write("Enter the city district to search for: ");
            string district = Console.ReadLine();

            List<CityService> foundServices = services.Where(s => s.District.Equals(district, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundServices.Count == 0)
            {
                Console.WriteLine("No records found in the specified city district.");
                return;
            }

            Console.WriteLine("Records found:");
            foreach (CityService service in foundServices)
            {
                Console.WriteLine(service.ToString());
            }
        }

        static void SortByName()
        {
            services.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Records sorted by name.");
        }

        static List<CityService> LoadDataFromFile(string filePath)
        {
            List<CityService> loadedServices = new List<CityService>();

            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');
                        if (fields.Length == 5)
                        {
                            string name = fields[0];
                            string address = fields[1];
                            string head = fields[2];
                            int numBuildings = int.Parse(fields[3]);
                            string district = fields[4];

                            CityService service = new CityService(name, address, head, numBuildings, district);
                            loadedServices.Add(service);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Під час завантаження даних з файлу виникла помилка:");
                    Console.WriteLine(ex.Message);
                }
            }

            return loadedServices;
        }

        static void SaveDataToFile(string filePath, List<CityService> services)
        {
            try
            {
                List<string> lines = new List<string>();

                foreach (CityService service in services)
                {
                    string line = $"{service.Name};{service.Address};{service.Head};{service.NumBuildings};{service.District}";
                    lines.Add(line);
                }

                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Під час збереження даних в файл виникла помилка:");
                Console.WriteLine(ex.Message);
            }
        }
    }

    class CityService
    {
        private string name;
        private string address;
        private string head;
        private int numBuildings;
        private string district;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be empty.");
                name = value;
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Address cannot be empty.");
                address = value;
            }
        }

        public string Head
        {
            get { return head; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Head cannot be empty.");
                head = value;
            }
        }

        public int NumBuildings
        {
            get { return numBuildings; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Number of reporting buildings cannot be negative.");
                numBuildings = value;
            }
        }

        public string District
        {
            get { return district; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("District cannot be empty.");
                district = value;
            }
        }

        public CityService(string name, string address, string head, int numBuildings, string district)
        {
            Name = name;
            Address = address;
            Head = head;
            NumBuildings = numBuildings;
            District = district;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nHead: {Head}\nNumber of reporting buildings: {NumBuildings}\nDistrict: {District}\n";
        }
    }
}