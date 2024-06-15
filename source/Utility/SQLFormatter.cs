using System.Runtime.Serialization;
using PoorMansTSqlFormatterLib.Formatters;
using PoorMansTSqlFormatterLib.Parsers;
using PoorMansTSqlFormatterLib.Tokenizers;

namespace source.Utility;
public class SQLFormatter
{
    ///Need to tokenized the sql object for the beatification of the file
    public string SqlFomatter(string sql){
        //Create an instance of the T-SQL tokenizer 
        var tokenizer = new TSqlStandardTokenizer();

        //Tokenize the SQL content
        var tokenList = tokenizer.TokenizeSQL(sql);

        //Create an instance of the T-SQL parser 
        var parser = new TSqlStandardParser();

        //Parse the tokenized SQL content 
        var parsedSql = parser.ParseSQL(tokenList);

        //Create an instance of the standard formatter 
        var formatter = new TSqlStandardFormatter(); 

        //Format the parsed SQL content 
        string formattedSql = formatter.FormatSQLTree(parsedSql);

        return formattedSql;
    }
}
