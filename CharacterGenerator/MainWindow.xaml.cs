using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Initiates the lists
        List<string> sex = new List<string>() { "male", "female" };
        List<string> race = new List<string>() { "Breton", "Imperial", "Nord", "Redguard", "Altmer", "Bosmer", "Dunmer", "Orc", "Argonian", "Khajiit" };
        List<string> skills = new List<string>();
        List<string> spells = new List<string>();
        string result = "";

        
        

        public void MakeSkillsList()
        {
            int counter = 0; //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("...\\skills.txt");

            while ((line = file.ReadLine()) != null)
            {
                skills.Add(line);
                counter++;
            }

            file.Close();
        }

        public void MakeSpellsList()
        {
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("...\\spells.txt");

            while ((line = file.ReadLine()) != null)
            {
                spells.Add(line);
                counter++;
            }

            file.Close();
        }

        public void ChangeBg()
        {
            //MainWindow.BackgroundProperty = "...\\bg.jpg";
            //bg.ImageSource
        }

        public void RandomChar()
        {
            MakeSkillsList();
            MakeSpellsList();
            result = "";

            Random r = new Random();
            int i = r.Next(sex.Count);
            result += "You are a " + sex[i];

            i = r.Next(race.Count);
            result += " " + race[i]+ "," + Environment.NewLine;

            i = r.Next(skills.Count);
            result += "specializing in " + skills[i];

            i = r.Next(skills.Count);
            result += ", " + skills[i];

            i = r.Next(skills.Count);
            result += ", and " + skills[i] + "." + Environment.NewLine;

            i = r.Next(spells.Count);
            result += "You have the spell " + spells[i] + " at your disposal.";
        }

        public void DisplayResult()
        {
            lblResult.Content = null;
            lblResult.Content = result;
        }

        private void btnMakeSkillList_Click(object sender, RoutedEventArgs e)
        {
            MakeSkillsList();
        }

        private void btnMakeSpellList_Click(object sender, RoutedEventArgs e)
        {
            MakeSpellsList();
        }

        private void btnGetCharacter_Click(object sender, RoutedEventArgs e)
        {
            RandomChar();
            DisplayResult();
        }
    }

}
