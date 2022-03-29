using System;
using System.Collections.Generic;
using System.Linq;

namespace LetterSoup
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      IEnumerable<string> matrix = new List<string> { "maurisdfsdfmaurisadfsamau", "paulasdasdmauridfsdfrsdfd", "paulasdasdghjgdfsdfpausds" };
      IEnumerable<string> wordStream = new List<string> { "mauri", "pau", "oscar"};
      WordFinder wf = new WordFinder(matrix);
      var mostRepeatedWords = wf.Find(wordStream);
      foreach (var word in mostRepeatedWords)
        Console.WriteLine(word);
    }
  }
}
