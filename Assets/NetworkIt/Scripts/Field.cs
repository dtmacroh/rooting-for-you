namespace NetworkIt
{
    public class Field
    {
        public string key;
        public string value;


        public Field(string key, string value)
        {
            this.key = key;
            this.value = value;
        }


        public override string ToString()
        {
            return this.key + " : " + this.value.ToString();
        }
    }
}
