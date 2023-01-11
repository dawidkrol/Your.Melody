using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Your.Melody.Library.Models
{
    public class PlayerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid GameId { get; set; }
        public float Points { get; set; }
        public int Rounds { get; set; } = 0;
        public UserModel User { get; set; }
    }
}
