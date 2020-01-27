using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// Fuchsia Information Engine Core Initalisation
/// 
/// 2020-01-20
/// 
/// </summary>
namespace Fuchsia.InformationEngine
{
    partial class FInfoEngine
    {
        internal FMXamlReader FMXamlReader { get; set; }
        public FInfoEngine()
        {
            FMXamlReader = new FMXamlReader(); 
        }
    }
}
