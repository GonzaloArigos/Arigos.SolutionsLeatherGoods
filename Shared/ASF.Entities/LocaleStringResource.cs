namespace ASF.Entities
{
    public class LocaleStringResource
    {
        public int Id { get; set; }
        public string ResourceValue { get; set; }
        public int LocaleResourceKey_Id { get; set; }
        public int Language_Id { get; set; }

        public virtual Language Language { get; set; }
        public virtual LocaleResourceKey LocaleResourceKey { get; set; }
    }
}