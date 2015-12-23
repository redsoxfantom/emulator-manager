using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmulatorManager.Components.ExecutionComponent
{
    public class Command
    {
        public String ExecutionPath { get; private set; }

        public String ExecutionArguments { get; private set; }

        public Boolean IsValidCommand { get; private set; }

        private ILog mLogger;

        /// <summary>
        /// Maps a replacement variable (of the form $VAR) to it's associated compiled regex
        /// </summary>
        private static Dictionary<string, Regex> mCachedRegexes = new Dictionary<string, Regex>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="executionPath">Path to the emulator</param>
        /// <param name="executionArgs">Arguments to the emulator with replacement variables</param>
        /// <param name="argReplacements">String of the form "$VAR=val;$VAR2=val", will be inserted into execution args</param>
        public Command(String executionPath, String executionArgs = "", String argReplacements = null)
        {
            mLogger = LogManager.GetLogger(GetType().Name);

            if (!String.IsNullOrEmpty(argReplacements))
            {
                if (argReplacements.Contains("=") && argReplacements.Contains(";"))
                {
                    ExecutionArguments = HandleArgumentReplacements(executionArgs, argReplacements);
                }
                else
                {
                    mLogger.WarnFormat("Replacement argument string was not in the correct format! Required format: \"$VAR=VAL;$VAR2=VAL2;etc\". Supplied replacement string was {0}", argReplacements);
                    ExecutionArguments = executionArgs;
                }
            }
            else
            {
                ExecutionArguments = executionArgs;
            }

            ExecutionPath = executionPath;
            IsValidCommand = true;
        }

        private string HandleArgumentReplacements(string executionArgs, string argReplacements)
        {
            Dictionary<Regex, string> NameValReplacements = ProcessReplacements(argReplacements);

            foreach(var varRegex in NameValReplacements.Keys)
            {
                string mappedValue = NameValReplacements[varRegex];
                mLogger.DebugFormat("Evaluating regex {0} (mapped to {1} on string {2}", varRegex,mappedValue,executionArgs);

                executionArgs = varRegex.Replace(executionArgs, mappedValue);
                mLogger.DebugFormat("Result of replacement was {0}",executionArgs);
            }

            return executionArgs;
        }

        /// <summary>
        /// Return a dictionary mapping a regex that recognizes "VAR" to its associated value
        /// </summary>
        /// <param name="argReplacements"></param>
        /// <returns></returns>
        private Dictionary<Regex, string> ProcessReplacements(string argReplacements)
        {
            Dictionary<Regex, string> retVal = new Dictionary<Regex, string>();

            foreach(var VarToNameReplacement in argReplacements.Split(';'))
            {
                String[] varName = VarToNameReplacement.Split('=');
                String var = varName[0];
                String name = varName[1];

                Regex varRegex;
                if(!mCachedRegexes.TryGetValue(var, out varRegex))
                {
                    varRegex = new Regex(var, RegexOptions.Compiled);
                    // Cache off the compiled regex to save time if we need it later
                    mCachedRegexes.Add(var,varRegex);
                }
                retVal.Add(varRegex, name);
            }

            return retVal;
        }

        public Command()
        {
            ExecutionPath = "";
            ExecutionArguments = "";
            IsValidCommand = false;
        }

        public override String ToString()
        {
            return String.Format("{0} {1}",ExecutionPath,ExecutionArguments);
        }
    }
}
