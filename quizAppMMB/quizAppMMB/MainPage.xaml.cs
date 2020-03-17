using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace quizAppMMB

{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        int score = 0;
        void OnSwiped(Object sender, SwipedEventArgs e)
        {
            if (e.Direction == SwipeDirection.Right)
            {
                if (keys[index-1] == 1)
                    characterScores[0] += 5;
                else if (keys[index-1] == 2)
                    characterScores[1] += 5;
                else if (keys[index-1] == 3)
                    characterScores[2] += 5;
                else if (keys[index-1] == 4)
                    characterScores[3] += 5;
            }
            nextQuestion();
        }
        int index = 0;

        public List<string> questions = new List<String>
        {
            "You're a bit of a troublemaker, a rascal","You are musically and academically gifted", "You care about your family", "You own a slingshot", "You own a musical instrument", "You are good at cooking", "You like an ice cold Duff beer",
            "You often wear a white polo shirt","You've used the phrase \"don't have a cow man\"","You care about the environment","You have blue hair","You work in a powerplant"
        };
        public List<int> keys = new List<int>
        {
            1,2,3,1,2,3,4,4,1,2,3,4
        };
        public List<string> characters = new List<String>
        {
            "bart","lisa", "marge", "homer"
        };
        public List<int> characterScores = new List<int>
        {
            0,0,0,0
        };
        public void nextQuestion()
        {
            question_label.Text = questions[index];
            index++;
            if (index >= questions.Count())
            {
                question_label.IsVisible = false;
                displayCharacter();
            }
            
        }

        public void displayCharacter()
        {
            lastResult.Text = "Your character is ";
            the_image.IsVisible = true;
            if (characterScores[0] == characterScores.Max())
            {
                the_image.Source = characters[0] + ".png";
                lastResult.Text += characters[0];
            }
            else if (characterScores[1] == characterScores.Max())
            {
                the_image.Source = characters[1] + ".png";
                lastResult.Text += characters[1];
            }
            else if (characterScores[2] == characterScores.Max())
            {
                the_image.Source = characters[2] + ".png";
                lastResult.Text += characters[2];
            }
            else if (characterScores[3] == characterScores.Max())
            {
                the_image.Source = characters[3] + ".png";
                lastResult.Text += characters[3];
            }
            lastResult.Text += " and your score is " + characterScores.Max();
        }
        void start_clicked(Object sender, EventArgs args)
        {
            start_btn.IsVisible = false;
            if (yourName.Text.Length <= 4)
            {
                characterScores[0] += 5;
                characterScores[1] += 5;
            }
            else
            {
                characterScores[2] += 5;
                characterScores[3] += 5;
            }
            if (int.Parse(yourAge.Text) < 18)
            {
                characterScores[0] += 5;
                characterScores[1] += 5;
            }
            else
            {
                characterScores[2] += 5;
                characterScores[3] += 5;
            }
            yourName.IsVisible = false;
            yourAge.IsVisible = false;
            question_label.IsVisible = true;
            lastResult.IsVisible = true;
            nextQuestion();
        }


    }
}
