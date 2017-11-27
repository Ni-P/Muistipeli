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
        bool _isOpen;
        bool _isMatched;

        public Card(String name, String imgPath)
        {
            Name = name;
            _imgPath = imgPath;
            IsOpen = false;
            _isMatched = false;
        }

        public string ImgPath { get => _imgPath; set => _imgPath = value; }
        public string Name { get => _name; set => _name = value; }
        public bool IsOpen { get => _isOpen; set => _isOpen = value; }
        public bool IsMatched { get => _isMatched; set => _isMatched = value; }
    }
}
