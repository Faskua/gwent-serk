using System.Security.Principal;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

class Lexxer{
    List<Token> tokens = new List<Token>();
    Regex text = new Regex(@"[_a-zA-Z][_a-zA-Z0-9]*");
    Regex number = new Regex(@"\d+(\.\d+)?");
    Regex symbol = new Regex(@">|<|>=|<=|=>|\+|-|\*|\/|\^|\+\+|--|\+=|-=|&&|==|!=|\|\|!|@@|@|=|;|,|:|.|\(|\[|{|\)|]|}");
    Regex Spaces = new Regex(@"[\s|\t]+");

    public List<Token> Tokenize(string input){
        tokens.Clear();
        string[] Splited = input.Split('\n');
        string Token = "";
        bool Comillas = false;
        int line = 0;
        int column = 0;
        (int line, int column) last = (0,0);

        while(line < Splited.Length){//iterando por lineas
            string Line = Splited[line];
            while ( column < Line.Length){ //por columnas
                if(Line[column] == '"'){
                    Comillas = !Comillas;
                    last = (line+1, column+1);
                    Token += Line[column];
                    if(!Comillas){
                        tokens.Add(new Token(TokenType.String, Token[1..^1], new CodeLocation(line, column)));
                        Token = "";
                    }
                }
                else if(Comillas){
                    Token += Line[column];
                }
                else{
                    if(Spaces.IsMatch(Line[column].ToString())){}
                    else if(text.IsMatch(Line[column].ToString())) AddToken(text.Match(Line, column).Value, line, ref column);
                    else if(number.IsMatch(Line[column].ToString())) AddToken(number.Match(Line, column).Value, line,ref column, TokenType.Int);
                    else if(symbol.IsMatch(Line[column].ToString())) AddToken(symbol.Match(Line, column).Value, line, ref column);
                }
                column++;
            }
            line ++;
            column = 0;
        }
        if(Comillas) throw new Exception($"Missing clousing quote at line: {last.line}, column: {last.column}");
        return tokens;
    }
    void AddToken(string match, int line, ref int column, TokenType type = TokenType.Unknown){
        try{
            TokenType forUsing = TokenType.Unknown;
            if(type is TokenType.Unknown) {
                forUsing = Token.Types[match];
                tokens.Add(new Token(forUsing, match, new CodeLocation(line, column)));
            }
            else 
                tokens.Add(new Token(type,match, new CodeLocation(line, column)));
        }
        catch(KeyNotFoundException){
            tokens.Add(new Token(TokenType.Identifier, match, new CodeLocation(line, column)));
        }
        column += match.Length - 1;
    }
    
}