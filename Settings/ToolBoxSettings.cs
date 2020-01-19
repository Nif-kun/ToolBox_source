﻿using System.Collections.Generic;
using System.Linq;
using ToolBox.SettingsComp;
using Verse;

namespace ToolBox.Settings
{
    public class ToolBoxSettings : ModSettings
    {
        public List<Container> containers = new List<Container>();
        public override void ExposeData()
        {
            containers = DefDatabase<CategoryDef>.AllDefs.SelectMany(x => x.drawContent).ToList();
            Scribe_Collections.Look(ref containers, "Container", LookMode.Deep);
            base.ExposeData();
        }
    }
}