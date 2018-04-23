using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.Cognitive.CustomVision.Training;
using Microsoft.Cognitive.CustomVision.Prediction;

namespace VisionXamSharp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CV_MainView : ContentPage,ICustomVision
	{
        Stream Imagen = null;
        string Informacion = "";
        TrainingApi trainingApi = new TrainingApi()
        {
            ApiKey = Constantes.trainingKey
        };
        PredictionEndpoint endpoint = new PredictionEndpoint()
        {
            ApiKey = Constantes.predictionKey
        };
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
                Imagen = file.GetStream();
                await Procesar(Imagen);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void comprobar(object sender, EventArgs e)
        {
            resultado.Text = Informacion;
        }

        public async Task Procesar(Stream img)
        {
            Indicador.IsRunning = true;
            var sproject = trainingApi.GetProjects().ToArray();
            var project = sproject[0];
            var result = endpoint.PredictImage(project.Id, img);
            var c = result.Predictions.ToArray();
            await Task.Delay(10000);
            for (int i = 0; i < c.Length; i++)
            {
                Informacion = Informacion + "Con: " + c[i].Tag + "," + String.Format(" Total: {0:P2}.", c[i].Probability) + "\n";
            }
            Indicador.IsRunning = false;
            Mensaje.Text = "Listo";
        }
    }
}