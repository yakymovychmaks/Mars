namespace DLL.Models.UserModel
{
    public class Office
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public List<Apointment> Apointment { get; set; }
    }
}
