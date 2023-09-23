﻿using SQL.Formatter.Core.Util;

namespace SQL.Formatter.Core
{
    public class InlineBlock
    {
        private int level;
        private readonly int maxColumnLength;

        public InlineBlock(int maxColumnLength)
        {
            this.maxColumnLength = maxColumnLength;
            level = 0;
        }

        public void BeginIfPossible(JSLikeList<Token> tokens, int index)
        {
            if (level == 0 && IsInlineBlock(tokens, index))
            {
                level = 1;
            }
            else if (level > 0)
            {
                level++;
            }
            else
            {
                level = 0;
            }
        }

        public void End()
        {
            level--;
        }

        public bool IsActive()
        {
            return level > 0;
        }

        private bool IsInlineBlock(JSLikeList<Token> tokens, int index)
        {
            int length = 0;
            int level = 0;

            for (int i = index; i < tokens.Size(); i++)
            {
                Token token = tokens.Get(i);
                length += token.value.Length;

                if (length > maxColumnLength)
                {
                    return false;
                }

                if (token.type == TokenTypes.OPEN_PAREN)
                {
                    level++;
                }
                else if (token.type == TokenTypes.CLOSE_PAREN)
                {
                    level--;
                    if (level == 0)
                    {
                        return true;
                    }
                }

                if (IsForbiddenToken(token))
                {
                    return false;
                }
            }

            return false;
        }

        private bool IsForbiddenToken(Token token)
        {
            return token.type == TokenTypes.RESERVED_TOP_LEVEL
                || token.type == TokenTypes.RESERVED_NEWLINE
                || token.type == TokenTypes.BLOCK_COMMENT
                || token.value.Equals(";");
        }
    }
}
