using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory;
using System.IO;
using System.Threading;

namespace TextBasedAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game theGame = new Game();
            theGame.reset();

            try
            {
                //TO THROW EXCEPTION PRESS Q WHILE GAME STARTS
                theGame.StartGame();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            while (theGame.getPlaying() == true)
            {
                theGame.checkIfValid(Console.ReadLine().ToUpper());
            }
        }
    }

    public class Game
    {
        bool m_Playing = true;
        Location m_Location = new Location();

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
                }
            }

        public void StartGame()
        {
            Console.WriteLine("Fail Corp Presents....");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            ConsoleKeyInfo checker;

            checker = Console.ReadKey(true);
            if (checker.Key == ConsoleKey.Q)
            {
                throw new ArgumentNullException("Exception: ", "Don't hit keys while the game is starting!");
            }

            System.Threading.Thread.Sleep(2000);

            checker = Console.ReadKey(true);
            if (checker.Key == ConsoleKey.Q)
            {
                throw new ArgumentNullException("Exception: ", "Don't hit keys while the game is starting!");
            }

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

            
            checker = Console.ReadKey(true);
            if (checker.Key == ConsoleKey.Q)
            {
                 throw new ArgumentNullException("Exception: ", "Don't hit keys while the game is starting!");
            }

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Made by Joel Cright, Nikolai Morin Cull, Andy Lovett, and Greg Coghill");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();

            checker = Console.ReadKey(true);
            if (checker.Key == ConsoleKey.Q)
            {
                throw new ArgumentNullException("Exception: ", "Don't hit keys while the game is starting!");
            }

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
        bool pissedSelf = false;
        bool checkedBasement = false;
        delegate double GetTimeDelegate();

        public delegate bool QTE(int input);

        public void reset()
        {
            m_Location = string.Empty;
            inventory.reset();
            pissedSelf = false;
            checkedBasement = false;
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
                case "INVENTORY":
                    inventory.printInventory();
                    break;

                case "CASTLE":
                    Castle();
                    break;

                case "DIE":
                    gameOver();
                    break;

                case "TOWN":
                    Town();
                    break;

                case "FIELD":
                    Field();
                    break;

                default:
                    Console.WriteLine("Does not compute");
                    break;
            }
        }

        private void Field()
        {
            setLocation("FIELD");
            
            while (getLocation() == "FIELD")
            {
                Console.Clear();
                Console.WriteLine("As you approach the field you take a deep breath, the fresh air ");
                Console.WriteLine("is relaxing and reminds you of home. The field is covered in daisies, ");
                Console.WriteLine("dandy lions and other miscellaneous flowers. Insects roam the tops of ");
                Console.WriteLine("flowers pollinating, while dragon flies go through their ranks. It is ");
                Console.WriteLine("quite peaceful so you stand and relish in the harmonious atmoshoere. ");
                Console.WriteLine("As you come back to reality you are unsure of the time lost and decide ");
                Console.WriteLine("it's time to continue your quest. You gaze across the field. ");
                Console.WriteLine("Looking across the field, you can see a paths leading East, South and West.");
                Console.WriteLine("To the north is a town,\nto the east lies the RIVER,\nto the south, the MILL,\nand to the west is the FOREST.\n");

                Console.WriteLine("What do you choose to do?\n");

                Console.WriteLine("Go to the TOWN");
                Console.WriteLine("Go to the RIVER.");
                Console.WriteLine("Go to the MILL.");
                Console.WriteLine("Go to the FOREST.");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "TOWN":
                    case "GO TO TOWN":
                    case "GO TO THE TOWN":
                        Town();
                        break;

                    case "RIVER":
                    case "GO TO RIVER":
                    case "GO TO THE RIVER":
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
                            Console.WriteLine("You look around and see To the north is a town,\nto the east lies the RIVER,\nto the south, the MILL,\nand to the west is the FOREST.\n");
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

            while (getLocation() == "RIVER")
            {
                Console.Clear();
                Console.WriteLine("Walking down the path you begin to hear rushing water. As you get ");
                Console.WriteLine("closer the rushing water sounds dangerous. You come out of the woods ");
                Console.WriteLine("and you can finally see the river. The river is flowing at lethal ");
                Console.WriteLine("speed, rapids and white caps deter from trying to cross it. You see ");
                Console.WriteLine("a couple of makeshift tomb stones and this makes the river seem even ");
                Console.WriteLine("more daunting. You can see a tree with a rope that had been cut or ");
                Console.WriteLine("snapped on the other side of the river. You think to yourself \"A ");
                Console.WriteLine(" ROPE would be quite handy right now.\".");

                Console.WriteLine("What do you choose to do?");

                Console.WriteLine("Go to the FIELD.");
                Console.WriteLine("Cross the RIVER.");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "CROSS THE RIVER":
                    case "RIVER":
                        //TODO: Check to see if you have the rope. If you do, you can cross. Otherwise you die.
                        Quarry();
                        break;

                    case "GO TO THE FIELD":
                    case "FIELD":
                        Field();
                        break;

                    case "CHECK INVENTORY":
                    case "INVENTORY":
                    case "CHECK":
                        inventory.printInventory();
                        break;

                    case "LOOK AROUND":
                        {
                            Console.WriteLine("You look around and see the rapids, a TREE across the");
                            Console.WriteLine("rapids in front on you and the field behind you.");
                        }
                        break;

                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void Quarry()
        {
            setLocation("QUARRY");

            bool pickaxe = false;
            bool menDead = false;
            
            while (getLocation() == "QUARRY")
            {
                Console.Clear();

                Console.WriteLine("You arrive at the quarry. It is very rocky. You see to quarry workers playing with some rocks, and a man standing over a pulley.\n There is a pickaxe on the ground");

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
                            if (menDead == false)
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
                            }
                            else
                            {
                                Console.WriteLine("The man has left, so you can't really speak to him");
                            }
                            break;
                            
                        }
                    case "SEARCH ROCKS":
                    case "ROCKS":
                        {
                            Console.WriteLine("You search through a pile of rocks. \nFoolishly, you disrupt a much larger pile, which is actually a small part\n of an even bigger pile. They tumble onto you, crushing you.");
                            System.Threading.Thread.Sleep(3000);
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
                            System.Threading.Thread.Sleep(4000);
                            Console.Clear();
                            Field();
                            break;
                        }
                    case "CHECK INVENTORY":
                        inventory.printInventory();
                        break;

                    case "LOOK AROUND":
                        {
                            Console.WriteLine("You look around and see some workers playing with");
                            Console.WriteLine("some rocks and a man by a pulley.");
                        }
                        break;

                    default:
                        Console.WriteLine("Thy does not compute. Try again");
                        break;
                }
            }
        }

        private void Mill()
        {
            setLocation("MILL");

            bool chestOpened = false;

            while (getLocation() == "MILL")
            {
                Console.Clear();
                Console.WriteLine("A path from the field leads into a thin lining of trees. Behind the trees ");
                Console.WriteLine("you see an old MILL factory, it is very frail from wheather and time. you ");
                Console.WriteLine("walk to the old door that is barely hanging on to it's hinges, and slowly ");
                Console.WriteLine("push it open. The door opens half way then falls flat on the ground making ");
                Console.WriteLine("a loud BANG! Dust fills the air, but settles quickly. There is some old ");
                Console.WriteLine("equipment scattered about, and some remains of animals. There is an intact ");
                Console.WriteLine("door that leads to the BASEMENT to your left and a CHEST to your right.\n");

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
                        Field();
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
                                Console.WriteLine("A MANEATER was hiding in the CHEST, waiting to eat you. It smells the urine, gets out of the chest leaves the MILL as fast as it can.");
                                Console.WriteLine("You find a rope in the CHEST and add it to your inventory\n");
                                inventory.addToInventory("Rope");
                            }
                        }
                        break;

                    case "LOOK AROUND":
                        {
                            Console.Clear();
                            if (checkedBasement == false)
                            {
                                Console.WriteLine("You look around the MILL and see a door that leads to the BASEMENT \nand a CHEST to your left.\n");
                                if (chestOpened == true)
                                {
                                    Console.WriteLine("The CHEST has already been opened.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You look around the MILL and a CHEST to your left.\n");
                                if (chestOpened == true)
                                {
                                    Console.WriteLine("The CHEST has already been opened.\n");
                                }
                            }
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
            GetTimeDelegate getTimeDelegate = new GetTimeDelegate(temp.getTime);

            DateTime StartTime = DateTime.Now;

            while (getLocation() == "FOREST_MAZE")
            {
                temp.Show_Left(StartTime);

                if (getTimeDelegate() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("You get lost in the forest, and starve to death slowly over the next several days.");
                    Thread.Sleep(3000);
                    setLocation(string.Empty);
                    gameOver();
                }

                Console.Clear();
                temp.Show_Left(StartTime);
                Console.WriteLine("Everything looks the same. Any direction seems as good as the last. Which way would you like to go?");
                switch (Console.ReadLine().ToUpper())
                {
                    case "EAST":
                        if (posXForestMaze == 0 && posYForestMaze == 0)
                        {
                            Forest();
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

            while (getLocation() == "FOREST")
            {
                Console.Clear();
                Console.WriteLine("The FOREST is dark and crawling with danger. There is a small narrow ");
                Console.WriteLine("path leading into the arbour of death. As you enter, you hear something ");
                Console.WriteLine("scamper across the root riden ground ten feet in front of you, but you ");
                Console.WriteLine("cannot see what is was as it is dark as shit. You continue your trek ");
                Console.WriteLine("into the woods when you come across an opening. A small field of short ");
                Console.WriteLine("grass and blue sky over head from the lack of trees.\n");

                Console.WriteLine("What do you choose to do?");
                Console.WriteLine("Go to the FIELD.");
                Console.WriteLine("Enter the Forest");
                Console.WriteLine("Look around.");
                Console.WriteLine("Check Inventory.");

                switch (Console.ReadLine().ToUpper())
                {
                    case "FIELD":
                    case "GO TO FIELD":
                    case "GO TO THE FIELD":
                        Field();
                        break;

                    case "ENTER THE FOREST":
                    case "FOREST":
                        {
                            ForestMaze();
                            break;
                        }

                    case "LOOK AROUND":
                    case "LOOK":
                        {
                            Console.WriteLine("You are in a Forest.\n");
                        }
                        break;

                    case "CHECK INVENTORY":
                    case "CHECK":
                    case "INVENTORY":
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

            while (getLocation() == "TOWN")
            {

                Console.Clear();
                Console.WriteLine("You enter the town and the smell of baked goods and leather assult ");
                Console.WriteLine("your nostrils. The pleasant and familiar smell relaxes you and calms ");
                Console.WriteLine("you. The market is packed with people at every shop and commotion fills ");
                Console.WriteLine("air. To your left is the BLACKSMITH's, to your right is the TAVERN and ");
                Console.WriteLine("in front of you lies the gates to the CASTLE.");

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
                    case "TAVERN":
                        Tavern();
                        break;

                    case "GO TO THE CASTLE":
                    case "CASTLE":
                        Castle();
                        break;

                    case "GO TO THE FIELD":
                    case "FIELD":
                        Field();
                        break;

                    case "LOOK AROUND":
                        Console.WriteLine("You look around and see plenty of shops with baked goods,");
                        Console.WriteLine("a lot of people, a BLACKSMITH's and a TAVERN.");
                        break;

                    case "CHECK INVENTORY":
                    case "CHECK":
                    case "INVENTORY":
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
            
            while (getLocation() == "BLACKSMITH")
            {
                Console.Clear();
                Console.WriteLine("You walk through the town and approach the BLACKSMITH's corner, the smell ");
                Console.WriteLine("of hot metal and smoke destroy the previous smell of baked goods from your ");
                Console.WriteLine("nostrils. You walk up to the BLACKSMITH and he glares at you with his one ");
                Console.WriteLine("eye, the other eye is covered with an eye patch from a recent accident.");
                Console.WriteLine("The BLACKSMITH grumbly asks you what you want.\n");

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

            while (getLocation() == "TAVERN")
            {
                Console.Clear();
                Console.WriteLine("You enter the tavern. The smell of mead and testosterone blankets the air.");
                Console.WriteLine("You look around and see plenty of patrons and wenches all about the tavern.");
                Console.WriteLine("You notice a large burley man, of mismatched proportions. He has tiny, thin");
                Console.WriteLine("legs and arms the size of barrels, he is leaning at the bar, talking to the");
                Console.WriteLine("bar tender. The Large man notices you have come in and gives you a look.");
                Console.WriteLine("The look is a typical \"I will fight you\" look.");

                Console.WriteLine("What will you do?\n");
                
                Console.WriteLine("Fight Man");
                Console.WriteLine("Talk to Man");
                Console.WriteLine("Drink with Man");
                Console.WriteLine("Leave");

                switch (Console.ReadLine().ToUpper())
                {
                    case "FIGHT":
                    case "FIGHT MAN":
                        {
                            Console.WriteLine("You point to the man and challenge his manliness. He immediately gets up,\nbrandishes a large axe, and removes your head from your shoulders.");
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

                    case "LOOK AROUND":
                        Console.WriteLine("You look around and see a large man at the bar, ");
                        Console.WriteLine("a lot of people, a BLACKSMITH's and a TAVERN.");
                        break;

                    case "CHECK INVENTORY":
                        Console.Clear();
                        inventory.printInventory();
                        break;    

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

            while (getLocation() == "CASTLE")
            {
                Console.Clear();
                Console.WriteLine("You unlock the gates and they open slow, but steadily. You walk up to the castle");
                Console.WriteLine("door and knock using the skull door knocker. You can hear the sound echoing ");
                Console.WriteLine("behind the door. The door suddenly swings open and a cold wind blows past you ");
                Console.WriteLine("from inside. The wind is cold and smells of rotton corpses. You muster the ");
                Console.WriteLine("courage and enter the castle. When you enter you can see the main hall and the ");
                Console.WriteLine("dusty dinning table, indicating the lack of use for a long period of time. ");
                Console.WriteLine("Suddenly a shriek coming from up stairs startles you. You sprint up the stairs and");
                Console.WriteLine("you see a door with a light source coming from the bottom of the door. You run to ");
                Console.WriteLine("the door and barge in. You seethe DEMON from the beginning of the game. It ");
                Console.WriteLine("smirkingly glares at you as if it was expecting you.");
                Console.WriteLine("== The demon is preparing an attack! Press the Q button to attack him first!");

                System.Threading.Thread.Sleep(4000);
                string input = Console.ReadLine();

                QTEClass myQTE = new QTEClass();
                QTE event1 = new QTE(myQTE.event1);

                for (int i = 0; i < 100000000; i++)
                {
                    do
                    {
                        while (!Console.KeyAvailable)
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

                            if (i == 99999999)
                            {
                                gameOver();
                                break;
                            }
                        }
                    } while (Console.ReadKey(true).Key != ConsoleKey.Q);

                    break;
                }
            }
            gameWin();
        }

        private void gameWin()
        {
            setLocation(string.Empty);

            Console.Clear();
            Console.WriteLine("You have defeated the DEMON and rescued the princess from her grizzly fate. ");
            Console.WriteLine("YAY!");
            Console.WriteLine("          _______                     _________ _       ");
            Console.WriteLine("|\\     /|(  ___  )|\\     /|  |\\     /|\\__   __/( (    /|");
            Console.WriteLine("( \\   / )| (   ) || )   ( |  | )   ( |   ) (   |  \\  ( |");
            Console.WriteLine(" \\ (_) / | |   | || |   | |  | | _ | |   | |   |   \\ | |");
            Console.WriteLine("  \\   /  | |   | || |   | |  | |( )| |   | |   | (\\ \\) |");
            Console.WriteLine("   ) (   | |   | || |   | |  | || || |   | |   | | \\   |");
            Console.WriteLine("   | |   | (___) || (___) |  | () () |___) (___| )  \\  |");
            Console.WriteLine("   \\_/   (_______)(_______)  (_______)\\_______/|/    )_)");

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
            setLocation(string.Empty);
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
            Town();
        }
    }

    public class Countdown
    {
        TimeSpan m_Left;

        public void Show_Left(DateTime dt)
        {
            TimeSpan duration = new TimeSpan(0, 0, 30);
            TimeSpan ts = DateTime.Now - dt;
            m_Left = duration - ts;
            Console.WriteLine("[{0:00}:{1:00}:{2:00}]", m_Left.Hours, m_Left.Minutes, m_Left.Seconds);
        }

        public void Times_up(object thread)
        {
            Thread t = (Thread)thread;
            Console.WriteLine("\nTime's Up!");
            t.Abort();
        }

        public double getTime()
        {
            return m_Left.TotalMilliseconds;
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
}

