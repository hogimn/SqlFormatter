﻿using System.Collections.Generic;
using SQL.Formatter.Core;

namespace SQL.Formatter.Language
{
    public class MySqlFormatter : AbstractFormatter
    {
        private static readonly List<string> ReservedWords = new List<string>{
        "ACCESSIBLE",
        "ADD",
        "ALL",
        "ALTER",
        "ANALYZE",
        "AND",
        "AS",
        "ASC",
        "ASENSITIVE",
        "BEFORE",
        "BETWEEN",
        "BIGINT",
        "BINARY",
        "BLOB",
        "BOTH",
        "BY",
        "CALL",
        "CASCADE",
        "CASE",
        "CHANGE",
        "CHAR",
        "CHARACTER",
        "CHECK",
        "COLLATE",
        "COLUMN",
        "CONDITION",
        "CONSTRAINT",
        "CONTINUE",
        "CONVERT",
        "CREATE",
        "CROSS",
        "CUBE",
        "CUME_DIST",
        "CURRENT_DATE",
        "CURRENT_TIME",
        "CURRENT_TIMESTAMP",
        "CURRENT_USER",
        "CURSOR",
        "DATABASE",
        "DATABASES",
        "DAY_HOUR",
        "DAY_MICROSECOND",
        "DAY_MINUTE",
        "DAY_SECOND",
        "DEC",
        "DECIMAL",
        "DECLARE",
        "DEFAULT",
        "DELAYED",
        "DELETE",
        "DENSE_RANK",
        "DESC",
        "DESCRIBE",
        "DETERMINISTIC",
        "DISTINCT",
        "DISTINCTROW",
        "DIV",
        "DOUBLE",
        "DROP",
        "DUAL",
        "EACH",
        "ELSE",
        "ELSEIF",
        "EMPTY",
        "ENCLOSED",
        "ESCAPED",
        "EXCEPT",
        "EXISTS",
        "EXIT",
        "EXPLAIN",
        "FALSE",
        "FETCH",
        "FIRST_VALUE",
        "FLOAT",
        "FLOAT4",
        "FLOAT8",
        "FOR",
        "FORCE",
        "FOREIGN",
        "FROM",
        "FULLTEXT",
        "FUNCTION",
        "GENERATED",
        "GET",
        "GRANT",
        "GROUP",
        "GROUPING",
        "GROUPS",
        "HAVING",
        "HIGH_PRIORITY",
        "HOUR_MICROSECOND",
        "HOUR_MINUTE",
        "HOUR_SECOND",
        "IF",
        "IGNORE",
        "IN",
        "INDEX",
        "INFILE",
        "INNER",
        "INOUT",
        "INSENSITIVE",
        "INSERT",
        "INT",
        "INT1",
        "INT2",
        "INT3",
        "INT4",
        "INT8",
        "INTEGER",
        "INTERVAL",
        "INTO",
        "IO_AFTER_GTIDS",
        "IO_BEFORE_GTIDS",
        "IS",
        "ITERATE",
        "JOIN",
        "JSON_TABLE",
        "KEY",
        "KEYS",
        "KILL",
        "LAG",
        "LAST_VALUE",
        "LATERAL",
        "LEAD",
        "LEADING",
        "LEAVE",
        "LEFT",
        "LIKE",
        "LIMIT",
        "LINEAR",
        "LINES",
        "LOAD",
        "LOCALTIME",
        "LOCALTIMESTAMP",
        "LOCK",
        "LONG",
        "LONGBLOB",
        "LONGTEXT",
        "LOOP",
        "LOW_PRIORITY",
        "MASTER_BIND",
        "MASTER_SSL_VERIFY_SERVER_CERT",
        "MATCH",
        "MAXVALUE",
        "MEDIUMBLOB",
        "MEDIUMINT",
        "MEDIUMTEXT",
        "MIDDLEINT",
        "MINUTE_MICROSECOND",
        "MINUTE_SECOND",
        "MOD",
        "MODIFIES",
        "NATURAL",
        "NOT",
        "NO_WRITE_TO_BINLOG",
        "NTH_VALUE",
        "NTILE",
        "NULL",
        "NUMERIC",
        "OF",
        "ON",
        "OPTIMIZE",
        "OPTIMIZER_COSTS",
        "OPTION",
        "OPTIONALLY",
        "OR",
        "ORDER",
        "OUT",
        "OUTER",
        "OUTFILE",
        "OVER",
        "PARTITION",
        "PERCENT_RANK",
        "PRECISION",
        "PRIMARY",
        "PROCEDURE",
        "PURGE",
        "RANGE",
        "RANK",
        "READ",
        "READS",
        "READ_WRITE",
        "REAL",
        "RECURSIVE",
        "REFERENCES",
        "REGEXP",
        "RELEASE",
        "RENAME",
        "REPEAT",
        "REPLACE",
        "REQUIRE",
        "RESIGNAL",
        "RESTRICT",
        "RETURN",
        "REVOKE",
        "RIGHT",
        "RLIKE",
        "ROW",
        "ROWS",
        "ROW_NUMBER",
        "SCHEMA",
        "SCHEMAS",
        "SECOND_MICROSECOND",
        "SELECT",
        "SENSITIVE",
        "SEPARATOR",
        "SET",
        "SHOW",
        "SIGNAL",
        "SMALLINT",
        "SPATIAL",
        "SPECIFIC",
        "SQL",
        "SQLEXCEPTION",
        "SQLSTATE",
        "SQLWARNING",
        "SQL_BIG_RESULT",
        "SQL_CALC_FOUND_ROWS",
        "SQL_SMALL_RESULT",
        "SSL",
        "STARTING",
        "STORED",
        "STRAIGHT_JOIN",
        "SYSTEM",
        "TABLE",
        "TERMINATED",
        "THEN",
        "TINYBLOB",
        "TINYINT",
        "TINYTEXT",
        "TO",
        "TRAILING",
        "TRIGGER",
        "TRUE",
        "UNDO",
        "UNION",
        "UNIQUE",
        "UNLOCK",
        "UNSIGNED",
        "UPDATE",
        "USAGE",
        "USE",
        "USING",
        "UTC_DATE",
        "UTC_TIME",
        "UTC_TIMESTAMP",
        "VALUES",
        "VARBINARY",
        "VARCHAR",
        "VARCHARACTER",
        "VARYING",
        "VIRTUAL",
        "WHEN",
        "WHERE",
        "WHILE",
        "WINDOW",
        "WITH",
        "WRITE",
        "XOR",
        "YEAR_MONTH",
        "ZEROFILL"};

        private static readonly List<string> ReservedTopLevelWords =
            new List<string>{
                "ADD",
                "ALTER COLUMN",
                "ALTER TABLE",
                "DELETE FROM",
                "EXCEPT",
                "FROM",
                "GROUP BY",
                "HAVING",
                "INSERT INTO",
                "INSERT",
                "LIMIT",
                "ORDER BY",
                "SELECT",
                "SET",
                "UPDATE",
                "VALUES",
                "WHERE"};

        private static readonly List<string> ReservedTopLevelWordsNoIndent =
            new List<string> { "INTERSECT", "INTERSECT ALL", "MINUS", "UNION", "UNION ALL" };

        private static readonly List<string> ReservedNewlineWords =
            new List<string>{
                "AND",
                "ELSE",
                "OR",
                "WHEN",
                "JOIN",
                "INNER JOIN",
                "LEFT JOIN",
                "LEFT OUTER JOIN",
                "RIGHT JOIN",
                "RIGHT OUTER JOIN",
                "CROSS JOIN",
                "NATURAL JOIN",
                "STRAIGHT_JOIN",
                "NATURAL LEFT JOIN",
                "NATURAL LEFT OUTER JOIN",
                "NATURAL RIGHT JOIN",
                "NATURAL RIGHT OUTER JOIN"};

        public override DialectConfig DoDialectConfig()
        {
            return DialectConfig.Builder()
                .ReservedWords(ReservedWords)
                .ReservedTopLevelWords(ReservedTopLevelWords)
                .ReservedTopLevelWordsNoIndent(ReservedTopLevelWordsNoIndent)
                .ReservedNewlineWords(ReservedNewlineWords)
                .StringTypes(
                    new List<string>{
                        StringLiteral.DoubleQuote,
                        StringLiteral.SingleQuote,
                        StringLiteral.BackQuote,
                        StringLiteral.Bracket})
                .OpenParens(new List<string> { "(", "CASE" })
                .CloseParens(new List<string> { ")", "END" })
                .IndexedPlaceholderTypes(new List<string> { "?" })
                .NamedPlaceholderTypes(new List<string>())
                .LineCommentTypes(new List<string> { "--", "#" })
                .SpecialWordChars(new List<string> { "@" })
                .Operators(new List<string> { ":=", "<<", ">>", "!=", "<>", "<=>", "&&", "||", "->", "->>" })
                .Build();
        }

        public MySqlFormatter(FormatConfig cfg) : base(cfg)
        {
        }
    }
}
