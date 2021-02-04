using System;
using System.Collections.Generic;
using System.Text;

namespace net.holmedal
{
    public class UserAvalableArgs : EventArgs
    {
#nullable enable
        private string? _Username,_Password;
        private int? _Vlan;
        public String Usernmae { get { return _Username; } }
        public String Password { get { return _Password; } }
        public int? Vlan { get { return _Vlan; } }
        public UserAvalableArgs(String? Username,string? Password,int? Vlan)
        {
            _Username = Username;
            _Password = Password;
            _Vlan = Vlan;
        }
    }
}
