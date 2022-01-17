namespace Indexers
{

  class Player { 
    public string Name { get; set; }

    public override string? ToString()
    {
      return Name;
    }
  }

  class Board
  {
    Player[,] board = new Player[8, 8];

    int RowToIndex(string row)
    {
      string temp = row.ToUpper();
      return temp[0] - 'A';
    }

    int PositionToColumn(string pos)
    {
      return pos[1] - '0' - 1;
    }

    public Player this[string row, int column]
    {
      get
      {
        return board[RowToIndex(row), column - 1];
      }
      set
      {
        board[RowToIndex(row), column - 1] = value;
      }
    }

    public Player this[string position]
    {
      get
      {
        return board[RowToIndex(position), PositionToColumn(position)];
      }
      set
      {
        board[RowToIndex(position), PositionToColumn(position)] = value;
      }
    }
  }
}
  


   
  
    
  


