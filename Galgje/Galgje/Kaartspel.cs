using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    enum Waarde
    {
        A = 1,
        Twee,
        Drie,
        Vier,
        Vijf,
        Zes,
        Zeven,
        Acht,
        Negen,
        Tien,
        J,
        Q,
        K
    }
    enum Type
    {
        Harten,
        Ruiten,
        Klaveren,
        Schoppen
    }
    class Kaart
    {
        public Waarde Waarde { get; set; }
        public Type Type { get; set; }

        public Kaart(Waarde waarde, Type type)
        {
            Waarde = waarde;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Waarde} van {Type}";
        }
    }
}
