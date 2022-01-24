/* -----------------------------------------------------------------------------
 * Rule_sign_in_with_ethereum.cs
 * -----------------------------------------------------------------------------
 *
 * Producer : com.parse2.aparse.Parser 2.5
 * Produced : Sat Dec 18 07:03:13 GMT 2021
 *
 * -----------------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;

sealed internal class Rule_sign_in_with_ethereum : Rule
{
    private Rule_sign_in_with_ethereum(String spelling, List<Rule> rules) :
    base(spelling, rules)
    {
    }

    internal override Object Accept(Visitor visitor)
    {
        return visitor.Visit(this);
    }

    internal static Rule_sign_in_with_ethereum Parse(ParserContext context)
    {
        context.Push("sign-in-with-ethereum");

        Rule rule;
        bool parsed = true;
        ParserAlternative b;
        int s0 = context.index;
        ParserAlternative a0 = new ParserAlternative(s0);

        List<ParserAlternative> as1 = new List<ParserAlternative>();
        parsed = false;
        {
            int s1 = context.index;
            ParserAlternative a1 = new ParserAlternative(s1);
            parsed = true;
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_domain.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, " wants you to sign in with your Ethereum account:");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_address.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    int g1 = context.index;
                    List<ParserAlternative> as2 = new List<ParserAlternative>();
                    parsed = false;
                    {
                        int s2 = context.index;
                        ParserAlternative a2 = new ParserAlternative(s2);
                        parsed = true;
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_statement.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_LF.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            as2.Add(a2);
                        }
                        context.index = s2;
                    }

                    b = ParserAlternative.GetBest(as2);

                    parsed = b != null;

                    if (parsed)
                    {
                        a1.Add(b.rules, b.end);
                        context.index = b.end;
                    }
                    f1 = context.index > g1;
                    if (parsed) c1++;
                }
                parsed = true;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, "URI: ");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_URI.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, "Version: ");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_version.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, "Chain ID: ");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_chain_id.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, "Nonce: ");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_nonce.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_LF.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Terminal_StringExactValue.Parse(context, "Issued At: ");
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    rule = Rule_issued_at.Parse(context);
                    if ((f1 = rule != null))
                    {
                        a1.Add(rule, context.index);
                        c1++;
                    }
                }
                parsed = c1 == 1;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    int g1 = context.index;
                    List<ParserAlternative> as2 = new List<ParserAlternative>();
                    parsed = false;
                    {
                        int s2 = context.index;
                        ParserAlternative a2 = new ParserAlternative(s2);
                        parsed = true;
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_LF.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Terminal_StringExactValue.Parse(context, "Expiration Time: ");
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_expiration_time.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            as2.Add(a2);
                        }
                        context.index = s2;
                    }

                    b = ParserAlternative.GetBest(as2);

                    parsed = b != null;

                    if (parsed)
                    {
                        a1.Add(b.rules, b.end);
                        context.index = b.end;
                    }
                    f1 = context.index > g1;
                    if (parsed) c1++;
                }
                parsed = true;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    int g1 = context.index;
                    List<ParserAlternative> as2 = new List<ParserAlternative>();
                    parsed = false;
                    {
                        int s2 = context.index;
                        ParserAlternative a2 = new ParserAlternative(s2);
                        parsed = true;
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_LF.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Terminal_StringExactValue.Parse(context, "Not Before: ");
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_not_before.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            as2.Add(a2);
                        }
                        context.index = s2;
                    }

                    b = ParserAlternative.GetBest(as2);

                    parsed = b != null;

                    if (parsed)
                    {
                        a1.Add(b.rules, b.end);
                        context.index = b.end;
                    }
                    f1 = context.index > g1;
                    if (parsed) c1++;
                }
                parsed = true;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    int g1 = context.index;
                    List<ParserAlternative> as2 = new List<ParserAlternative>();
                    parsed = false;
                    {
                        int s2 = context.index;
                        ParserAlternative a2 = new ParserAlternative(s2);
                        parsed = true;
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_LF.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Terminal_StringExactValue.Parse(context, "Request ID: ");
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_request_id.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            as2.Add(a2);
                        }
                        context.index = s2;
                    }

                    b = ParserAlternative.GetBest(as2);

                    parsed = b != null;

                    if (parsed)
                    {
                        a1.Add(b.rules, b.end);
                        context.index = b.end;
                    }
                    f1 = context.index > g1;
                    if (parsed) c1++;
                }
                parsed = true;
            }
            if (parsed)
            {
                bool f1 = true;
                int c1 = 0;
                for (int i1 = 0; i1 < 1 && f1; i1++)
                {
                    int g1 = context.index;
                    List<ParserAlternative> as2 = new List<ParserAlternative>();
                    parsed = false;
                    {
                        int s2 = context.index;
                        ParserAlternative a2 = new ParserAlternative(s2);
                        parsed = true;
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_LF.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Terminal_StringExactValue.Parse(context, "Resources:");
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            bool f2 = true;
                            int c2 = 0;
                            for (int i2 = 0; i2 < 1 && f2; i2++)
                            {
                                rule = Rule_resources.Parse(context);
                                if ((f2 = rule != null))
                                {
                                    a2.Add(rule, context.index);
                                    c2++;
                                }
                            }
                            parsed = c2 == 1;
                        }
                        if (parsed)
                        {
                            as2.Add(a2);
                        }
                        context.index = s2;
                    }

                    b = ParserAlternative.GetBest(as2);

                    parsed = b != null;

                    if (parsed)
                    {
                        a1.Add(b.rules, b.end);
                        context.index = b.end;
                    }
                    f1 = context.index > g1;
                    if (parsed) c1++;
                }
                parsed = true;
            }
            if (parsed)
            {
                as1.Add(a1);
            }
            context.index = s1;
        }

        b = ParserAlternative.GetBest(as1);

        parsed = b != null;

        if (parsed)
        {
            a0.Add(b.rules, b.end);
            context.index = b.end;
        }

        rule = null;
        if (parsed)
        {
            rule = new Rule_sign_in_with_ethereum(context.text.Substring(a0.start, a0.end - a0.start), a0.rules);
        }
        else
        {
            context.index = s0;
        }

        context.Pop("sign-in-with-ethereum", parsed);

        return (Rule_sign_in_with_ethereum)rule;
    }
}

/* -----------------------------------------------------------------------------
 * eof
 * -----------------------------------------------------------------------------
 */
