using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ChooseYourPath
{
    /// <summary>
    /// A simple choose your own adventure type game.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        //Declare Choice object, assign false values
        Choice userChoice = new Choice(false, false, false, "choice 1", "choice 2", "choice 3");

        //Levels Dictionary
        Dictionary<string, string[]> levelsDic = new Dictionary<string, string[]>
            {
                //starting level
                {"level_001", new string[] {"You awake to feel a hard and smooth surface below you.  It's very dark and the air is damp, but you can see light coming in from an opening in the distance.  You don't remember how you got here.  You seem to be alone...",
                    "Check your pockets",//leads to level 001a
                    "Head toward the light",//leads to level 001b
                    "Try to remember anything" }},//leads to level 001c

                //TIER 1 OF CHOICES
                //level as a result of ChoiceButton1
                {"level_001a", new string[] {"You check the pockets of your pants to find what feels like a pocket knife in your front left pocket and a lighter in your front right pocket.  There is nothing in your back pockets...",
                    "Get out your lighter",//leads to level 001aa
                    "Get out your knife",//leads to level 001ab
                    "Head toward the lighted opening" }},//leads to level 001ac

                //level as a result of ChoiceButton2
                {"level_001b", new string[] {"You stand up, feeling a little disoriented, and begin to move toward the light.  The opening appears to be the mouth of a cave.  As you get closer to the opening you can see what looks like moss covered trees just outside the opening...",
                    "Go outside",//leads to level 001ba
                    "Wait and watch for movement",//leads to level 001bb
                    "Yell \"Hello, is anyone out there?!\"" }},//leads to level 001bc

                //level as a result of ChoiceButton3
                {"level_001c", new string[] {"You close your eyes and think deeply, trying to recall any memories...  You see a flash of light in your mind, and remember a loud rumbling sound.  You remember seeing the ground around you shake...",
                    "Check your pockets",//leads to level 001ca
                    "Head toward the lighted opening",//leads to level 001cb
                    "Check the ground around you" }},//leads to level 001cc

                //TIER 2 OF CHOICES
                {"level_001aa", new string[] {"You get out your lighter.  From the feel of it, it feels like an old metal zippo lighter, and when you open it the smell of lighter fluid fumes fills your nose...",
                    "Light it",//leads to level 001aaa
                    "Throw it",//leads to level 001aab
                    "Put it back in your pocket" }},//leads to level 001aac

                {"level_001ab", new string[] {"You get out your pocket knife.  It was clipped to your pocket with a built on clip.  Probably there to keep it from falling out of your pocket.  It is a spring assisted knife, with a tension bar that allows the blade to flip out when part of the blade is pressed.  It was designed to clip in your left pocket to keep the blade from opening in your pocket...",
                    "Flip the blade out",//leads to level 001aba
                    "Clip it back in your left pocket",//leads to level 001abb
                    "Clip it in your right pocket" }},//leads to level 001abc

                {"level_001ac", new string[] {"You stand up, feeling a little disoriented, and begin to move toward the light.  The opening appears to be the mouth of a cave.  As you get closer to the opening you can see what looks like moss covered trees just outside the opening...",
                    "Go outside",//leads to level 001aca
                    "Wait and watch for movement",//leads to level 001acb
                    "Yell \"Hello, is anyone out there?!\"" }},//leads to level 001acc

                {"level_001ba", new string[] {"As you step outside, you hear partially damp leaves quietly pressed beneath your shoes.  It is probably mid day from your judgement, according to the placement of the sun in the sky.  You look behind you to notice it was indeed a cave you were in, and it's mouth was at the bottom of a sheer cliff face.  Before you, you see a dense moss covered forest stretching the distance of your range of sight...",
                    "Inspect the cliff",//leads to level 001baa
                    "Head out into the forest",//leads to level 001bab
                    "Inspect around the mouth of the cave" }},//leads to level 001bac

                {"level_001bb", new string[] {"As you wait, paying close attention and focusing your eyes the best you can, you think you see movement outside, but you are not sure.  Was that movement... or are my eyes playing tricks on me...?  The darkness around you is effecting the ability of your eyes to focus...",
                    "Go outside",//leads to level 001bba
                    "Check your pockets",//leads to level 001bbb
                    "Go to sleep" }},//leads to level 001bbc

                {"level_001bc", new string[] {"You take a deep breath, and yell as loud as you can \"Hello, is anyone out there?!\"  You here your voice echo back to you several times.  As you wait patiently for a response, you hear nothing...  not even the chirp of a bird...",
                    "choice1bc",//leads to level 001bca
                    "choice2bc",//leads to level 001bcb
                    "choice3bc" }},//leads to level 001bcc

                {"level_001ca", new string[] {"You check the pockets of your pants to find what feels like a pocket knife in your front left pocket and a lighter in your front right pocket.  There is nothing in your back pockets...",
                    "Get out your lighter",//leads to level 001caa
                    "Get out your knife",//leads to level 001cab
                    "Head toward the lighted opening" }},//leads to level 001cac

                {"level_001cb", new string[] {"You stand up, feeling a little disoriented, and begin to move toward the light.  The opening appears to be the mouth of a cave.  As you get closer to the opening you can see what looks like moss covered trees just outside the opening...",
                    "Go outside",//leads to level 001cba
                    "Wait and watch for movement",//leads to level 001cbb
                    "Yell \"Hello, is anyone out there?!\"" }},//leads to level 001cbc

                {"level_001cc", new string[] {"As you feel the ground around you, you feel a sharp sensation in your hand.  A few moments later and you don't feel so good...  The little light you can see, slowly blurs and fades to black...  You will never know what happened.  Maybe someone will find your body, if anyone else exists...",
                    "Restart",//trigger word to start entire game over
                    "Try Again",//trigger word to redo same exact level, same three choices
                    "Exit" }},//trigger word to leave program

                //TIER 3 OF CHOICES
                {"level_001aaa", new string[] {"As you strike the lighter, it lights up immediately.  The heat from the flame warms your thumb and pointer finger.  You look around and notice you are in a small, one room cave.  The walls, floor, and ceiling are solid rock.  You don't see anything to peak your interest...",
                    "Go outside",//leads to level 001aaaa
                    "Wait and watch for movement",//leads to level 001aaab
                    "Yell \"Hello, is anyone out there?!\"" }},//leads to level 001aaac

                {"level_001aba", new string[] {"Text 001aba",
                    "choice1aba",//leads to level 001abaa
                    "choice2aba",//leads to level 001abab
                    "choice3aba" }},//leads to level 001abac

                {"level_001aca", new string[] {"Text 001aca",
                    "choice1aca",//leads to level 001acaa
                    "choice2aca",//leads to level 001acab
                    "choice3aca" }},//leads to level 001acac

                {"level_001baa", new string[] {"Text 001baa",
                    "choice1baa",//leads to level 001baaa
                    "choice2baa",//leads to level 001baab
                    "choice3baa" }},//leads to level 001baac

                {"level_001bba", new string[] {"Text 001bba",
                    "choice1bba",//leads to level 001bbaa
                    "choice2bba",//leads to level 001bbab
                    "choice3bba" }},//leads to level 001bbac

                {"level_001bca", new string[] {"Text 001bca",
                    "choice1bca",//leads to level 001bcaa
                    "choice2bca",//leads to level 001bcab
                    "choice3bca" }},//leads to level 001bcac

                {"level_001caa", new string[] {"Text 001caa",
                    "choice1caa",//leads to level 001caaa
                    "choice2caa",//leads to level 001caab
                    "choice3caa" }},//leads to level 001caac

                {"level_001cba", new string[] {"Text 001cba",
                    "choice1cba",//leads to level 001cbaa
                    "choice2cba",//leads to level 001cbab
                    "choice3cba" }}//leads to level 001cbac



        };
        //to access the values levelsDic["level_001a"][0];

            /*Level scheme will be as follows:
             * with each choice either an "a", "b", or "c" will be appended to the level name
             * that appended level name will be the next level loaded
             * for example level_001abcb would be the level resulting from the following choice order:
             * ChoiceButton1, ChoiceButton2, ChoiceButton3, and then ChoiceButton2 again
             * so the path can be traced back in the tree easily
             */

        public MainPage()
        {
            this.InitializeComponent();

            bool alive = true;

            //beginGame();
            nextLevel(userChoice.CurrentLevel);
        }

        //Class to make an object that contains 3 boolean fields - choice 1, choice 2, and choice 3
        public class Choice
        {
            public bool Choice1 { get; set; }
            public bool Choice2 { get; set; }
            public bool Choice3 { get; set; }
            public string TextValue1 { get; set; }
            public string TextValue2 { get; set; }
            public string TextValue3 { get; set; }
            public string LastAnswer { get; set; }
            public string CurrentLevel { get; set; }

            public Choice(bool choice1, bool choice2, bool choice3,
                string text1, string text2, string text3)
            {
                Choice1 = choice1;
                Choice2 = choice2;
                Choice3 = choice3;
                TextValue1 = text1;
                TextValue2 = text2;
                TextValue3 = text3;
                LastAnswer = "";
                CurrentLevel = "level_001";
            }
        }

        public void levelChoices(string button1Text, string button2Text, string button3Text)
        {
            ChoiceButton1.Content = button1Text;
            ChoiceButton2.Content = button2Text;
            ChoiceButton3.Content = button3Text;
        }
        
        public void nextLevel(string level)
        {
            if(level.Contains("Restart"))
            {
                //start game over at level_001
            }
            else if (level.Contains("Try Again"))
            {
                //redo the last scenario with the same 3 choices
            }
            else if (level.Contains("Exit"))
            {
                //exit game going back to main screen - yet to be made
            }
            else
            {
                //load next level data from dictionary and update ReadingPane and button text
                levelChoices(levelsDic[level][1], levelsDic[level][2], levelsDic[level][3]);
                ReadingPane.Text = levelsDic[level][0];
            }
        }
        
        private void ChoiceButton1_Click(object sender, RoutedEventArgs e)
        {
            //What happens when ChoiceButton1 is clicked
            //Change value of userChoice to true,false,false
            userChoice.Choice1 = true;
            userChoice.Choice2 = false;
            userChoice.Choice3 = false;
            userChoice.LastAnswer = ChoiceButton1.Content.ToString();
            //update current level
            string level = userChoice.CurrentLevel.ToString();
            string updatedLevel = level += "a";
            //if the button clicked's content equals Restart, Try Again, or Exit
            //add that to the level string to get picked up by nextLevel()
            userChoice.CurrentLevel = updatedLevel;
            nextLevel(userChoice.CurrentLevel);
        }

        private void ChoiceButton2_Click(object sender, RoutedEventArgs e)
        {
            //What happens when ChoiceButton2 is clicked
            //Change value of userChoice to false,true,false
            userChoice.Choice1 = false;
            userChoice.Choice2 = true;
            userChoice.Choice3 = false;
            userChoice.LastAnswer = ChoiceButton2.Content.ToString();
            //update current level
            string level = userChoice.CurrentLevel.ToString();
            string updatedLevel = level += "b";
            //if the button clicked's content equals Restart, Try Again, or Exit
            //add that to the level string to get picked up by nextLevel()
            userChoice.CurrentLevel = updatedLevel;
            nextLevel(userChoice.CurrentLevel);
        }

        private void ChoiceButton3_Click(object sender, RoutedEventArgs e)
        {
            //What happens when ChoiceButton3 is clicked
            //Change value of userChoice to false,false,true
            userChoice.Choice1 = false;
            userChoice.Choice2 = false;
            userChoice.Choice3 = true;
            userChoice.LastAnswer = ChoiceButton1.Content.ToString();

            //update current level
            string level = userChoice.CurrentLevel.ToString();
            string updatedLevel = level += "c";
            //if the button clicked's content equals Restart, Try Again, or Exit
            //add that to the level string to get picked up by nextLevel()
            userChoice.CurrentLevel = updatedLevel;
            nextLevel(userChoice.CurrentLevel);
        }
    }
}
