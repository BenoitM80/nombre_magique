using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nombre_magique.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {

        const int NB_MIN = 1;
        const int NB_MAX = 10;
        const int NB_TRIES = 4;

        int leftTries = NB_TRIES;

        int guessNumber = 0;
        

        public GamePage()
        {
            this.guessNumber = RandomNumber();
            InitializeComponent();
            // NavigationPage.SetHasNavigationBar(this, false);

            valLabel.Text = "entre " + NB_MIN + " et " + NB_MAX;
        }


        // Action du clic sur le bouton de validation:
        private void GuessButton_Clicked(object sender, EventArgs e)
        {
            int number = 0;

            if (leftTries > 0)
            {                
                try
                {
                    number = Int32.Parse(NumberEntry.Text);                     
                }
                catch
                {
                    DisplayAlert("Erreur", "Il faut saisir un nombre entre 1 et 10", "OK");
                    NumberEntry.Text = "";
                    return;
                }


                bool resultat = teste_nombre(number);

                if (resultat == true)
                    {
                #pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                        ResultAction(guessNumber,true);
                        
                #pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel

                    }
                    else
                    {
                        NumberEntry.Text = "";
                        TriesLabel.Text = "Vies restantes : " + leftTries;


                        if (leftTries== 0) {
#pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                        ResultAction(guessNumber,false);
                #pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
                        return;
                        }

                        NumberEntry.Focus();
                }
            }          
        }

        // Calcule un nombre aléatoire entre min et max:
        private int RandomNumber()
        {
            int magicNumber = new Random().Next(NB_MIN, NB_MAX);

            return magicNumber;            
        }

        // Teste le nombre saisi par l'utilisateur:
        private bool teste_nombre(int valeur)
        {        
            if ((valeur >= NB_MIN) && (valeur <= NB_MAX)){
                if (valeur > this.guessNumber)
                {
                    this.leftTries--;
                    if (this.leftTries > 0)
                    {
                        DisplayAlert("Oops", "le nombre est inférieur à " + valeur,"OK");
                    }
                    return false;

                } else if (valeur < this.guessNumber)
                {

                    this.leftTries--;
                    if (this.leftTries > 0)
                    {
                        DisplayAlert("Oops", "le nombre est supérieur à " + valeur, "OK");
                    }
                    return false;

                } else
                {                    
                    return true;
                }

            } else {
                DisplayAlert("Erreur", "votre nombre doit être compris entre " + NB_MIN + " et " + NB_MAX, "OK");
                return false;
            }
        }


        // Action effectuée quand le joueur a gagné ou perdu:
        private async Task ResultAction(int number,bool hasWon)
        {            
            await this.Navigation.PushAsync(new WinPage(number,hasWon));
        }


  
    }
}