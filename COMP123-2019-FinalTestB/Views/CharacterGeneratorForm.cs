using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
/*
 * STUDENT NAME: Yoonseop  Lee
 * STUDENT ID: 301037418
 * DESCRTIPTION : This is CharacterGeneratorForm
 *       
 */
namespace COMP123_2019_FinalTestB.Views
{
    public partial class CharacterGeneratorForm : MasterForm
    {
        public CharacterGeneratorForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This is the event handler for the BackButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex != 0)
            {
                MainTabControl.SelectedIndex--;
            }
        }


        /// <summary>
        /// This is the event handler for the NextButton Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex < MainTabControl.TabPages.Count - 1)
            {
                MainTabControl.SelectedIndex++;
            }
        }


        private void GenerateButton_Click(object sender, EventArgs e)
        {
            LoadNames();

            
        }

        private void GenerateAbilitiesButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int RandomStrenth = rand.Next(3, 18);
            int RandomDex = rand.Next(3, 18);
            int RandomConsti = rand.Next(3, 18);
            int RandomInt = rand.Next(3, 18);
            int RandomWisdom = rand.Next(3, 18);
            int RandomCharisma = rand.Next(3, 18);


            StrenthDataLabel.Text = RandomStrenth.ToString();
            DexterityDataLabel.Text = RandomDex.ToString();
            ConstitutionDataLabel.Text = RandomConsti.ToString();
            IntelligenceDataLabel.Text = RandomInt.ToString();
            WisdomDataLabel.Text = RandomWisdom.ToString();
            CharismaDataLabel.Text = RandomCharisma.ToString();

            Program.character.Strength = RandomStrenth.ToString();
            Program.character.Dexterity = RandomDex.ToString();
            Program.character.Constitution = RandomConsti.ToString();
            Program.character.Intelligence = RandomInt.ToString();
            Program.character.Wisdom = RandomWisdom.ToString();
            Program.character.Charisma = RandomCharisma.ToString();
        }

        public void GenerateInventoryButton_Click(object sender, EventArgs e)
        {


            LoadInventory();



        }



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "Current State.txt";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
            saveFileDialog.ShowDialog();
        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";

            // open file dialog 
            var _dialogResult = openFileDialog.ShowDialog();
            if (_dialogResult != DialogResult.Cancel)
            {
                // open file to write
                using (StreamWriter outputStream = new StreamWriter(
                    File.Open(openFileDialog.FileName, FileMode.Create)))
                {
                    // write stuff to the file

                    // cleanup
                    outputStream.Flush();
                    outputStream.Close();
                    outputStream.Dispose();
                }

            }


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.aboutBox.ShowDialog();
        }


        public void LoadInventory()
        {
            string inventoryPath = "..\\..\\Data\\inventory.txt";

            List<string> inventoryList = new List<string>();

            TextReader reader = new StreamReader(inventoryPath);
            string input = reader.ReadLine();
            while (input != null)
            {
                inventoryList.Add(input);
                input = reader.ReadLine();
            }
            reader.Close();

            GenerateRandomInventory(inventoryList);
        }


        public void LoadNames()
        {
            string firstNamePath = "..\\..\\Data\\firstNames.txt";
            string lastNamePath = "..\\..\\Data\\lastNames.txt";

            List<string> firstNames = new List<string>();
            
            TextReader reader = new StreamReader(firstNamePath);
            string input = reader.ReadLine();
            while (input != null)
            {
                firstNames.Add(input);
                input = reader.ReadLine();
            }
            reader.Close();


            List<string> lastNames = new List<string>();

            TextReader lastNameReader = new StreamReader(lastNamePath);
            string inputValue = lastNameReader.ReadLine();
            while (inputValue != null)
            {
                lastNames.Add(inputValue);
                inputValue = lastNameReader.ReadLine();
            }
            lastNameReader.Close();

            GenerateNames(firstNames, lastNames);
        }


        public void GenerateNames(List<string> firstNames, List<string> lastNames)
        {

            Random rand = new Random();
            int index = rand.Next(firstNames.Count);
            FirstNameDataLabel.Text = firstNames[index];

            Program.character.FirstName = firstNames[index];






            Random random = new Random();
            int lastNameIndex = rand.Next(lastNames.Count);
            LastNameDataLabel.Text = lastNames[lastNameIndex];

            Program.character.LastName = lastNames[index];
        }


        public void GenerateRandomInventory(List<string> inventoryList)
        {
            Random rand = new Random();
            int Item1Index = rand.Next(inventoryList.Count);
            ItemNameDataLabel1.Text = inventoryList[Item1Index];
            int Item2Index = rand.Next(inventoryList.Count);
            ItemNameDataLabel2.Text = inventoryList[Item2Index];
            int Item3Index = rand.Next(inventoryList.Count);
            ItemNameDataLabel3.Text = inventoryList[Item3Index];
            int Item4Index = rand.Next(inventoryList.Count);
            ItemNameDataLabel4.Text = inventoryList[Item4Index];

            Program.character.Inventory.Add(inventoryList[Item1Index]);
            Program.character.Inventory.Add(inventoryList[Item2Index]);
            Program.character.Inventory.Add(inventoryList[Item3Index]);
            Program.character.Inventory.Add(inventoryList[Item4Index]);
        }


        private void CharacterGeneratorForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            GenerateAbilitiesButton_Click(sender, e);
            LoadInventory();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedIndex == 3)
            {
                HeroNameDataLabel.Text = CharacterNameTextBox.Text;
                GeneratedNameDataLabel.Text = Program.character.FirstName + Program.character.LastName;
                AbilitiesDataLabel.Text = $"str{Program.character.Strength}  dex{Program.character.Dexterity} con{Program.character.Constitution}  int{Program.character.Intelligence} wis{ Program.character.Wisdom}  char{ Program.character.Charisma}";

            }
        }
    }
}
