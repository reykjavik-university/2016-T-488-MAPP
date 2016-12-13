namespace XFHelloWorld.Model
{
    using Xamarin.Forms;

    public class Person
    {
        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string ImageName { get; set; }

        public ImageSource ImageResource => ImageSource.FromResource("XFHelloWorld.Images.FamousPeople." + this.ImageName + ".png");

        public override string ToString()
        {
            return this.Name + " " + this.BirthYear;
        }
    }
}
