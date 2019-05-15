using System.Windows;

namespace PhotoManager.CarouselControl
{
    public interface ICarouselControl
    {
        void SelectElement(FrameworkElement element);
        double Rotate(double startXInScreenCoordinates, double endXInScreenCoordinates);
        void SelectFrontMostElement();
        void Rotate(double angleInDegrees);
        bool ShowRotation { get; set; }
    }
}
