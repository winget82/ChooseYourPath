using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        Choice userChoice = new Choice(false, false, false, "choice 1", "choice 2", "choice 3", "");

        public MainPage()
        {
            this.InitializeComponent();

            bool alive = true;
            
            beginGame();

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

            public Choice(bool choice1, bool choice2, bool choice3,
                string text1, string text2, string text3, string lastAnswer)
            {
                Choice1 = choice1;
                Choice2 = choice2;
                Choice3 = choice3;
                TextValue1 = text1;
                TextValue2 = text2;
                TextValue3 = text3;
                LastAnswer = lastAnswer;
            }
        }

        public void levelChoices(string button1Text, string button2Text, string button3Text)
        {
            ChoiceButton1.Content = button1Text;
            ChoiceButton2.Content = button2Text;
            ChoiceButton3.Content = button3Text;
        }

        public void beginGame()
        {
            levelChoices("Clean your boots", "Stand in the warmth barefooted", "Walk on...");
            ReadingPane.Text = "You are standing in cow patty...  What would you like to do?";
            //get method to wait for button click to finish

            level_001();
        }

        public void level_001()
        {
            if (userChoice.Choice1)
            {
                ReadingPane.Text = "How would you like to clean your boots?";
                levelChoices("Use a rag", "Wipe them in the grass", "Find a stick");   
            }
            else if (userChoice.Choice2)
            {
                ReadingPane.Text = "You are standing in cow patty barefoot, man does that feel warm and fresh!" +
                    "How would you like to proceed?";
                levelChoices("Walk on...", "Put hands in it...", "Meditate");
            }
            else if (userChoice.Choice3)
            {
                ReadingPane.Text = "You walk on...  You come to a creek.  What would you like to do?";
                levelChoices("Fish", "Wash your boots", "Get a drink");
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
            //something to run next level
        }

        private void ChoiceButton2_Click(object sender, RoutedEventArgs e)
        {
            //What happens when ChoiceButton2 is clicked
            //Change value of userChoice to false,true,false
            userChoice.Choice1 = false;
            userChoice.Choice2 = true;
            userChoice.Choice3 = false;
            userChoice.LastAnswer = ChoiceButton2.Content.ToString();
            //something to run next level
        }

        private void ChoiceButton3_Click(object sender, RoutedEventArgs e)
        {
            //What happens when ChoiceButton3 is clicked
            //Change value of userChoice to false,false,true
            userChoice.Choice1 = false;
            userChoice.Choice2 = false;
            userChoice.Choice3 = true;
            userChoice.LastAnswer = ChoiceButton1.Content.ToString();
            //something to run next level
        }
    }
}
