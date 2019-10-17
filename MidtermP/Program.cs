using System;

namespace MidtermP
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Pieces { get; set; }
        public double Man_Price { get; set; }
        public double Store_Price { get; set; }


    }
    public class Inventory : Item
    {
        Item[] item = new Item[5];
        public void Start() {
            for (int i = 0; i < item.Length; i++)
            {
                item[i] = new Item();
                
             }
            item[0].ID = 100;
            item[1].ID = 235;
            item[2].ID = 670;
            item[3].ID = 340;
            item[4].ID = 130;

            item[0].Name = "SCREW";
            item[1].Name = "BOLTS";
            item[2].Name = "CHIPS";
            item[3].Name = "RASPY";
            item[4].Name = "METAL";

            item[0].Pieces = 213;
            item[1].Pieces = 345;
            item[2].Pieces = 170;
            item[3].Pieces = 330;
            item[4].Pieces = 720;

            item[0].Man_Price = 401;
            item[1].Man_Price = 550;
            item[2].Man_Price = 570;
            item[3].Man_Price = 127;
            item[4].Man_Price = 200;

            item[0].Store_Price = 650;
            item[1].Store_Price = 860;
            item[2].Store_Price = 670;
            item[3].Store_Price = 430;
            item[4].Store_Price = 300;


        }
        public void Check(int id)
        {
            Start();
            int count = 0;
            for(int i =0; i < item.Length; i++)
            { 
                if(item[i].ID == id)
                {
                    Console.WriteLine("Item Is Available");

                    count++;   
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Item Not Available");
            }
        }
        public void Update(int id, int pieces)
        {

            Start();
            for (int i = 0; i < item.Length; i++)
            {
                if(pieces > item[i].Pieces)
                {
                    Console.WriteLine("Sorry It is Not Allowed");
                }
                if(item[i].ID == id)
                {
                    item[i].Pieces -= pieces;
                    Console.WriteLine("Item {0} Has {1} Pieces Now", item[i].ID, item[i].Pieces);
                }

            }
            
        

        }
        public void Quantity(int id)
        {
            Start();
            for(int i =0; i < item.Length;i++)
            {
                if(item[i].ID == id)
                {
                    Console.WriteLine("The Quantity For Item {0} Is : {1}",item[i].Name,item[i].Pieces);
                }
            }
        }
        public void Report()
        {
            Start();
            Console.WriteLine("Item ID   Item Name    Item Pieces   Item Man_Price   Item Store_Price");
            for (int i = 0; i < item.Length; i++)
            {
            Console.WriteLine("{0}       {1}          {2}            {3}               {4}", item[i].ID, item[i].Name, item[i].Pieces, item[i].Man_Price, item[i].Store_Price);
            }
            double inventory = 0;
            double num_items = 0;
            for(int i =0; i < item.Length; i++)
            {
                inventory += item[i].Pieces * item[i].Store_Price;
                num_items += item[i].Pieces;
            }
            Console.WriteLine("Total Inventory: ${0}",inventory);
            Console.WriteLine("Total Number OF Items In Store: {0}",num_items);


        }

    }
    public class Client: Inventory
    {
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("**********************************\n\n");
                   Console.WriteLine("WELCOME TO THE HARDWARE STORE\n");
                Console.WriteLine("PLEASE SELECT ONE OF THE OPTIONS:");
                Console.WriteLine("1.CHECK ITEM IS IN THE STORE\n");
                Console.WriteLine("2.SELL AN ITEM\n");
                Console.WriteLine("3.PRINT THE REPORT\n");
                Console.WriteLine("4. Cancel\n");
                
               choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("WHAT IS THE ID OF THE ITEM YOURE LOOKING FOR?");
                        var it = Convert.ToInt32(Console.ReadLine());
                        Check(it);
                        break;
                    case 2:
                        Console.WriteLine("WHAT IS THE ID FOR THE ITEM THAT YOU WANT TO SELL AND HOW MANY PIECES?");
                        var id = Convert.ToInt32(Console.ReadLine());
                        var pieces = Convert.ToInt32(Console.ReadLine());
                        Update(id, pieces);
                        break;
                    case 3:
                        Report();
                        break;
                    case 4:
                        Console.WriteLine("\n\nTHANK YOU FOR USING SOFTWARE SERVICE");
                        break;
                }
            } while (choice != 4);
        }

    }

    class MainClass
    {
        public static void Main(string[] args)
        {

            var client = new Client();
            client.Menu();
            
            
           
        }
    }
}
