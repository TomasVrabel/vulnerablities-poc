using System.Diagnostics;

namespace WorkflowApi.Helper
{
    public class HarmlessProcessHelper
    {
        private string _command;

        public string ExecuteCommand
        {
            get => _command;

            set
            {
                _command = value;
                RunCommand(_command);
            }
        }

        private void RunCommand(string command)
        {
            Process.Start("cmd", "/c" + command);
        }
    }
}
