using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory;
using System.IO;
using System.Threading;

/*
TODO:
 * Replace all lower case cases with upper case
 * Add a check inventory and look around case to each location
 * Add a default case to each location
 * QTE fix, it doesn't work or the player doesn't know when it works
 * Get the countdown to work
 
 *TODO FOR EVERYONE:
 * Get a timesheet ( ie "I did this" ) from each member to hand in with assignment

TODO AFTER GAME IS DONE:
 * Add comments for Tony showing examples of what he's looking for ( ie the requirements for the assignment )
 * Add a map/location logic function to replace all the ifs and switches?
 * Check all code paths for breaks/bugs
*/
namespace TextBasedAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game theGame = new Game();
            theGame.reset();            

            //theGame.StartGame();

            while (theGame.getPlaying() == true)
            {
                theGame.checkIfValid(Console.ReadLine().ToUpper());   
            }
        }
    }

    public delegate bool QTE(int input);

    public class Game
    {
        bool m_Playing = true;
        Location m_Location = new Location();
        Map.Map map = new Map.Map();

        string currentLocation = string.Empty;

        public void reset()
        {
            m_Playing = true;
            m_Location.reset();
        }

        private void setPlaying(bool playing)
        {
            m_Playing = playing;
        }

        public bool getPlaying()
        {
            return m_Playing;
        }

        public void checkIfValid(string toCheck)
        {
            if (toCheck == "EXIT")
            {
                setPlaying(false);
                return;
            }

            if (toCheck == "RESET")
            {
                reset();
                return;
            }

            else
            {
                m_Location.whereTo(toCheck);
                //m_Location.whereTo(map.whereAreWeGoing(m_Location.getLocation(), toCheck));
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Fail Corp Presents....");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            System.Threading.Thread.Sleep(2000);

            Console.Beep(200, 400);
            Console.Beep(100, 400);
            Console.Beep(300, 900);

            Console.WriteLine(" _______  _______ _________ _ ");
            Console.WriteLine("|  ____ \\(  ___  )\\__   __/( \\");
            Console.WriteLine("| (    \\/| (   ) |   ) (   | (");
            Console.WriteLine("| (__    | (___) |   | |   | | ");
            Console.WriteLine("|  __)   |  ___  |   | |   | |");
            Console.WriteLine("| (      | (   ) |   | |   | |  ");
            Console.WriteLine("| )      | )   ( |___) (___| (____/\\");
            Console.WriteLine("|/       |/     \\|\\_______/(_______/");

            System.Threading.Thread.Sleep(500);

            Console.WriteLine(" _______           _______  _______ _________");
            Console.WriteLine("(  ___  )|\\     /|(  ____ \\(  ____ \\__   __/");
            Console.WriteLine("| (   ) || )   ( || (    \\/| (    \\/   ) (   ");
            Console.WriteLine("| |   | || |   | || (__    | (_____    | |  ");
            Console.WriteLine("| |   | || |   | ||  __)   (_____  )   | |  ");
            Console.WriteLine("| | /\\| || |   | || (            ) |   | |  ");
            Console.WriteLine("| (_\\ \\ || (___) || (____/\\/\\____) |   | |  ");
            Console.WriteLine("(____\\/_)(_______)(_______/\\_______)   )_(  ");
            Console.Beep(200, 400);
            Console.Beep(100, 400);
            Console.Beep(300, 900);

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Made by Joel Cright, Nikolai Morin Cull, Andy Lovett, and Greg Coghill");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();

            Console.Clear();
            Console.WriteLine("          Welcome to FAIL QUEST.\nThis text based adventure will test your failure awesomenessness.\n\nYou have just exited the TOWN of Shmagma, ");
            Console.WriteLine("it is a hot summer day with a nice cool wind blowing east and everything is ");
            Console.WriteLine("perfect. All of a sudden a shriek comes from the north east of your position.");
            Console.WriteLine("Quickly you spin around and witness a massive DEMON carring a princess to the ");
            Console.WriteLine("castle behind the TOWN you just left.");
            Console.WriteLine("You feel you must do what you can to save the princess from her fate,\nbut you must aquire itams to aid you on your quest.");
            Console.WriteLine("You are facing a path that leads to a beautiful FIELD of tall grass.");
            Console.WriteLine("Behind you is the TOWN of Shmagma from which you have just exited.\n");
            Console.WriteLine("What do you choose to do?");
            Console.WriteLine("Go to the TOWN.");
            Console.WriteLine("Go to the FIELD.");
            Console.WriteLine("Look around.");
            Console.WriteLine("Check Inventory.");
            Console.WriteLine("");
        }
    }

    public class Location
    {
        string m_Location = string.Empty;
        Inventory.Inventory inventory = new Inventory.Inventory();
        bool lookedAround = false;
        bool pissedSelf = false;
        bool checkedBasement = false;

        public void reset()
        {
            m_Location = string.Empty;
            inventory.reset();
        }

        private void setLocation(string location)
        {
            m_Location = location;
        }

        public string getLocation()
        {
            return m_Location;
        }

        public void whereTo(string toHere)
        {
            string action = toHere.ToUpper();
            switch (action)
            {
                case "LOOK":
                    LookAround();
                    break;

                case "TEST INV":
                    inventory.testInventory();
                    break;

                case "INVENTORY":
                    inventory.printInventory();
                    break;

                case "INV R":
                    Console.WriteLine("Remove:");
                    inventory.removeFromInventory(Console.ReadLine());
                    break;

                case "CASTLE":
                    Castle();
                    break;

                case "DIE":
                    gameOver();
                    break;

                case "MILL":
                    Mill();
                    break;

                case "TOWN":
                    Town();
                    break;

                case "BASEMENT":
                    Basement();
                    break;


                case "QUARRY":
                    Quarry();
                    break;

                case "BLACKSMITH":
                    Blacksmith();
                    break;

                case "FIELD":
                    FieldOfShit();
                    break;

                case "RIVER":
                    River();
                    break;

                case "FOREST":
                    Forest();
                    break;

                default:
                    Console.WriteLine("Does not compute");
                    break;
            }
        }

        private void LookAround()
        {
            if (lookedAround == false)
            {
                Console.WriteLine("You look around, and find a rope on the ground nearby!");
                foreach (string inventoryItem in inventory.getInventory())
                {
                    if (inventoryItem == null)
                    {
                        inventory.addToInventory("Rope");
                        lookedAround = true;
                        return;
                    }

                    else if (inventoryItem == "EndOfInv")
                    {
                        inventory.inventoryFull("Rope");
                        lookedAround = true;
                        return;
                    }
                }
            }

            else
            {
                Console.WriteLine("You've already looked around. There is nothing interesting anymore");
            }
        }

        private void Field()
        {
            setLocation("FIELD");

            Console.Clear();
            Console.WriteLine("As you approach the field you take a deep breath, the fresh air ");
            Console.WriteLine("is relaxing and reminds you of home. The field is covered in daisies, ");
            Console.WriteLine("dandy lions and other miscellaneous flowers. Insects roam the tops of ");
            Console.WriteLine("flowers pollinating, while dragon flies go through their ranks. It is ");
            Console.WriteLine("quite peaceful so you stand and relish in the harmonious atmoshoere. ");
            Console.WriteLine("As you come back to reality you are unsure of the time lost and decide ");
            Console.WriteLine("it's time to continue your quest. You gaze across the field. ");
            Console.WriteLine("Looking across the field, you can see a paths leading East, South and West.");
            Console.WriteLine("To the east lies the RIVER,\nto the south, the MILL,\nand to the west is the FOREST.\n");
            Console.WriteLine("What do you choose to do?");
            Console.WriteLine("Go to the RIVER.");
            Console.WriteLine("Go to the MILL.");
            Console.WriteLine("Go to the FOREST.");
            Console.WriteLine("Look around.");
            Console.WriteLine("Check Inventory.");
        }

        private void FieldOfShit()
        {
            setLocation("FIELD");

            Console.Clear();
            Console.WriteLine("As you approach the field you notice a fairly recognizable smell");
            Console.WriteLine("You realize it is the smell of feces, but you are unable to ");
            Console.WriteLine("Identify the origins of what it came from.");
            Console.WriteLine("To the east lies the RIVER,\nto the south, the MILL,\nand to the west is the FOREST.\n");

            while (getLocation() == "FIELD")
            {
                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the RIVER.");
                Console.WriteLine("Go to the MILL.");
                Console.WriteLine("Go to the FOREST.");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "RIVER":
                    case "GO TO RIVER":
                    case "GO TO THE RIVER":
                        //TODO: Check to see if you have the rope. If you do, you can cross. Otherwise you die.
                        River();
                        break;

                    case "MILL":
                    case "GO TO MILL":
                    case "GO TO THE MILL":
                        Mill();
                        break;

                    case "FOREST":
                    case "GO TO FOREST":
                    case "GO TO THE FOREST":
                        Forest();
                        break;


                    case "LOOK AROUND":
                        {
                            Console.WriteLine("You look around and see to the east lies the RIVER,\nto the south, the MILL,\nand to the west is the FOREST.\n");
                        }
                        break;

                    case "CHECK INVENTORY":
                        inventory.printInventory();
                        break;

                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void River()
        {
            setLocation("RIVER");

            Console.Clear();
            Console.WriteLine("You approach the river with caution as the rapids could easily pull you");
            Console.WriteLine(" in and make short work of you. A ROPE could be quite handy right now...\n");
           

            while (getLocation() == "RIVER")
            {
                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the FIELD.");
                Console.WriteLine("Cross the RIVER.");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "CROSS THE RIVER":
                        //TODO: Check to see if you have the rope. If you do, you can cross. Otherwise you die.
                        Quarry();
                        break;

                    case "Go to the FIELD":
                        FieldOfShit();
                        break;

                    case "Check Inventory":
                        inventory.printInventory();
                        break;
                }
            }
        }

        private void Quarry()
        {
            setLocation("QUARRY");

            bool pickaxe = false;
            bool menDead = false;
            Console.Clear();
            Console.WriteLine("You arrive at the quarry. It is very rocky. You see to quarry workers playing with some rocks, and a man standing over a pulley.\n There is a pickaxe on the ground");

            while (getLocation() == "QUARRY")
            {
                Console.WriteLine("\nWhat will you do?\n");

                Console.WriteLine("Talk to Workers");
                Console.WriteLine("Talk to Man");
                Console.WriteLine("Search Rocks");
                Console.WriteLine("Take PICKAXE");
                Console.WriteLine("Leave");
                
                switch (Console.ReadLine().ToUpper())
                {
                    case "TALK TO WORKERS":
                    case "WORKERS":
                        {
                            if (menDead == true)
                            {
                                Console.WriteLine("The men are dead. This makes it difficult to talk to them.");
                            }
                            else
                            {
                                Console.WriteLine("You approach the working men.\nThey ignore you and maintain their focus on the rocks.");
                            }
                            break;
                        }

                    case "TALK TO MAN":
                    case "MAN":
                        {
                            if (pickaxe == true)
                            {
                                Console.WriteLine("You approach the strange man...");
                                Console.WriteLine("He sees the pickaxe you are carrying and panics.\n He cuts the pulley and runs,dropping a hammer as he flees.\nThe pulley drops a boudler on the working men, crushing them.\nYou take the hammer");
                                pickaxe = false;
                                menDead = true;
                            }
                            else
                            {
                                Console.WriteLine("You approach the strange man...");
                                Console.WriteLine("He looks over your puny form and chuckles to himself. \nYou are no threat to him. He ignores you.");
                            }
                            break;
                        }
                    case "SEARCH ROCKS":
                    case "ROCKS":
                        {
                            Console.WriteLine("You search through a pile of rocks. \nFoolishly, you disrupt a much larger pile, which is actually a small part\n of an even bigger pile. They tumble onto you, crushing you.");
                            gameOver();
                            break;
                        }

                    case "TAKE PICKAXE":
                    case "PICKAXE":
                        {
                            Console.WriteLine("You take the pickaxe. It is rather hefty, considering you are so weak and puny.");
                            pickaxe = true;
                            break;
                        }

                    case "LEAVE":
                        {
                            Console.WriteLine("You exit the quarry. On your way back across the river, you lose your rope.");
                            Console.Clear();
                            break;
                        }
                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void Mill()
        {
            setLocation("MILL");

            Console.Clear();
            Console.WriteLine("A path from the field leads into a thin lining of trees. Behind the trees ");
            Console.WriteLine("you see an old MILL factory, it is very frail from wheather and time. you ");
            Console.WriteLine("walk to the old door that is barely hanging on to it's hinges, and slowly ");
            Console.WriteLine("push it open. The door opens half way then falls flat on the ground making ");
            Console.WriteLine("a loud BANG! Dust fills the air, but settles quickly. There is some old ");
            Console.WriteLine("equipment scattered about, and some remains of animals. There is an intact ");
            Console.WriteLine("door that leads to the BASEMENT to your left and a CHEST to your right.\n");

            bool chestOpened = false;

            while (getLocation() == "MILL")
            {

                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the FIELD.");
                if (checkedBasement == false)
                {
                    Console.WriteLine("Go to the BASEMENT.");
                }
                if (chestOpened == false)
                {
                    Console.WriteLine("Open the CHEST.");
                }
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");

                switch (Console.ReadLine().ToUpper())
                {
                    case "FIELD":
                    case "GO TO FIELD":
                    case "GO TO THE FIELD":
                        FieldOfShit();
                        break;

                    case "BASEMENT":
                    case "GO TO BASEMENT":
                    case "GO TO THE BASEMENT":
                        Basement();
                        break;

                    case "CHEST":
                    case "OPEN CHEST":
                    case "OPEN THE CHEST":
                        {
                            chestOpened = true;
                            if (pissedSelf == false)
                            {
                                Console.Clear();
                                Console.WriteLine("You open the Chest and a MANEATER comes out and tries to eat you! \nYou have seconds left what do you do?\n");
                                bool free = false;
                                int success = 0;
                                int failure = 0;

                                while (free != true)
                                {
                                    string action = Console.ReadLine();
                                    if (action.ToUpper() == "STRUGGLE")
                                    {
                                        Console.WriteLine("You struggle to get free, the MANEATER weakens!");
                                        success++;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The MANEATER continues trying to eat you!");
                                        failure++;
                                    }

                                    if (success >= 7)
                                    {
                                        Console.WriteLine("SUCCESS! You manage to get free of the MANEATER and kill it!");
                                        free = true;
                                        Console.WriteLine("You find a rope in the CHEST and add it to your inventory");
                                        inventory.addToInventory("Rope");
                                    }
                                    else if (failure >= 5)
                                    {
                                        Console.WriteLine("The MANEATER has eaten you, you are dead.");
                                        gameOver();
                                        break;
                                    }
                                }
                            }
                            else if (pissedSelf == true)
                            {
                                Console.Clear();
                                Console.WriteLine("The MANEATER smells the urine, gets out of the chest\n leaves the MILL as fast as it can.");
                                Console.WriteLine("You find a rope in the CHEST and add it to your inventory\n");
                                inventory.addToInventory("Rope");
                            }
                        }
                        break;

                    case "LOOK AROUND":
                        {
                            Console.Clear();
                            Console.WriteLine("You look around the MILL and see a door that leads to the BASEMENT \nand a CHEST to your left.\n");
                        }
                        break;

                    case "CHECK INVENTORY":
                        inventory.printInventory();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void ForestMaze()
        {
            setLocation("FOREST_MAZE");

            int posXForestMaze = 0;
            int posYForestMaze = 0;
            Countdown temp = new Countdown();

            DateTime StartTime = DateTime.Now;
            Thread forest = new Thread(ForestMaze);
            Timer timer = new Timer(temp.Times_up, forest, 120000, Timeout.Infinite);
            forest.Start(StartTime);
            forest.Join();
            timer.Dispose();

            //CountdownEvent countDown = new CountdownEvent(10);

            //CountdownTimer timerCountdown = new CountdownTimer(10000);

            while (getLocation() == "FOREST_MAZE")
            {
                
                Console.Clear();
                temp.Show_Left(StartTime);
                Console.WriteLine("Everything looks the same. Any direction seems as good as the last. Which way would you like to go?");
                switch (Console.ReadLine().ToUpper())
                {
                    case "EAST":
                        if (posXForestMaze == 0 && posYForestMaze == 0)
                        {
                            FieldOfShit();
                        }

                        else
                        {
                            posXForestMaze--;
                            if (posXForestMaze < 0) posXForestMaze = 0;
                        }

                        break;

                    case "NORTH":
                        posYForestMaze++;
                        Console.WriteLine("You aren't sure where you are. Let's try a different direction");
                        break;

                    case "WEST":
                        posXForestMaze++;
                        Console.WriteLine("You aren't sure where you are. Let's try a different direction");
                        break;

                    case "SOUTH":
                        posYForestMaze--;
                        Console.WriteLine("You aren't sure where you are. Let's try a different direction");
                        break;
                }
            }
        }

        private void Forest()
        {
            setLocation("FOREST");

            Console.Clear();
            Console.WriteLine("The FOREST is dark and crawling with danger. There is a small narrow ");
            Console.WriteLine("path leading into the arbour of death. As you enter, you hear something ");
            Console.WriteLine("scamper across the root riden ground ten feet in front of you, but you ");
            Console.WriteLine("cannot see what is was as it is dark as shit. You continue your trek ");
            Console.WriteLine("into the woods when you come across an opening. A small field of short ");
            Console.WriteLine("grass and blue sky over head from the lack of trees.\n");

            while (getLocation() == "FOREST")
            {
                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the FIELD.");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");

                switch (Console.ReadLine().ToUpper())
                {
                    case "FIELD":
                    case "GO TO FIELD":
                    case "GO TO THE FIELD":
                        FieldOfShit();
                        break;

                    case "LOOK AROUND":
                        {
                            Console.WriteLine("You are in a Forest.\n");
                        }
                        break;

                    case "CHECK INVENTORY":
                        inventory.printInventory();
                        break;

                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void Basement()
        {
            setLocation("BASEMENT");
            
            Console.Clear();
            Console.WriteLine("You open the door and head down the old rickety stairs to the BASEMENT.");
            Console.WriteLine("The further down you go the less you can see until nothing is visible.");
            Console.WriteLine("When you reach the last step you hear loud laboured breathing. The ");
            Console.WriteLine("breathing becomes louder and louder until it sounds like it is directly ");
            Console.WriteLine("in front of you. All of a sudden you hear a deafening hiss, then big red ");
            Console.WriteLine("eyes appear in font of you. Out of complete shock you wet your pants, shriek ");
            Console.WriteLine("and run back up the stairs and slam the door behind you. You can hear the ");
            Console.WriteLine("stairs crumble and fall apart behind the door. ");
            Console.WriteLine("This calms you a little, but now you have wet pants and reek of urine.\n");

            setLocation("MILL");

            pissedSelf = true;
            checkedBasement = true;
        }

        private void Town()
        {
            setLocation("TOWN");

            Console.Clear();
            Console.WriteLine("You enter the town and the smell of baked goods and leather assult ");
            Console.WriteLine("your nostrils. The pleasant and familiar smell relaxes you and calms ");
            Console.WriteLine("you. The market is packed with people at every shop and commotion fills ");
            Console.WriteLine("air. To your left is the BLACKSMITH's, to your right is the TAVERN and ");
            Console.WriteLine("in front of you lies the gates to the CASTLE.");

            while (getLocation() == "TOWN")
            {
                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the BLACKSMITH.");
                Console.WriteLine("Go to the TAVERN.");
                Console.WriteLine("Go to the CASTLE.");
                Console.WriteLine("Go to the FIELD");
                Console.WriteLine("Check Inventory.");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "GO TO THE BLACKSMITH":
                    case "BLACKSMITH":
                        Blacksmith();
                        break;

                    case "GO TO THE TAVERN":
                        Tavern();
                        break;

                    case "GO TO THE CASTLE":               
                    case "CASTLE":
                        Castle();
                        break;

                    case "Go to the FIELD":
                        FieldOfShit();
                        break;

                    case "CHECK INVENTORY":
                        Console.Clear();
                        inventory.printInventory();
                        break;                        

                    default:
                        {
                            Console.WriteLine("That didn't work at all! Maybe check dat grammar?");
                            break;
                        }
                }
            }
        }

        private void Blacksmith()
        {
            setLocation("BLACKSMITH");

            bool gotGem = false;
            bool angryBlacksmith = true;
            Console.Clear();
            Console.WriteLine("You walk through the town and approach the BLACKSMITH's corner, the smell ");
            Console.WriteLine("of hot metal and smoke destroy the previous smell of baked goods from your ");
            Console.WriteLine("nostrils. You walk up to the BLACKSMITH and he glares at you with his one ");
            Console.WriteLine("eye, the other eye is covered with an eye patch from a recent accident.");
            Console.WriteLine("The BLACKSMITH grumbly asks you what you want.\n");
            while (getLocation() == "BLACKSMITH")
            {
                Console.WriteLine("What will you do?\n");

                Console.WriteLine("Tell the BLACKSMITH you don't like his face");
                Console.WriteLine("Talk to Blacksmith");
                Console.WriteLine("Look around");
                Console.WriteLine("Check INVENTORY");
                Console.WriteLine("Go to the TOWN");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {

                    //You are an idiot. Have fun dying
                    case "TELL THE BLACKSMITH YOU DON'T LIKE HIS FACE":
                    case "TELL THE BLACKSMITH YOU DONT LIKE HIS FACE":
                    case "FACE":
                    case "TELL BLACKSMITH":
                    case "I DON'T LIKE YOUR FACE":
                    case "I DONT LIKE YOUR FACE":
                        {
                            Console.Clear();
                            Console.WriteLine("The already miserable blacksmith, insulted by your words, is clearly not happy.\n He hurls his white-hot hammer across the room, and the hammer-head collides with your forehead, cracking your head wide open. ");
                            System.Threading.Thread.Sleep(4000);
                            gameOver();
                            break;
                        }
                    //Got the gem? He lets you keep it
                    case "TALK TO BLACKSMITH":
                    //Got the gem? He lets you keep it
                    case "TALK":
                    case "BLACKSMITH":
                        {
                            Console.WriteLine("You approach the blacksmith...");
                            if (gotGem == true)
                            {
                                Console.WriteLine("He notices the gem you have found, and tells you that you can have it.");
                                angryBlacksmith = false;
                            }
                            else //Don't got the gem? He doesnt care.
                            {
                                Console.WriteLine("He quickly realizes you have nothing particularly important to say, and returns his attention to his anvil.");
                            }
                            break;
                        }
       
                    //You find a gem. Its pretty
                    case "LOOK AROUND":
                    case "LOOK":
                        {
                            if (gotGem == true)
                            {
                                Console.WriteLine("You find nothing of interest");
                                Console.Clear();
                                    break;
                            }
                            else
                            {
                                Console.WriteLine("You take a look around the blacksmith's workplace.\n After rudely sifting through various piles of stuff, you find a large, shiny gemstone.\nYou take it.");
                                gotGem = true;
                                inventory.addToInventory("Gem");
                                break;
                            }
                        }
                    //You check your stuff
                    case "CHECK INVENTORY":
                    case "INVENTORY":
                        {
                            Console.Clear();
                            inventory.printInventory();
                            break;
                        }

                        //Got the gem? If you didnt talk to the blacksmith after finding it, he kills you. Otherwise you're fine
                    case "GO TO THE TOWN":
                    //Got the gem? If you didnt talk to the blacksmith after finding it, he kills you. Otherwise you're fine
                    case "TOWN":
                        {
                            if (angryBlacksmith == true)
                            {
                                Console.WriteLine("You attempt to leave with the gem in hand when the blacksmith accuses you of theivery, which you are guilty of.\n He hurls a spear across the room, impaling your weak body.");
                                System.Threading.Thread.Sleep(4000);
                                gameOver();
                                gotGem = false;

                                break;
                            }
                            else
                            {
                                Town();
                                break;
                            }
                        }

                    default:
                        {
                            Console.WriteLine("That didn't quite work. Try again");
                            break;
                        }
                }
            }
        }

        private void Tavern()
        {
            setLocation("TAVERN");

            int broseph = 0;
            //Required bools
            //TODO: Item from drunk man
            Console.WriteLine("You walk into a tavern. You see many patrons and wenches. You notice a large man at the bar\n");

            while (getLocation() == "TAVERN")
            {
                Console.WriteLine("What will you do?\n");
                Console.WriteLine("Fight Man");
                Console.WriteLine("Talk to Man");
                Console.WriteLine("Drink with Man");
                Console.WriteLine("Leave");
                Console.WriteLine(": ");

                switch (Console.ReadLine().ToUpper())
                {
                    case "FIGHT":
                    case "FIGHT MAN":
                        {
                            Console.WriteLine("You point to the man and challenge his manliness.He immediately gets up,\nbrandishes an large axe, and removes your head from your shoulders.");
                            System.Threading.Thread.Sleep(3000);
                            gameOver();
                            break;
                        }
                    case "TALK":
                    case "TALK TO MAN":
                        {
                            Console.WriteLine("You approach the man and attempt to initiate a meaningful conversation...\n");
                            if (broseph > 1)
                            {
                                Console.Beep(300, 300);
                                Console.Beep(200, 300);
                                Console.Beep(300, 800);
                                Console.WriteLine("After a few minutes of chatting about wenches and alcohol.");
                                Console.WriteLine("He then passes out and falls to the ground.\n A key falls from his pocket. You take it.");
                                //Shit happens. Aw yiss
                                break;
                            }
                            else
                            {
                                Console.WriteLine("He scoffs at your scrawny form and turns his attention to something in the room that isn't as puny as you.\n");
                                //Nothing happens. Must be more bro-like
                                break;
                            }
                        }
                    case "DRINK":
                    case "DRINK WITH MAN":
                        {
                            Console.WriteLine("You walk up to the bar and order a drink for the man with the fine,\n sculpted muscles. He gives you a heavy pat on the back and thanks you.");
                            broseph += 1;
                            //You become bros
                            break;
                        }

                    case "LEAVE":
                        {
                            Console.Clear();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Thy does not compute. Try again, fool!");
                            break;
                        }
                }
            }
        }

        private void Castle()
        {
            setLocation("CASTLE");

            Console.Clear();
            Console.WriteLine("== The demon is preparing an attack! Press the Q button to attack him first!");
            System.Threading.Thread.Sleep(4000);
            string input = Console.ReadLine();

            QTEClass myQTE = new QTEClass();

            QTE event1 = new QTE(myQTE.event1);

            for (int i = 0; i < 100000000; i++)
            {
                Console.WriteLine("Wat");
                Console.Clear();
                Console.WriteLine("       ,--.--._");
                Console.WriteLine("------'' _, \\___)");
                Console.WriteLine("        / _/____)");
                Console.WriteLine("        \\//(____)");
                Console.WriteLine("------\\     (__)");
                Console.WriteLine("       `-----''");

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("         ,--.--._");
                Console.WriteLine("--------'' _, \\___)");
                Console.WriteLine("          / _/____)");
                Console.WriteLine("          \\//(____)");
                Console.WriteLine("--------\\     (__)");
                Console.WriteLine("         `-----''");

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("             ,--.--._");
                Console.WriteLine("-----------'' _, \\___)");
                Console.WriteLine("             / _/____)");
                Console.WriteLine("             \\//(____)");
                Console.WriteLine("-----------\\     (__)");
                Console.WriteLine("            `-----''");

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("               ,--.--._");
                Console.WriteLine("-------------'' _, \\___)");
                Console.WriteLine("               / _/____)");
                Console.WriteLine("               \\//(____)");
                Console.WriteLine("-------------\\     (__)");
                Console.WriteLine("               `-----''");

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("                  ,--.--._");
                Console.WriteLine("----------------'' _, \\___)");
                Console.WriteLine("                  / _/____)");
                Console.WriteLine("                  \\//(____)");
                Console.WriteLine("----------------\\     (__)");
                Console.WriteLine("               `-----''");

                System.Threading.Thread.Sleep(200);
                Console.Clear();
                Console.WriteLine("                     ,--.--._");
                Console.WriteLine("-------------------'' _, \\___)");
                Console.WriteLine("                     / _/____)");
                Console.WriteLine("                     \\//(____)");
                Console.WriteLine("-------------------\\     (__)");
                Console.WriteLine("                  `-----''");
                ConsoleKeyInfo checker;
                checker = Console.ReadKey(true);
                if (checker.Key == ConsoleKey.Q )
                {
                    //You win/game over shit
                    return;
                }
                
                if (i == 99999999)
                {
                   gameOver();
                    break;
                }
            }

   
        }

        private void gameWin()
        {
            Console.Clear();
            Console.WriteLine("You have defeated the DEMON and rescued the princess from her grizzly fate. ");
            Console.WriteLine("YAY!");
            Console.WriteLine("          _______                     _________ _       ");
            Console.WriteLine("|\\     /|(  ___  )|\\     /|  |\\     /|\\__   __/( (    /|");
            Console.WriteLine("( \\   / )| (   ) || )   ( |  | )   ( |   ) (   |  \\  ( |");
            Console.WriteLine(" \\ (_) / | |   | || |   | |  | | _ | |   | |   |   \\ | |");
            Console.WriteLine("  \\   /  | |   | || |   | |  | |( )| |   | |   | (\\ \\) |");
            Console.WriteLine("   ) (    | |   | || |   | |  | || || |   | |   | | \\   |");
            Console.WriteLine("   | |    | (___) || (___) |  | () () |___) (___| )  \\  |");
            Console.WriteLine("   \\_/   (_______)(_______)  (_______)\\_______/|/    )_)");

            Console.WriteLine("Press any key to continue");
            System.Threading.Thread.Sleep(3000);

            bool winScreen = true;

            while (winScreen)
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                winScreen = false;
            }

            Console.Clear();
            reset();
        }

        private void gameOver()
        {
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("======= You have died =======");
            Console.WriteLine("         _,.-------.,_");
            Console.WriteLine("     ,;~'             '~;,");
            Console.WriteLine("   ,;                     ;,");
            Console.WriteLine("  ;                         ;");
            Console.WriteLine(" ,'                         ',");
            Console.WriteLine(",;                           ;,");
            Console.WriteLine("; ;      .           .      ; ;");
            Console.WriteLine("| ;   ______       ______   ; |");
            Console.WriteLine("|  `/~*     ~* . *~     *~\\'  |");
            Console.WriteLine("|  ~  ,-~~~^~, | ,~^~~~-,  ~  |");
            Console.WriteLine(" |   |        }:{        |   |");
            Console.WriteLine(" |   l       / | \\       !   |");
            Console.WriteLine(" .~  (__,.--* .^. *--.,__)  ~.");
            Console.WriteLine(" |     ---;' / | \\ `;---     |");
            Console.WriteLine("  \\__.       \\/^\\/       .__/");
            Console.WriteLine("   V| \\                 / |V");
            Console.WriteLine("    | |T~\\___!___!___/~T| |");
            Console.WriteLine("    | |`IIII_I_I_I_IIII'| |");
            Console.WriteLine("    |  \\,III I I I III,/  |");
            Console.WriteLine("     \\   `~~~~~~~~~~'    /");
            Console.WriteLine("       \\   .       .   /   ");
            Console.WriteLine("         \\.    ^    ./");
            Console.WriteLine("           ^~~~^~~~^");
            Console.Beep(300, 300);
            Console.Beep(200, 300);
            Console.Beep(100, 800);
            System.Threading.Thread.Sleep(3000);

            bool gameOverScreen = true;
            
            while (gameOverScreen)
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                gameOverScreen = false;
            }

            Console.Clear();
            reset();
        }
    }

    public class Countdown
    {
        public void Show_Left(DateTime dt)
        {
            TimeSpan duration = new TimeSpan(0, 0, 10);
            TimeSpan ts = DateTime.Now - dt;
            TimeSpan left = duration - ts;
            Console.WriteLine("[{0:00}:{1:00}:{2:00}]", left.Hours, left.Minutes, left.Seconds);
        }

        public void Times_up(object thread)
        {
            Thread t = (Thread)thread;
            Console.WriteLine("\nTime's Up!");
            //t.Abort();
        }
    }

    public class QTEClass
    {
        public QTEClass() { }

        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public bool event1(int input)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            int requiredInput = randomNumber;

            if (input == requiredInput)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public bool event2(int input)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            int requiredInput2 = randomNumber;

            if (input == requiredInput2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    //public partial class CountdownTimer
    //{
    //    Counter count = new Counter();
    //    Counter timer = new Counter();
    //    DateTime MainTimer_last_Tick = DateTime.Now;
    //    int startTime = -1;

    //    public CountdownTimer(/*int timeInMilliseconds*/)
    //    {
    //        //l_Timer_TE.Text = (int.Parse(tb_TimerLength_TE.Text)*1000).ToString();
    //        //timer.aTimer.Interval = timeInMilliseconds * 1000;
    //        //timer.aTimer.Enabled = true;
    //        //timer.aTimer.Tick += new EventHandler(TimerDone);

    //        //count.aTimer.Interval = 1000;
    //        //count.aTimer.Enabled = true;
    //        //count.aTimer.Tick += new EventHandler(TimerTick);
    //        //count.aTimer.Start();
    //        //timer.aTimer.Start();
    //        //MainTimer_last_Tick = DateTime.Now;
    //    }

    //    public void TimerDone(object source, EventArgs e)
    //    {
    //        timer.aTimer.Stop();
    //        count.aTimer.Stop();
    //        Console.WriteLine("Your timer is up");
    //    }

    //    public void TimerTick(object source, EventArgs e)
    //    {
    //        TimerUpdate();
    //    }

    //    public void TimerUpdate()
    //    {
    //        double remaining_Milliseconds = (int)(MainTimer_last_Tick.AddMilliseconds(timer.aTimer.Interval).Subtract(DateTime.Now).TotalMilliseconds);
    //        Console.WriteLine(Math.Round(remaining_Milliseconds / 1000, 0, MidpointRounding.AwayFromZero).ToString());
    //    }
    //}

    //public class Counter
    //{
    //    public System.Windows.Forms.Timer aTimer = null;

    //    public Counter()
    //    {
    //        aTimer = new System.Windows.Forms.Timer();
    //    }
    //}
}

