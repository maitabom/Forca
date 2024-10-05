using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Models;

public class Word
{
    public string Tips { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;

    public Word() { }
    public Word(string tips, string text)
    {
        this.Tips = tips;
        this.Text = text;
    }
}
