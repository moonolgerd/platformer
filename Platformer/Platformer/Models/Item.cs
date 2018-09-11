using Newtonsoft.Json;
using System;

namespace Platformer
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
