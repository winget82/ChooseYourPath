using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
                {"level_001", new string[] {"Text 001", "choice1", "choice2", "choice3"}},//starting level
                {"level_001a", new string[] {"Text 001a", "choice1a", "choice2a", "choice3a"}},//level as a result of ChoiceButton1
                {"level_001b", new string[] {"Text 001b", "choice1b", "choice2b", "choice3b"}},//level as a result of ChoiceButton2
                {"level_001c", new string[] {"Text 001c", "choice1c", "choice2c", "choice3c"}},//level as a result of ChoiceButton3
                {"level_001aa", new string[] {"Text 001aa", "choice1aa", "choice2aa", "choice3aa"}},
                {"level_001ab", new string[] {"Text 001ab", "choice1ab", "choice2ab", "choice3ab"}},
                {"level_001ac", new string[] {"Text 001ac", "choice1ac", "choice2ac", "choice3ac"}}
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
            //load next level data from dictionary and update ReadingPane and button text
            levelChoices(levelsDic[level][1], levelsDic[level][2], levelsDic[level][3]);
            ReadingPane.Text = levelsDic[level][0];
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
            userChoice.CurrentLevel = updatedLevel;
            nextLevel(userChoice.CurrentLevel);
        }
    }
}
