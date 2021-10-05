using System;

namespace PhoneBook
{
    class ContactsList
    {
        static void Main(string[] args)
        {
            var contactsArray = new string[5, 2];


            contactsArray[0, 0] = "User1";
            contactsArray[0, 1] = "User1@gmail.com";
            contactsArray[1, 0] = "User2";
            contactsArray[1, 1] = "User2@gmail.com";
            contactsArray[2, 0] = "User3";
            contactsArray[2, 1] = "User3@gmail.com";
            contactsArray[3, 0] = "User4";
            contactsArray[3, 1] = "User4@gmail.com";
            contactsArray[4, 0] = "User5";
            contactsArray[4, 1] = "User5@gmail.com";

            for (int i = 0; i < contactsArray.GetLength(0); i++)
            {
                Console.WriteLine(contactsArray[i, 0] + " " + contactsArray[i, 1]);
            }

        }
    }
}
