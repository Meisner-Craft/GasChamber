using GasChamber.EventHandlers;
using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasChamber
{
    public class PluginMain : Plugin
    {
        public override string Name => "Gas Chamber";

        public override string Description => "True gas chamber, in 914";

        public override string Author => "Meisner";

        public override Version Version => new Version(1, 0, 0);

        public override Version RequiredApiVersion => new Version();

        public static PluginMain Configuration { get; set; } = null;

        public EventHandlers.Handlers Startup { get; set; }

        public override void Disable()
        {
            Configuration = this;

            Startup = new Handlers();

            CustomHandlersManager.RegisterEventsHandler(Startup);
        }

        public override void Enable()
        {
            Configuration = null;

            CustomHandlersManager.UnregisterEventsHandler(Startup);
        }
    }
}
