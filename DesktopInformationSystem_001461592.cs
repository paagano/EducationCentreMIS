// DesktopInformationSystem_001461592.cs
// C# Desktop Application for Education Centre Management Information System
// Developed By: Philip Agano - 001461592
// This application manages Teachers, Admins, and Students records
// Demonstrates OOP concepts: Inheritance, Encapsulation, Polymorphism
// Uses a console-based menu for user interaction
// Data is stored in-memory using a List<Person> for simplicity
// No external libraries or databases are used

using System; // Basic system functionalities
using System.Collections.Generic; // For using List<T>

// =============================
//  BASE CLASS: Person
// =============================

// Abstract base class representing a generic person
// Encapsulates common fields and methods for derived classes
// Implements polymorphism via virtual methods
// Inheritance is used to create specific person types (Teacher, Admin, Student)
public abstract class Person
{
    // Private fields (Encapsulation)
    // Common fields for all derived classes (Id, Name, Telephone, Email, Role)
    // Id is unique identifier, set only once in constructor
    private int id;
    private string name;
    private string telephone;
    private string email;
    private string role;

    // Public properties
    // Id is read-only outside the class, set only in constructor
    public int Id
    {
        // Read-only outside the class
        // Protected setter for derived classes
        // Id is set only once during construction
        get => id;
        protected set => id = value;
    }

    // Name property with basic validation
    // Trims whitespace and ensures non-empty
    // Defaults to "Unknown" if invalid
    public string Name
    {
        get => name;
        set => name = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
    }

    // Telephone property with trimming
    // Defaults to empty string if null
    public string Telephone
    {
        get => telephone;
        set => telephone = value?.Trim() ?? string.Empty;
    }

    // Email property with trimming
    // Defaults to empty string if null
    public string Email
    {
        get => email;
        set => email = value?.Trim() ?? string.Empty;
    }

    // Role property (read-only outside, set in constructor)
    // Protected setter for derived classes
    // Role is set only once during construction
    public string Role
    {
        get => role;
        protected set => role = value;
    }

    // Constructor (common to all)
    // Initializes Id and Role
    // Other fields can be set via properties
    protected Person(int id, string role)
    {
        Id = id; // Set unique identifier
        Role = role; // Set role (Teacher/Admin/Student)
    }

    // Virtual method (to be overridden) for displaying info
    // Displays common fields
    // Derived classes will append their specific fields
    public virtual void DisplayInfo()
    {
        // Display the core information in formatted columns
        // This provides a consistent layout for all records
        // The derived classes will add their specific details below this line

        // Console.WriteLine($"ID: {Id} | Role: {Role} | Name: {Name} | Tel: {Telephone} | Email: {Email}");
        Console.WriteLine($"{Id,-5} | {Role,-10} | {Name,-20} | {Telephone,-12} | {Email,-25}"); // Formatted output
    }

    // Editable common fields
    // Can be called by derived classes to edit common fields
    // Derived classes can extend this method to edit their specific fields
    public virtual void EditCommonFields()
    {
        Console.Write($"Enter new name (OR Leave blank and press Enter to keep as '{Name}'): ");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Name = input;

        Console.Write($"Enter new telephone (OR Leave blank and press Enter to keep as '{Telephone}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Telephone = input;

        Console.Write($"Enter new email (OR Leave blank and press Enter to keep as '{Email}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Email = input;
    }
}

// =============================
//  DERIVED CLASS: Teacher
// =============================

// Inherits from Person and adds specific fields for Teacher
public class Teacher : Person
{
    // Private fields for Teacher-specific data
    private double salary;
    private string subject1;
    private string subject2;

    // Public properties for Teacher-specific fields
    // Salary with basic validation (non-negative)
    public double Salary
    {
        get => salary; // Getter
        set => salary = value < 0 ? 0 : value; // Setter with validation
    }

    public string Subject1
    {
        get => subject1;
        set => subject1 = value?.Trim() ?? string.Empty;
    }

    public string Subject2
    {
        get => subject2;
        set => subject2 = value?.Trim() ?? string.Empty;
    }

    // Constructor
    // Calls base constructor to set Id and Role
    // Other fields can be set via properties
    public Teacher(int id) : base(id, "Teacher") { }

    // Override method to display Teacher-specific info
    // Calls base method to display common fields
    // Appends Teacher-specific fields (Polymorphic behavior)
    public override void DisplayInfo()
    {
        // Call base method to display common fields
        base.DisplayInfo();
        // Append Teacher-specific fields
        // Console.WriteLine($"   Teacher Details -> Salary: {Salary}, Subjects: {Subject1}, {Subject2}");
        Console.WriteLine($"       └──Details: Salary: {Salary,8:C2} | Subjects: {Subject1}, {Subject2}"); // Formatted output
        Console.WriteLine(); // Blank line for better readability
    }

    // Override method to edit Teacher-specific fields
    // Calls base method to edit common fields
    // Extends to edit Teacher-specific fields
    public override void EditCommonFields()
    {
        // Calls base method to edit common fields
        base.EditCommonFields();

        // Extends to edit Teacher-specific fields
        Console.Write($"Enter new salary (OR Leave blank and press Enter to keep as '{Salary}'): ");
        var input = Console.ReadLine();
        if (double.TryParse(input, out double s)) Salary = s;

        Console.Write($"Enter subject 1 (OR Leave blank and press Enter to keep as '{Subject1}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Subject1 = input;

        Console.Write($"Enter subject 2 (OR Leave blank and press Enter to keep as '{Subject2}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Subject2 = input;
    }
}

// =============================
//  DERIVED CLASS: Admin
// =============================

// Inherits from Person and adds specific fields for Admin
public class Admin : Person
{
    // Public properties for Admin-specific fields
    public double Salary { get; set; }
    public string EmploymentType { get; set; }
    public int WorkingHours { get; set; }

    public Admin(int id) : base(id, "Admin") { }

    // Override method to display Admin-specific info
    public override void DisplayInfo()
    {
        // Call base method to display common fields
        base.DisplayInfo();

        // Append Admin-specific fields (Polymorphic behavior)
        // Console.WriteLine($"   Admin Details -> Salary: {Salary}, Type: {EmploymentType}, Hours: {WorkingHours}");
        Console.WriteLine($"       └──Details: Salary: {Salary,8:C2} | Type: {EmploymentType} | Hours: {WorkingHours}"); // Formatted output
        Console.WriteLine(); // Blank line for better readability
    }

    // Override method to edit Admin-specific fields
    public override void EditCommonFields()
    {
        // Calls base method to edit common fields
        base.EditCommonFields();

        // Extends to edit Admin-specific fields
        Console.Write($"Enter new salary (OR Leave blank and press Enter to keep as '{Salary}'): ");
        var input = Console.ReadLine();
        if (double.TryParse(input, out double s)) Salary = s;

        Console.Write($"Enter employment type (OR Leave blank and press Enter to keep as '{EmploymentType}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) EmploymentType = input;

        Console.Write($"Enter working hours (OR Leave blank and press Enter to keep as '{WorkingHours}'): ");
        input = Console.ReadLine();
        if (int.TryParse(input, out int h)) WorkingHours = h;
    }
}

// =============================
//  DERIVED CLASS: Student
// =============================

// Inherits from Person and adds specific fields for Student
// Student-specific fields: Subject1, Subject2, Subject3
public class Student : Person
{
    // Public properties for Student-specific fields 
    public string Subject1 { get; set; }
    public string Subject2 { get; set; }
    public string Subject3 { get; set; }

    // Constructor - calls base constructor to set Id and Role
    public Student(int id) : base(id, "Student") { }

    // Override method to display Student-specific info
    public override void DisplayInfo()
    {
        // Call base method to display common fields
        base.DisplayInfo();

        // Append Student-specific fields (Polymorphic behavior)
        // Console.WriteLine($"   Student Details -> Subjects: {Subject1}, {Subject2}, {Subject3}");
        Console.WriteLine($"       └──Details: Subjects: {Subject1}, {Subject2}, {Subject3}"); // Formatted output
        Console.WriteLine(); // Blank line for better readability
    }

    // Override method to edit Student-specific fields
    public override void EditCommonFields()
    {
        // Calls base method to edit common fields
        base.EditCommonFields();

        // Extends to edit Student-specific fields
        Console.Write($"Enter subject 1 (OR Leave blank and press Enter to keep as '{Subject1}'): ");
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Subject1 = input;

        Console.Write($"Enter subject 2 (OR Leave blank and press Enter to keep as '{Subject2}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Subject2 = input;

        Console.Write($"Enter subject 3 (OR Leave blank and press Enter to keep as '{Subject3}'): ");
        input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input)) Subject3 = input;
    }
}


// =========================================
//  PROGRAM ENTRY POINT (Main program Class)
// =========================================

// Main program class
class Program
{
    // A dynamic list to store Person objects (any type: Teacher, Admin, Student)
    // Using List<Person> to leverage polymorphism
    static List<Person> people = new List<Person>();
    static int nextId = 1; // A counter to assign unique IDs

    // Main method
    static void Main()
    {
        bool exit = false; // controls the main loop. Exits when true.

        // Main loop for menu. Exits when user chooses to.(Option 6)
        while (!exit)
        {
            // Display header
            Console.WriteLine(); // Blank line for better readability
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\n EDUCATION CENTRE MANAGEMENT INFORMATION SYSTEM (Desktop App)");
            Console.WriteLine("\n Developed By: Philip Agano - Banner ID: 001461592 | University of Greenwich");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("\n Hi Admin, What would you like to do?");
            Console.WriteLine();

            // Display menu options
            Console.WriteLine("1. Add New record");
            Console.WriteLine("2. View All records");
            Console.WriteLine("3. View records by Role");
            Console.WriteLine("4. Edit existing record");
            Console.WriteLine("5. Delete existing record");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Select an option (1–6): ");

            // Read user choice
            string choice = Console.ReadLine();
            Console.WriteLine(); // Blank line for better readability

            // Handle user choice. Calls appropriate method based on input.
            // Invalid input is handled in default case.
            switch (choice)
            {
                case "1":
                    AddRecord();
                    break;
                case "2":
                    ViewAllRecords();
                    break;
                case "3":
                    ViewRecordsByRole();
                    break;
                case "4":
                    EditRecord();
                    break;
                case "5":
                    DeleteRecord();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again (Allowed Options: 1, 2, 3, 4, 5, 6).");
                    break;
            }
        }

        // Exit message
        Console.WriteLine("Exiting System... Goodbye!");
        Console.Beep(); // Audible feedback on exit
    }

    // ==============================
    //  MENU OPTION METHODS. 
    // ==============================

    // Each method corresponds to a menu option.
    // They handle adding, viewing, editing, and deleting records.
    // The methods leverage polymorphism to manage different Person types.

    // ------------------------------
    // MENU OPTION 1: ADD NEW RECORD
    // ------------------------------

    // Method to add a new record
    static void AddRecord()
    {
        Console.WriteLine("Select User Group:");
        Console.WriteLine("1. Teacher");
        Console.WriteLine("2. Admin");
        Console.WriteLine("3. Student");
        Console.Write("Your Choice: ");
        string roleChoice = Console.ReadLine();

        // Variable to hold the new person object. Initialized to null.
        Person person = null;

        // The switch decides which class object to create based on user input
        switch (roleChoice)
        {
            //  Add Teacher (Case "1")
            //  Collects Teacher-specific data
            case "1":
                person = new Teacher(nextId++);
                Console.Write("Enter Teacher's Name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter Teacher's Telephone No.: ");
                person.Telephone = Console.ReadLine();
                Console.Write("Enter Teacher's Email: ");
                person.Email = Console.ReadLine();

            // Teacher-specific fields
                Console.Write("Enter Salary: ");
                if (double.TryParse(Console.ReadLine(), out double tSalary)) // Basic validation for salary input
                    ((Teacher)person).Salary = tSalary; // Cast to Teacher to access Teacher-specific properties

                Console.Write("Enter Subject 1: ");
                ((Teacher)person).Subject1 = Console.ReadLine();
                Console.Write("Enter Subject 2: ");
                ((Teacher)person).Subject2 = Console.ReadLine();
                break;

            // Add Admin (Case "2")
            // Collects Admin-specific data
            case "2":
                person = new Admin(nextId++);
                Console.Write("Enter Admin's Name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter Admin's Telephone: ");
                person.Telephone = Console.ReadLine();
                Console.Write("Enter Admin's Email: ");
                person.Email = Console.ReadLine();

                Console.Write("Enter Salary: ");
                // Basic validation for salary input
                if (double.TryParse(Console.ReadLine(), out double aSalary))
                    ((Admin)person).Salary = aSalary;

                // Admin-specific fields
                Console.Write("Employment type (Full-time/Part-time): ");
                ((Admin)person).EmploymentType = Console.ReadLine();

                Console.Write("Working Hours: ");
                // Basic validation for working hours input
                if (int.TryParse(Console.ReadLine(), out int hours))
                    ((Admin)person).WorkingHours = hours;
                break;

            // Add Student (Case "3")
            // Collects Student-specific data
            case "3":
                person = new Student(nextId++);
                Console.Write("Enter Student Name: ");
                person.Name = Console.ReadLine();
                Console.Write("Enter Student Telephone No.: ");
                person.Telephone = Console.ReadLine();
                Console.Write("Enter Student Email: ");
                person.Email = Console.ReadLine();

                Console.Write("Enter Subject 1: ");
                ((Student)person).Subject1 = Console.ReadLine();
                Console.Write("Enter Subject 2: ");
                ((Student)person).Subject2 = Console.ReadLine();
                Console.Write("Enter Subject 3: ");
                ((Student)person).Subject3 = Console.ReadLine();
                break;

            default:
                Console.WriteLine("Invalid role selected. Allowed options are 1 - Teacher, 2 - Admin, or 3 - Student.");
                return;
        }

        // Finally, store the new person in the list
        people.Add(person);
        Console.WriteLine($"\nRecord added successfully! Assigned ID: {person.Id}");
    }

    // --------------------------------
    // MENU OPTION 2: VIEW ALL RECORDS
    // --------------------------------

    // Method to view all records
    static void ViewAllRecords()
    {
        // Check if there are any records
        if (people.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        // Display all records
        Console.WriteLine("All Records:");
        // Console.WriteLine("-------------------------------------------------------");
        // Console.WriteLine();

        // Print table header for better readability
        PrintTableHeader();

        foreach (var p in people)
        {
            p.DisplayInfo(); // Polymorphic call – runs the correct derived method
        }
    }

    // ---------------------------
    // MENU OPTION 3: VIEW BY ROLE
    // ---------------------------

    // Method to view records filtered by role
static void ViewRecordsByRole()
    {
        Console.Write("Enter role to filter (Teacher/Admin/Student): ");
        string role = Console.ReadLine()?.Trim();

        // Check for invalid input
        if (string.IsNullOrWhiteSpace(role) ||
            !(role.Equals("Teacher", StringComparison.OrdinalIgnoreCase) ||
            role.Equals("Admin", StringComparison.OrdinalIgnoreCase) ||
            role.Equals("Student", StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Invalid role entered! Please type Teacher, Admin, or Student only.");
            Console.WriteLine("Returning to main menu...\n");
            return; // Take user back to menu
        }

        // Filter records based on valid role (case-insensitive)
        var filtered = people.FindAll(p => p.Role.Equals(role, StringComparison.OrdinalIgnoreCase));

        if (filtered.Count == 0)
        {
            Console.WriteLine($"No records found for role: {role}");
            return;
        }

        Console.WriteLine($"\nRecords for {role}:");

        // Print table header for better readability
        PrintTableHeader();
        foreach (var p in filtered)
        {
            p.DisplayInfo(); // polymorphic call
        }
    }

    // --------------------------
    // MENU OPTION 4: EDIT RECORD
    // --------------------------

    // Method to edit an existing record
    static void EditRecord()
    {
        Console.Write("Enter record ID to edit: ");

        // Validate ID input
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        // Find the person by ID
        var person = people.Find(p => p.Id == id);

        // If not found, inform user
        if (person == null)
        {
            Console.WriteLine("Record not found.");
            return;
        }

        // If record is found, Call the edit method (polymorphic)
        person.EditCommonFields();
        Console.WriteLine();
        Console.WriteLine("Record updated successfully.");
    }

    // ----------------------------
    // MENU OPTION 5: DELETE RECORD
    // ----------------------------

    // Method to delete an existing record
    static void DeleteRecord()
    {
        Console.Write("Enter record ID to delete: ");

        // Validate ID input
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID entered. Returning to main menu...\n");
            return;
        }

        // Find the person by ID
        var person = people.Find(p => p.Id == id);

        // If not found, inform user
        if (person == null)
        {
            Console.WriteLine($"Record with ID {id} not found.\n");
            return;
        }

        // Display record info before confirming
        Console.WriteLine("\nRecord found:");
        person.DisplayInfo();

        // Ask for confirmation
        Console.Write("\nAre you sure you want to delete this record? (1. Yes, 2. No): ");
        string choice = Console.ReadLine()?.Trim();

        switch (choice)
        {
            case "1":
                people.Remove(person);
                Console.WriteLine("Record deleted successfully.\n");
                break;

            case "2":
                Console.WriteLine("Operation cancelled. Record not deleted.\n");
                break;

            default:
                Console.WriteLine("Invalid choice. Operation aborted.\n");
                break;
        }
    }

        // -----------------------------------------------------------
        // Helper method to print table header for better readability
        // -----------------------------------------------------------
        static void PrintTableHeader()
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine($"{"ID",-5} | {"Role",-10} | {"Name",-20} | {"Telephone",-12} | {"Email",-25}"); // Header
            Console.WriteLine("--------------------------------------------------------------------------------");
        }

}