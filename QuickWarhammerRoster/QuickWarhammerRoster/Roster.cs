using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWarhammerRoster
{
    class Roster
    {
        private static int rosterCounter;
        private static List<Unit> UnitList = new List<Unit>();
        public static List<Unit> RosterList = new List<Unit>();

        private static int rosterPoints;
        //Counters control looping sequence within the method
        private static string continuetroopSelected;
        private static int hqCounter;
        private static int troopCounter;
        //int fastCounter = 0; not implemented yet
        //int heavyCounter = 0; to be implemented once I own Heavy Support Models


        public static void addUnits()
        {
            UnitList.Add(new Unit("Gravis Captain", "hq", 7));
            UnitList.Add(new Unit("Lieutenent", "hq", 5));
            UnitList.Add(new Unit("Mephiston", "hq", 8));
            UnitList.Add(new Unit("Librarian", "hq", 6));
            UnitList.Add(new Unit("Librarian Dreadnought", "hq", 9));
            UnitList.Add(new Unit("Scouts", "troop", 4));
            UnitList.Add(new Unit("Tactical Squad", "troop", 9));
            UnitList.Add(new Unit("Intercessors", "troop", 10));
            UnitList.Add(new Unit("Sanguinary Guard", "elite", 8));
            UnitList.Add(new Unit("Assault Terminators", "elite", 11));
            UnitList.Add(new Unit("Reivers", "elite", 10));
            UnitList.Add(new Unit("Inceptors", "fast", 10));
            UnitList.Add(new Unit("Assault Squad", "fast", +9));
        }
        public static void rosterQuery() //prints the force
        {
            foreach (var Unit in RosterList)
            {
                rosterPoints = Unit.unitCost + rosterPoints;
            }
            

            Console.WriteLine("Your Force so far: ");
            foreach (var Unit in RosterList)
            {
                Console.WriteLine(Unit.unitName + ", " + Unit.unitType + ", " + Unit.unitCost + " Power Level");
            }            
            Console.WriteLine();//write a blank line
            Console.WriteLine("Total Power Level: " + rosterPoints);
        }
        public static void hqSelector()//called during rosterbuilder to pick HQs and display them
        {
            foreach (var Unit in UnitList.FindAll(x => x.unitType == "hq"))//displays list of HQs
            {
                Console.WriteLine(Unit.unitName + ", HQ, " + Unit.unitCost + " Power Level");
            }
            string hqselected = Console.ReadLine();
            hqselected.ToLower();

            if (hqselected == "gravis captain")
            {
                RosterList.Add(new Unit("Gravis Captain", "hq", 7)); //adds to a secondary list
                Console.WriteLine("Gravis Captain Selected");
            }
            if (hqselected == "lieutenent")
            {
                UnitList.Add(new Unit("Lieutenent", "hq", 5));
                Console.WriteLine("Lieutenent Selected");
            }
            if (hqselected == "mephiston")
            {
                RosterList.Add(new Unit("Mephiston", "hq", 8));
                Console.WriteLine("Mephiston Selected");
            }
            if (hqselected == "librarian")
            {
                RosterList.Add(new Unit("Librarian", "hq", 6));
                Console.WriteLine("Librarian Selected");
            }

            if (hqselected == "librarian dreadnought")
            {
                RosterList.Add(new Unit("Librarian Dreadnought", "hq", 9));
                Console.WriteLine("Librarian Dreadnought Selected");
            }

        }

        public static void troopSelector()
        {

            foreach (var Unit in UnitList.FindAll(x => x.unitType == "troop"))
            {
                Console.WriteLine(Unit.unitName + ", Troop, " + Unit.unitCost + " Power Level");
            }

            string troopSelected = Console.ReadLine();
            troopSelected.ToLower();

            if (troopSelected == "scouts")
            {
                RosterList.Add(new Unit("Scouts", "troop", 4));
                Console.WriteLine("Scouts Selected");
            }

            if (troopSelected == "tactical squad")
            {
                RosterList.Add(new Unit("Tactical Squad", "troop", 9));
                Console.WriteLine("Tactical Squad Selected");

            }

            if (troopSelected == "intercessors")
            {
                RosterList.Add(new Unit("Intercessors", "troop", 10));
                Console.WriteLine("intercessor Squad Selected");
            }



        }

        public static void eliteSelector()
        {
            foreach (var Unit in UnitList.FindAll(x => x.unitType == "elite"))
            {
                Console.WriteLine(Unit.unitName + ", Elite, " + Unit.unitCost + " Power Level");
            }
        }

        public static void faSelector()
        {
            foreach (var Unit in UnitList.FindAll(x => x.unitType == "fast"))
            {
                Console.WriteLine(Unit.unitName + ", Fast, " + Unit.unitCost + " Power Level");
            }
        }



        public static void rosterBuilder()
        {


            if (ForceOrg.forceType == "patrol" && rosterCounter == 0)
            {
                //start of loop at 0
                while (rosterCounter == 0)
                {

                    if (hqCounter == 0)//pick an hq choice
                    {
                        hqCounter++;
                        Console.WriteLine("Select 1 to 2 HQ choices from the Following List");
                        hqSelector();

                    }
                    Console.WriteLine("Select Another? Y/N");
                    string continueHQSelected = Console.ReadLine();//collect user input
                    continueHQSelected.ToLower();
                    if (continueHQSelected == "y")
                    {
                        Console.WriteLine("Select another HQ Choice");
                        hqCounter++;//increase the counter
                        hqSelector();//select another hq
                        rosterCounter = 1;//move the loop along
                    }

                    else
                    {
                        rosterCounter = 1;//if they do not select another unit, move to the next section
                    }
                }

                rosterQuery();//print the current roster

                while (rosterCounter == 1)
                {
                    if (troopCounter == 0)
                    {
                        Console.WriteLine("select 1 to 3 choices from the following list");
                        troopSelector();
                        troopCounter++;
                        Console.WriteLine("Select Another? Y/N");
                        string continuetroopSelected = Console.ReadLine();
                        continuetroopSelected.ToLower();
                        if (continuetroopSelected == "y")
                        {
                            rosterQuery();
                            Console.WriteLine("select 1 to 2 choices from the following list");
                            troopSelector();
                            troopCounter++;
                            Console.WriteLine("Select Another? Y/N");
                            continuetroopSelected = Console.ReadLine();
                            if (continuetroopSelected == "y")
                            {
                                rosterQuery();
                                Console.WriteLine("select a choice from the following list");
                                troopSelector();
                                troopCounter++;

                            }
                            else
                            {
                                rosterCounter = 2; //move the roster builder along
                            }

                        }
                        else
                        {
                            rosterCounter = 2;  //move the roster builder along
                        }

                    }
                    else
                    {
                        rosterCounter = 2;  //move the roster builder along
                    }
                }


            }


        }

    }
}

    

