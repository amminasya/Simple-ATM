
using System;
using System.Collections.Specialized;

public class CardHolder
{
    String cardnum;
    String name;
    String surname;
    int pin;
    double balance;

    public CardHolder(string cardnum, string name, string surname, int pin, double balance)
    {
        this.name = name;
        this.surname = surname;
        this.pin = pin;
        this.cardnum = cardnum;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardnum;
    }

    public string getName()
    {
        return name;
    }

    public string getSurname()
    {
        return surname;
    }

    public int getPin()
    {
        return pin;
    }

    public double getbalance ()
    {
        return balance;
    }

    public void setNum(String newcardnum)
    {
        cardnum = newcardnum;
    }

    public void setName(String newname)
    {
        name = newname;
    }

    public void setSurname(String newsurname) 
    {  
        surname = newsurname;
    }   

    public void setPin(int newpin)
    {
        pin = newpin;
    }

    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one option   ");
            Console.WriteLine("Option 1: Deposit");
            Console.WriteLine("Option 2: Withdraw");
            Console.WriteLine("Option 3: Show Balance");
            Console.WriteLine("Option 4: Exit");

        }


        void deposit(CardHolder currentuser)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit = Double.Parse(Console.ReadLine());
            currentuser.setbalance(deposit + currentuser.getbalance());
            Console.WriteLine("Your current balance is: " + currentuser.getbalance);
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money  would you like to withdraw?");
            double withdraw = Double.Parse(Console.ReadLine());
            //check if there is enough money

            if(currentUser.getbalance() < withdraw)
            {
                Console.WriteLine("Not enough money :(");
            }
            else
            {
                currentUser.setbalance(currentUser.getbalance() - withdraw);
                Console.WriteLine("Thank you");
            }
        }

        void balance(CardHolder currentuser)
        {
            Console.WriteLine("Your current balance is: " + currentuser.getbalance());
        }

        List<CardHolder> cardholders = new List<CardHolder>();
        cardholders.Add(new CardHolder("6677889910101111", "Asya", "Minasyan",124, 16.1));
        cardholders.Add(new CardHolder("6677889910101112", "Alla", "Lusinyan", 133, 176.01));
        cardholders.Add(new CardHolder("6677889910101131", "Dave", "petyan", 656, 516.91));

        //prompt user
        Console.WriteLine("Please enter your debit card:  ");
        String debitnum ="";
        CardHolder currentuser;

        while(true)
        {
            try
            {
                debitnum = Console.ReadLine();
                //check against our "database"
                currentuser = cardholders.FirstOrDefault(a => a.cardnum == debitnum);
                if (currentuser != null) { break; }
                else { Console.WriteLine("Card not recognized"); }
            }
            catch { Console.WriteLine("Card not recognized"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userpin = 0;
        while(true)
        {
            try
            {
                userpin = int.Parse(Console.ReadLine());
                if (currentuser.getPin() == userpin) { break; }
                else { Console.WriteLine("Incorrect pin.Please try again"); }

            }
            catch { Console.WriteLine("Incorrect pin.Please try again"); }
        }

        Console.WriteLine("Welcome " + currentuser.getName());
        int option = 0;
        do
        {
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentuser);  }
            else if (option == 2) { withdraw(currentuser); }
            else if (option == 3) { balance(currentuser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 5);
        Console.WriteLine("Thank you");
    }

}
