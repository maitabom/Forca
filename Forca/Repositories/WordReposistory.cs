using Forca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forca.Repositories;

public class WordReposistory
{
    private List<Word> words;

    public WordReposistory()
    {
        words = new List<Word>();

        words.Add(new Word("Verdura", "Cenoura"));
        words.Add(new Word("Planta", "Girassol"));
        words.Add(new Word("Fruta", "Abacaxi"));
        words.Add(new Word("Animal", "Cavalo"));
        words.Add(new Word("Transporte", "Carro"));
        words.Add(new Word("Animal", "Raposa"));
        words.Add(new Word("Planeta", "Saturno"));

        FormatWords();
    }

    public Word GetRandomWord()
    {
        Random random = new Random();
        var index = random.Next(0, words.Count);

        return words[index];
    }

    protected void FormatWords()
    {
        foreach (var word in words)
        {
            word.Tips = word.Tips.ToUpper();
            word.Text = word.Text.ToUpper();
        }
    }
}
