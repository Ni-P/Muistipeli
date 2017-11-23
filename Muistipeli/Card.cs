using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muistipeli
{
    class Card
    {
        String _name;
        String _imgPath;

        public Card(String name, String imgPath)
        {
            _name = name;
            _imgPath = imgPath;
        }

        public string ImgPath { get => _imgPath; set => _imgPath = value; }
    }
}
