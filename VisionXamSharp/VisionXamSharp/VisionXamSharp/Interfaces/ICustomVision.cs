using System.IO;
using System.Threading.Tasks;
namespace VisionXamSharp
{
    interface ICustomVision
    {
        Task Procesar(Stream img);
    }
}
