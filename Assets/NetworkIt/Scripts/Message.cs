using System.Collections.Generic;
using Newtonsoft.Json;

namespace NetworkIt
{
    public class Message
    {
        private string subject;
        private bool deliverToSelf = false;
        private List<Field> fields = new List<Field>();

        public string Subject
        {
            get
            {
                return this.subject;
            }
            set
            {
                this.subject = value;
            }
        }


        /// <summary>
        /// When true, allows the sender to also recieve the same message activating the same message event
        /// Default is false
        /// </summary>
        public bool DeliverToSelf
        {
            get
            {
                return this.deliverToSelf;
            }
            set
            {
                this.deliverToSelf = value;
            }
        }

        public List<Field> Fields
        {
            get
            {
                return this.fields;
            }
        }

        public Message(string subject)
        {
            this.subject = subject;
        }


        public void AddField(string key, string value)
        {
            Field f = new Field(key, value);
            this.fields.Add(f);
        }


        public string GetField(string key)
        {
            foreach (Field f in this.fields)
            {
                if (f.key.Equals(key))
                {
                    return f.value;
                }
            }

            return null;
        }

        public override string ToString()
        {
            string ret = JsonConvert.SerializeObject(new
            {
                subject = this.subject,
                fields = this.fields
            });

            return ret;
        }
    }
}
