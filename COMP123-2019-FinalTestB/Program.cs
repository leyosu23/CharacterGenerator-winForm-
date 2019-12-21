using COMP123_2019_FinalTestB.Objects;
using COMP123_2019_FinalTestB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_2019_FinalTestB
{
    static class Program
    {
        public static CharacterGeneratorForm characterForm;
        public static Character character;
        public static AboutBox aboutBox;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            characterForm = new CharacterGeneratorForm();
            character = new Character();
            aboutBox = new AboutBox();
            Application.Run(characterForm);
        }
    }
}
