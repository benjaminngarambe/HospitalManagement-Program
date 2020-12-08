using StructureOfHospital;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlPanel
{
    internal class Program
    {
        private static bool userLogged = false;
        private static int userTypeLogged = -1; //specifies the user type 0 - Doctor, 1 - Nurse, 2 - Administrator

        private Doctor d = new Doctor();
        private Nurse n = new Nurse();
        private Administrator a = new Administrator();

        private static bool UserSearch(string username)
        {
            bool userFound = false;

            List<Worker> WorkerList = new List<Worker>();

            for (int i = 0; i < Doctor.DoctorList.Count(); i++)
            {
                WorkerList.Add(Doctor.DoctorList[i]);
            }

            for (int i = 0; i < Administrator.AdministratorList.Count(); i++)
            {
                WorkerList.Add(Administrator.AdministratorList[i]);
            }

            for (int i = 0; i < Nurse.NurseList.Count(); i++)
            {
                WorkerList.Add(Nurse.NurseList[i]);
            }

            for (int i = 0; i < WorkerList.Count(); i++)
            {
                if (WorkerList[i].Username == username)
                {
                    return true;
                }
            }

            if (userFound == false)
            {
                Console.Clear();
                Console.WriteLine("False login\n");
            }
            return false;
        }

        //###########################Iyambere
        private void UserLogin(string username, string password)
        {
            bool userFound = false;
            while (userFound == false)
            {
                for (int i = 0; i < Doctor.DoctorList.Count(); i++)
                {
                    if (Doctor.DoctorList[i].Username == username && Doctor.DoctorList[i].Password == password)
                    {
                        Console.WriteLine("Logged in, hello {0}\n", Doctor.DoctorList[i].Name);
                        userLogged = true;
                        userFound = true;
                        CreateUserInstance(0, i);
                        break;
                    }
                    else if (Doctor.DoctorList[i].Username == username && Doctor.DoctorList[i].Password != password)
                    {
                        Console.WriteLine("The wrong password was entered\n");
                        userFound = true;
                        break;
                    }
                }

                if (userFound == true)
                {
                    break;
                }

                for (int i = 0; i < Nurse.NurseList.Count(); i++)
                {
                    if (Nurse.NurseList[i].Username == username && Nurse.NurseList[i].Password == password)
                    {
                        Console.WriteLine("Logged in, hello {0}\n", Nurse.NurseList[i].Name);
                        userLogged = true;
                        userFound = true;
                        CreateUserInstance(1, i);
                        break;
                    }
                    else if (Nurse.NurseList[i].Username == username && Nurse.NurseList[i].Password != password)
                    {
                        Console.WriteLine("The wrong password was entered \n");
                        userFound = true;
                        break;
                    }
                }

                if (userFound == true)
                {
                    break;
                }

                for (int i = 0; i < Administrator.AdministratorList.Count(); i++)
                {
                    if (Administrator.AdministratorList[i].Username == username && Administrator.AdministratorList[i].Password == password)
                    {
                        Console.WriteLine("Logged in, hello {0}\n", Administrator.AdministratorList[i].Name);
                        userLogged = true;
                        userFound = true;
                        CreateUserInstance(2, i);
                        break;
                    }
                    else if (Administrator.AdministratorList[i].Username == username && Administrator.AdministratorList[i].Password != password)
                    {
                        Console.WriteLine("The wrong password was entered \n");
                        userFound = true;
                        break;
                    }
                }

                if (userFound == false)
                {
                    Console.WriteLine("Wrong login and password were entered\n");
                    break;
                }
            }
        }

        //###########################kabiri
        private void SetLoginValues()
        {
            string username;
            string password;

            if (userLogged == false)
            {
                while (true)
                {
                    Console.WriteLine("Enter login");

                    username = Console.ReadLine();
                    try
                    {
                        if (string.IsNullOrEmpty(username))
                        {
                            Console.Clear();
                            throw new ArgumentException("You entered an empty string \n Try again");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (UserSearch(username))
                {
                    while (true)
                    {
                        Console.WriteLine("enter the password");

                        password = Console.ReadLine();

                        try
                        {
                            if (string.IsNullOrEmpty(password))
                            {
                                Console.Clear();
                                throw new ArgumentException("You entered an empty string \n Try again");
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (SystemException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    Console.Clear();
                    UserLogin(username, password);
                }
            }
        }

        //###########################gatatu
        private object CreateUserInstance(int userType, int i) //the userType parameter specifies the user type 0 - Doctor, 1 - Nurse, 2 - Administrator
        {
            if (userType == 0)
            {
                d = new Doctor(Doctor.DoctorList[i].Username, Doctor.DoctorList[i].Surname,
                               Doctor.DoctorList[i].Pesel, Doctor.DoctorList[i].Username,
                               Doctor.DoctorList[i].Password, Doctor.DoctorList[i].Specialty, Doctor.DoctorList[i].Pzw);
                userTypeLogged = 0;
                return d;
            }
            else if (userType == 1)
            {
                n = new Nurse(Nurse.NurseList[i].Username, Nurse.NurseList[i].Surname,
                              Nurse.NurseList[i].Pesel, Nurse.NurseList[i].Username,
                              Nurse.NurseList[i].Password);
                userTypeLogged = 1;
                return n;
            }
            else if (userType == 2)
            {
                a = new Administrator(Administrator.AdministratorList[i].Username, Administrator.AdministratorList[i].Surname,
                                      Administrator.AdministratorList[i].Pesel, Administrator.AdministratorList[i].Username,
                                      Administrator.AdministratorList[i].Password);
                userTypeLogged = 2;
                return a;
            }
            return -1;
        }

        //###########################kane
        private static void DisplayWorkerList()
        {
            int index = 1;
            for (int i = 0; i < Doctor.DoctorList.Count(); i++)
            {
                Console.WriteLine("{0}: {1} {2} doctor {3}", index, Doctor.DoctorList[i].Name,
                                 Doctor.DoctorList[i].Surname, Doctor.DoctorList[i].Specialty.ToString().ToLower());
                index++;
            }
            for (int i = 0; i < Nurse.NurseList.Count(); i++)
            {
                Console.WriteLine("{0}: {1} {2} nurse", index, Nurse.NurseList[i].Name,
                                 Nurse.NurseList[i].Surname);
                index++;
            }

            if (userTypeLogged == 2)
            {
                for (int i = 0; i < Administrator.AdministratorList.Count(); i++)
                {
                    Console.WriteLine("{0}: {1} {2} administrator", index, Administrator.AdministratorList[i].Name,
                                     Administrator.AdministratorList[i].Surname);
                    index++;
                }
            }
            Console.WriteLine();
        }

        //###########################gatanu
        private void AddUser()
        {
            int switchOption;

            while (true)
            {
                Console.WriteLine("Select the type of user you want to add:\n1. Doctor\n2. Nurse\n3. Administrator\nyour Choice:");

                while (true)
                {
                    try
                    {
                        switchOption = int.Parse(Console.ReadLine());

                        if (switchOption > 3 || switchOption < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("try again\nSelect the type of user you want to add:\n1.Doctor\n2.Nurse\n3.Administrator\nyour Choice: ");
                }

                switch (switchOption)
                {
                    case 1:
                        SetUserData(0);
                        break;

                    case 2:
                        SetUserData(1);
                        break;

                    case 3:
                        SetUserData(2);
                        break;
                }
                break;
            }
        }

        //###########################gatandatu
        private static bool IfLoginIsAlreadyUsed(string username)
        {
            List<Worker> WorkerList = new List<Worker>();

            for (int i = 0; i < Doctor.DoctorList.Count(); i++)
            {
                WorkerList.Add(Doctor.DoctorList[i]);
            }

            for (int i = 0; i < Administrator.AdministratorList.Count(); i++)
            {
                WorkerList.Add(Administrator.AdministratorList[i]);
            }

            for (int i = 0; i < Nurse.NurseList.Count(); i++)
            {
                WorkerList.Add(Nurse.NurseList[i]);
            }

            for (int i = 0; i < WorkerList.Count(); i++)
            {
                if (WorkerList[i].Username == username)
                {
                    Console.WriteLine("\nLogin is already taken");
                    return true;
                }
            }
            return false;
        }

        //###########################karindwi
        private static bool PeselValidation(string pesel)
        {
            if (pesel.Length == 11)
            {
                int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int controlSum = CalculateControlSum(pesel, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;
                if (controlNum == 10)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(pesel[pesel.Length - 1].ToString());
                bool result = controlNum == lastDigit;
                if (result)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("\nPesel Number is invalid");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("\nPesel Number must contain 11 digits");
                return false;
            }
        }

        //###########################umunani
        private static int CalculateControlSum(string pesel, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < pesel.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(pesel[i].ToString());
            }
            return controlSum;
        }

        //###########################icyenda
        private void SetUserData(int userType) //the userType parameter specifies the user type 0 - Doctor, 1 - Nurse, 2 - Administrator
        {
            string name;
            string surname;
            long pesel;
            string username;
            string password;

            Console.Clear();

            name = SetName();
            surname = SetSurname();
            pesel = SetPesel();
            username = SetUsername();
            password = SetPassword();

            if (userType == 0)
            {
                AddDoctor(name, surname, pesel, username, password);
            }
            else if (userType == 1)
            {
                n = new Nurse(name, surname, pesel, username, password);
                n.Add(n);
            }
            else if (userType == 2)
            {
                a = new Administrator(name, surname, pesel, username, password);
                a.Add(a);
            }
            Console.Clear();
            Console.WriteLine("User added\n");
        }

        //###########################icumi
        private static string SetName()
        {
            string name;

            Console.WriteLine("Enter your name");
            while (true)
            {
                try
                {
                    name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name))
                    {
                        throw new ArgumentException("You entered an empty string");
                    }
                    else
                    {
                        if (!IfLoginIsAlreadyUsed(name))
                            break;
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                Console.WriteLine("try again\nEnter your name");
            }
            return name;
        }

        //###########################cuminarimwe
        private static string SetSurname()
        {
            string surname;

            Console.WriteLine("Enter your surname");
            while (true)
            {
                try
                {
                    surname = Console.ReadLine();

                    if (string.IsNullOrEmpty(surname))
                    {
                        throw new ArgumentException("You entered an empty string");
                    }
                    else
                    {
                        if (!IfLoginIsAlreadyUsed(surname))
                            break;
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                Console.WriteLine("try again\nEnter your surname");
            }
            return surname;
        }

        //###########################cuminakabiri
        private static long SetPesel()
        {
            long pesel;

            Console.WriteLine("Enter your Pesel Number");
            while (true)
            {
                string readPesel = Console.ReadLine();
                bool checkTryParse = long.TryParse(readPesel, out pesel);

                if (!checkTryParse)
                {
                    try
                    {
                        throw new ArgumentException("You entered an empty string");
                    }
                    catch (SystemException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                }
                else
                {
                    if (PeselValidation(readPesel))
                        break;
                }

                Console.WriteLine("try again\nEnter your Pesel");
            }
            return pesel;
        }

        //###########################cuminagatatu
        private static string SetUsername()
        {
            string username;

            Console.WriteLine("Please enter your username");
            while (true)
            {
                try
                {
                    username = Console.ReadLine();

                    if (string.IsNullOrEmpty(username))
                    {
                        throw new ArgumentException("You entered an empty string");
                    }
                    else
                    {
                        if (!IfLoginIsAlreadyUsed(username))
                            break;
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                Console.WriteLine("try again\nPlease enter your username");
            }
            return username;
        }

        //###########################cuminakane
        private static string SetPassword()
        {
            string password;

            Console.WriteLine("Enter the user's password");
            while (true)
            {
                try
                {
                    password = Console.ReadLine();

                    if (string.IsNullOrEmpty(password))
                    {
                        throw new ArgumentException("You entered an empty string");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                Console.WriteLine("try again\nEnter the user's password");
            }
            return password;
        }

        //###########################cuminagatanu
        private static int SetPzw()
        {
            int pzw;

            Console.WriteLine("Enter your PWZ number");
            while (true)
            {
                try
                {
                    pzw = int.Parse(Console.ReadLine());
                    if (pzw.ToString().Length == 7)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nThe PWZ number must consist of 7 digits");
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine("\n" + e.Message);
                }
                Console.WriteLine("try again\nEnter your PWZ number");
            }
            return pzw;
        }

        //###########################cuminagatandatu
        private static Specialty SetSpecialty()
        {
            int switchOption;
            while (true)
            {
                Console.WriteLine("Choose the doctor's specialization:\n1. Kardiologist\n2. Urologist \n3. Neurologist\n4. Laryngologist\nChoice: ");

                while (true)
                {
                    try
                    {
                        switchOption = int.Parse(Console.ReadLine());

                        if (switchOption > 4 || switchOption < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.WriteLine("\n" + e.Message);
                    }
                    Console.WriteLine("try again\nChoose the doctor's specialization:\n1. Kardiologist\n2. Urologist \n3. Neurologist\n4. Laryngologist\nChoice: ");
                }
                switch (switchOption)
                {
                    case 1:
                        return Specialty.Kardiolog;

                    case 2:
                        return Specialty.Urolog;

                    case 3:
                        return Specialty.Neurolog;

                    case 4:
                        return Specialty.Laryngolog;
                }
            }
        }

        //###########################cuminakarindwi
        private void AddDoctor(string name, string surname, long pesel, string username, string password)
        {
            int pzw;
            Specialty specialty;

            pzw = SetPzw();
            specialty = SetSpecialty();

            d = new Doctor(name, surname, pesel, username, password, specialty, pzw);
            d.Add(d);
        }

        //###########################cuminumunani
        private void RemoveUserMenu()
        {
            int switchOption;

            while (true)
            {
                Console.WriteLine("Select the type of user you want to delete:\n1. Doctor\n2. Nurse\n3. Administrator\nChoice:");

                while (true)
                {
                    try
                    {
                        switchOption = int.Parse(Console.ReadLine());

                        if (switchOption > 3 || switchOption < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Please try again\n Select the type of user you want to delete:\n1. Doctor\n2. Nurse\n3. Administrator\nChoice:");
                }

                switch (switchOption)
                {
                    case 1:
                        Console.Clear();
                        RemoveUser(d.DisplayList(), 0);
                        break;

                    case 2:
                        Console.Clear();
                        RemoveUser(n.DisplayList(), 1);
                        break;

                    case 3:
                        Console.Clear();
                        RemoveUser(a.DisplayList(), 2);
                        break;
                }
                break;
            }
        }

        //###########################cuminicyenda
        private void RemoveUser(int lastIndex, int listType) //the listType parameter specifies a list of users 0 - list of doctors, 1 - list of nurses, 2 - list of administrators
        {
            int userIndex;
            while (true)
            {
                Console.WriteLine("\nEnter the employee index to be deleted:");
                Console.Write("Choice:");

                while (true)
                {
                    try
                    {
                        userIndex = int.Parse(Console.ReadLine());

                        if (userIndex > lastIndex || userIndex < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered\n");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message + "\n");
                    }
                    if (listType == 0)
                        d.DisplayList();
                    else if (listType == 1)
                        n.DisplayList();
                    else if (listType == 2)
                        a.DisplayList();

                    Console.WriteLine("\nEnter the employee index to be deleted:");
                    Console.Write("Choice:");
                }

                if (listType == 0)
                {
                    d.Remove(userIndex - 1);
                }
                else if (listType == 1)
                {
                    n.Remove(userIndex - 1);
                }
                else if (listType == 2)
                {
                    a.Remove(userIndex - 1);
                }

                Console.Clear();
                Console.WriteLine("User removed\n");
                break;
            }
        }

        //###########################makumyabiri
        private void UpdateUserMenu()
        {
            int switchOption;

            while (true)
            {
                Console.WriteLine("Select the type of user you want to modify:\n1. Doctor\n2. Nurse\n3. Administrator\nChoice:");

                while (true)
                {
                    try
                    {
                        switchOption = int.Parse(Console.ReadLine());

                        if (switchOption > 3 || switchOption < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("Please try again\n Select the type of user you want to modify:\n1. Doctor\n2. Nurse\n3. Administrator\nChoice:");
                }

                switch (switchOption)
                {
                    case 1:
                        Console.Clear();
                        UpdateUser(d.DisplayWholeList(), 0);
                        break;

                    case 2:
                        Console.Clear();
                        UpdateUser(n.DisplayWholeList(), 1);
                        break;

                    case 3:
                        Console.Clear();
                        UpdateUser(a.DisplayWholeList(), 2);
                        break;
                }
                break;
            }
        }

        //###########################
        private void UpdateUser(int lastIndex, int listType) // the listType parameter specifies a list of users 0 - list of doctors, 1 - list of nurses, 2 - list of administrators
        {
            int userIndex;
            while (true)
            {
                Console.WriteLine("\nEnter the employee index to be modified:");
                Console.Write("Choice:");

                while (true)
                {
                    try
                    {
                        userIndex = int.Parse(Console.ReadLine());

                        if (userIndex > lastIndex || userIndex < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered\n");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message + "\n");
                    }
                    if (listType == 0)
                        d.DisplayWholeList();
                    else if (listType == 1)
                        n.DisplayWholeList();
                    else if (listType == 2)
                        a.DisplayWholeList();

                    Console.WriteLine("\nEnter the employee index to be modified:");
                    Console.Write("Choice:");
                }

                SetUpdateValues(userIndex, listType);

                Console.Clear();
                Console.WriteLine("User data has been modified\n");
                break;
            }
        }
        //###########################
        private void SetUpdateValues(int userIndex, int listType) // the listType parameter specifies a list of users 0 - list of doctors, 1 - list of nurses, 2 - list of administrators
        {
            int switchOption;
            string name;
            string surname;
            long pesel;
            string username;
            string password;
            Specialty specialty;
            int pzw;

            Console.Clear();

            if (listType == 0)
            {
                do
                {
                    while (true)
                    {
                        Console.WriteLine("Select the attribute you want to modify:/n1. Name/n2. Lastname/n3. Pesel Number/n4. Login/n5. Password/n6. Specialization/n7. PZW Number/n8. Finish editing /nChoice:");

                        while (true)
                        {
                            try
                            {
                                switchOption = int.Parse(Console.ReadLine());

                                if (switchOption > 8 || switchOption < 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("The wrong number was entered\n");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (SystemException e)
                            {
                                Console.Clear();
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine("try again\nSelect the attribute you want to modify:/n1. Name/n2. Lastname/n3. Pesel Number/n4. Login/n5. Password/n6. Specialization/n7. PZW Number/n8. Finish editing /nChoice:");
                        }

                        switch (switchOption)
                        {
                            case 1:
                                Console.Clear();
                                name = SetName();
                                Doctor.DoctorList[userIndex - 1].Name = name;
                                break;

                            case 2:
                                Console.Clear();
                                surname = SetSurname();
                                Doctor.DoctorList[userIndex - 1].Surname = surname;
                                break;

                            case 3:
                                Console.Clear();
                                pesel = SetPesel();
                                Doctor.DoctorList[userIndex - 1].Pesel = pesel;
                                break;

                            case 4:
                                Console.Clear();
                                username = SetUsername();
                                Doctor.DoctorList[userIndex - 1].Username = username;
                                break;

                            case 5:
                                Console.Clear();
                                password = SetPassword();
                                Doctor.DoctorList[userIndex - 1].Password = password;
                                break;

                            case 6:
                                Console.Clear();
                                specialty = SetSpecialty();
                                Doctor.DoctorList[userIndex - 1].Specialty = specialty;
                                break;

                            case 7:
                                Console.Clear();
                                pzw = SetPzw();
                                Doctor.DoctorList[userIndex - 1].Pzw = pzw;
                                break;
                        }
                        Console.WriteLine();
                        break;
                    }
                }
                while (switchOption != 8);
            }
            else if (listType == 1 || listType == 2)
            {
                do
                {
                    while (true)
                    {
                        Console.WriteLine("Select the attribute you want to modify:\n1. Name\n2. Lastname\n3. Pesel Number\n4. Login\n5. Password\n6. Finish editing\nchoice: ");

                        while (true)
                        {
                            try
                            {
                                switchOption = int.Parse(Console.ReadLine());

                                if (switchOption > 6 || switchOption < 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("The wrong number was entered\n");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            catch (SystemException e)
                            {
                                Console.Clear();
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine("try again\nSelect the attribute you want to modify:\n1. Name\n2. Lastname\n3. Pesel Number\n4. Login\n5. Password\n6. Finish editing\nchoice: ");
                        }

                        if (listType == 1)
                        {
                            switch (switchOption)
                            {
                                case 1:
                                    Console.Clear();
                                    name = SetName();
                                    Nurse.NurseList[userIndex - 1].Name = name;
                                    break;

                                case 2:
                                    Console.Clear();
                                    surname = SetSurname();
                                    Nurse.NurseList[userIndex - 1].Surname = surname;
                                    break;

                                case 3:
                                    Console.Clear();
                                    pesel = SetPesel();
                                    Nurse.NurseList[userIndex - 1].Pesel = pesel;
                                    break;

                                case 4:
                                    Console.Clear();
                                    username = SetUsername();
                                    Nurse.NurseList[userIndex - 1].Username = username;
                                    break;

                                case 5:
                                    Console.Clear();
                                    password = SetPassword();
                                    Nurse.NurseList[userIndex - 1].Password = password;
                                    break;
                            }
                        }
                        else if (listType == 2)
                        {
                            switch (switchOption)
                            {
                                case 1:
                                    Console.Clear();
                                    name = SetName();
                                    Administrator.AdministratorList[userIndex - 1].Name = name;
                                    break;

                                case 2:
                                    Console.Clear();
                                    surname = SetSurname();
                                    Administrator.AdministratorList[userIndex - 1].Surname = surname;
                                    break;

                                case 3:
                                    Console.Clear();
                                    pesel = SetPesel();
                                    Administrator.AdministratorList[userIndex - 1].Pesel = pesel;
                                    break;

                                case 4:
                                    Console.Clear();
                                    username = SetUsername();
                                    Administrator.AdministratorList[userIndex - 1].Username = username;
                                    break;

                                case 5:
                                    Console.Clear();
                                    password = SetPassword();
                                    Administrator.AdministratorList[userIndex - 1].Password = password;
                                    break;
                            }
                        }
                        break;
                    }
                }
                while (switchOption != 6);
            }
        }

        //###########################makumyabirinarimwe
        private static void UserNotLoggedMenu(Program p)
        {
            int switchOption;
            do
            {
                Console.WriteLine("HOSPITAL MENU PROGRAM:");
                Console.WriteLine("1. Sign In \n2. Close the program \nChoice: ");

                while (true)
                {
                    try
                    {
                        switchOption = int.Parse(Console.ReadLine());

                        if (switchOption > 2 || switchOption < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("The wrong number was entered\n");
                        }
                        break;
                    }
                    catch (SystemException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("try again\n");
                    Console.WriteLine("HOSPITAL MENU PROGRAM:");
                    Console.WriteLine("1. Sign In \n2. Close the program \nChoice:");
                }

                switch (switchOption)
                {
                    case 1:
                        Console.Clear();
                        p.SetLoginValues();
                        if (userLogged)
                        {
                            if (UserLoggedMenu(p))
                            {
                                switchOption = 2;
                            }
                        }
                        break;
                }
            }
            while (switchOption != 2);

            Serialization.SerializeList(Doctor.DoctorList, "Doctors.xml");
            Serialization.SerializeList(Nurse.NurseList, "Nurses.xml");
            Serialization.SerializeList(Administrator.AdministratorList, "Administrators.xml");
        }

        private static bool UserLoggedMenu(Program p)
        {
            int switchOption;

            if (userTypeLogged == 0 || userTypeLogged == 1)
            {
                do
                {
                    Console.WriteLine("HOSPITAL MENU PROGRAM:\n1. log out\n2. View a list of employees\n3. Close the program\nChoice: ");
                    while (true)
                    {
                        try
                        {
                            switchOption = int.Parse(Console.ReadLine());

                            if (switchOption > 3 || switchOption < 1)
                            {
                                Console.Clear();
                                Console.WriteLine("The wrong number was entered\n");
                            }

                            break;
                        }
                        catch (SystemException e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("try again\nHOSPITAL MENU PROGRAM:\n1. Log out \n2.View a list of employees \n3. Close the program \nChoice:");
                    }

                    switch (switchOption)
                    {
                        case 1:
                            Console.Clear();
                            userLogged = false;
                            Console.WriteLine("Logged out\n");
                            switchOption = 3;
                            break;

                        case 2:
                            Console.Clear();
                            DisplayWorkerList();
                            break;

                        case 3:
                            Console.Clear();
                            return true;
                    }
                }
                while (switchOption != 3);
            }
            else if (userTypeLogged == 2)
            {
                do
                {
                    Console.WriteLine("HOSPITAL MENU PROGRAM:\n1. log out\n2. View a list of employees\n3. Add a new user\n4. Modify an existing user\n5. Delete existing user\n6. Close the program\nChoice: ");

                    while (true)
                    {
                        try
                        {
                            switchOption = int.Parse(Console.ReadLine());

                            if (switchOption > 6 || switchOption < 1)
                            {
                                Console.Clear();
                                Console.WriteLine("The wrong number was entered\n");
                            }
                            break;
                        }
                        catch (SystemException e)
                        {
                            Console.Clear();
                            Console.WriteLine(e.Message);
                        }
                        Console.WriteLine("try again\nHOSPITAL MENU PROGRAM:\n1.log out\n2.View a list of employees\n3.Add a new user\n4.Modify an existing user\n5.Delete existing user\n6.Close the program\nChoice: ");
                    }

                    switch (switchOption)
                    {
                        case 1:
                            Console.Clear();
                            userLogged = false;
                            Console.WriteLine("Logged out\n");
                            switchOption = 6;
                            break;

                        case 2:
                            Console.Clear();
                            DisplayWorkerList();
                            break;

                        case 3:
                            Console.Clear();
                            p.AddUser();
                            break;

                        case 4:
                            Console.Clear();
                            p.UpdateUserMenu();
                            break;

                        case 5:
                            Console.Clear();
                            p.RemoveUserMenu();
                            break;

                        case 6:
                            return true;
                    }
                }
                while (switchOption != 6);
            }
            return false;
        }

        private static void Main(string[] args)
        {
            Program p = new Program();
            _ = new Serialization();

            Serialization.DeserializeList(ref Doctor.DoctorList, "Doctors.xml");
            Serialization.DeserializeList(ref Nurse.NurseList, "Nurses.xml");
            Serialization.DeserializeList(ref Administrator.AdministratorList, "Administrators.xml");

            UserNotLoggedMenu(p);
        }
    }
}