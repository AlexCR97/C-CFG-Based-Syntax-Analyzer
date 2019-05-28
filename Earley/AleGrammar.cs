using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFGParser
{
    class AleGrammar : Grammar
    {
        public override void initStartRules()
        {
            var rules = new List<string>()
            {
                "if ( <condition> ) { <statement> }",
                "if ( <condition> ) { <statement> } else { <statement> }",
            };
            addStartRules(rules);
        }

        public override void initProductionRules()
        {
            var conditionRules = new List<string>()
            {
                "<id> <relational-operator> <id>",
                "<id> <relational-operator> <number>",
                "<number> <relational-operator> <number>",
            };
            addProductionRules("<condition>", conditionRules);

            addProductionRule("<id>", "var0 var1 var2 var3 var4 var5 var6 var7 var8 var9");

            addProductionRule("<relational-operator>", "> < == >= <= !=");

            addProductionRule("<number>", "0 1 2 3 4 5 6 7 8 9");

            var statementRules = new List<string>()
            {
                "<type> <id> ;",
                "<type> <id> = <id> ;",
                "<type> <id> = <number> ;",
                "<type> <id> = <function-call> ;",
                "<id> = <id> ;",
                "<id> = <number> ;",
                "<id> = <function-call> ;",
                "<function-call> ;",
            };
            addProductionRules("<statement>", statementRules);

            addProductionRule("<type>", "int float double char string bool");

            var functionCallRules = new List<string>()
            {
                "<id> ( )",
                "<id> . <id> ( )",
            };
            addProductionRules("<function-call>", functionCallRules);

            addProductionRule("if", "if");
            addProductionRule("else", "else");
            addProductionRule("=", "=");
            addProductionRule(";", ";");
            addProductionRule(".", ".");
            addProductionRule("(", "(");
            addProductionRule(")", ")");
            addProductionRule("{", "{");
            addProductionRule("}", "}");
        }

        public override void initPOS()
        {
            addPOS("<id>");
            addPOS("<relational-operator>");
            addPOS("<number>");
            addPOS("<type>");

            addPOS("if");
            addPOS("else");
            addPOS("=");
            addPOS(";");
            addPOS(".");
            addPOS("(");
            addPOS(")");
            addPOS("{");
            addPOS("}");
        }
    }
}
