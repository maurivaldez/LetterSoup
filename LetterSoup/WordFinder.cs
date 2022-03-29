using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LetterSoup
{
  public class WordFinder
  {
    private IEnumerable<string> _matrix;
    public WordFinder( IEnumerable<string> matrix )
    {
      _matrix = matrix;
      //Validations?
      //64x64
      //All strings same lengh
    }

    public IEnumerable<string> Find( IEnumerable<string> wordStream )
    {
      var maxtrixDecomposed = new List<string>();

      LeftToRight(ref maxtrixDecomposed);
      TopToBottom(ref maxtrixDecomposed);

      //RightToLeft(ref maxtrixDecomposed);
      //BottomToTop(ref maxtrixDecomposed);

      var mostRepeatedWords = FindInADecomposedMatrix(wordStream, maxtrixDecomposed);

      return mostRepeatedWords.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key).AsEnumerable();
    }

    private void LeftToRight(ref List<string> maxtrixDecomposed)
    {
      foreach(var horizontalRow in _matrix)
        maxtrixDecomposed.Add(horizontalRow);
    }

    private void TopToBottom(ref List<string> maxtrixDecomposed)
    {
      if (_matrix.Any())
      {
        var horizontalLength = _matrix.ElementAt(0).Length;
        for (var index = 0; index < horizontalLength; index++)
        {
          var verticalArray = _matrix.Select(x => x[index]).ToArray();
          var verticalRow = string.Join("", verticalArray);
          maxtrixDecomposed.Add(verticalRow);
        }
      }
    }

    private Dictionary<string, int> FindInADecomposedMatrix(IEnumerable<string> wordStream, IEnumerable<string> matrixDecomposed)
    {
      var mostRepeatedWords = new Dictionary<string, int>(); //Word, Count
      
      foreach(var word in wordStream)
      {
        var numberOfRepeate = 0;
        foreach (var row in matrixDecomposed)
        {
          var index = 0;
          while(index < row.Length)
          {
            var startIndexFounded = row.IndexOf(word, index);
            if (startIndexFounded != -1)
            {
              index = startIndexFounded + word.Length;
              numberOfRepeate += 1;
            }
            else
              break;
          }
        }
        if (numberOfRepeate > 0)
          mostRepeatedWords.Add(word, numberOfRepeate);
      }
      return mostRepeatedWords;
    }

    //Methods to extend
    private void RightToLeft(ref List<string> maxtrixDecomposed)
    {

    }

    private void BottomToTop(ref List<string> maxtrixDecomposed)
    {

    }

    
  }
}
