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
    public partial class StarsView : ContentView
    {
        public StarsView()
        {
            InitializeComponent();

        #pragma warning disable CS4014
            InfiniteRotation(star1, 4000);
            InfiniteRotation(star2, 5000);
            InfiniteRotation(star3, 9000);
        #pragma warning restore CS4014
        }

        // Procédure asynchrone pour gérer la rotation infinie des étoiles
        private async Task InfiniteRotation(View view, uint timer)
        {
            bool always = true;
            while (always)
            {
                await view.RotateTo(360, timer);
                view.Rotation = 0;
            }
        }
    }
}