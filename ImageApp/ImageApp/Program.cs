using System.Drawing;
namespace ImageApp
{
    public interface IImageViewer
    {
        void DisplayImage(string file);
    }


    public class PNGImageViewer
    {
        public void DisplayPNG(string filename) 
        {
            Console.WriteLine(filename +"It's a png file.");
            
        }
    }

    public class PNGAdapter: IImageViewer
    {
        private PNGImageViewer _viewer = null;

        public PNGAdapter(PNGImageViewer viewer)
        {
            _viewer = viewer;
        }
        public void DisplayImage(string filename)
        {
            _viewer.DisplayPNG(filename);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PNGImageViewer viewer = new PNGImageViewer();
            PNGAdapter adapter = new PNGAdapter(viewer);

            adapter.DisplayImage("image1.png");
            Console.ReadKey();
        }
    }
}
