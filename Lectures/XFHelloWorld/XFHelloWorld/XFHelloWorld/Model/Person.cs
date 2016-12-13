namespace XFHelloWorld.Model
{
    public class Person
    {
        public string Name { get; set; }

        public int BirthYear { get; set; }

        public string ImageName { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.BirthYear;
        }
    }
}
