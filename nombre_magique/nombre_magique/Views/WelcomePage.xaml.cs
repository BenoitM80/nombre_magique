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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();

            // Pour ne pas afficher la NavigationBar dans la page
            NavigationPage.SetHasNavigationBar(this, false);

            #pragma warning disable CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel

            InfiniteScale(playButton, 1000);
               #pragma warning restore CS4014 // Dans la mesure où cet appel n'est pas attendu, l'exécution de la méthode actuelle continue avant la fin de l'appel
        }


        // Procédure asynchrone pour gérer la rotation infinie des étoiles
        private async Task InfiniteScale(View view, uint timer)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.1, timer);
                await view.ScaleTo(1.0, timer);
                view.Scale = 0;
            }
        }

        // Gestion du bouton "Jouer"
        private void PlayButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
    }
}