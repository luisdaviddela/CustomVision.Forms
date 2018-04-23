using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisionXamSharp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CV_MainView : ContentPage
	{
		public CV_MainView ()
		{
			InitializeComponent ();
		}
        private async void Imagen_Foto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void comprobar(object sender, EventArgs e)
        {

        }
    }
}