﻿namespace ToolBox.SettingsDefComp
{
    public class CostCol : BaseProp
    {
        public new string header = "Cost";
        public new float headerPos = 5f;
        public new float width = 40f;
        public float min = 1f;
        public float max = 9999f;

        public override void Header()
        {
            base.header = header;
            base.headerPos = headerPos;
            base.width = width;
            base.Header();
        }
    }
}
