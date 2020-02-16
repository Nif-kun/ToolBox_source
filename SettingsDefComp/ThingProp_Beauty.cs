﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using RimWorld;
using UnityEngine;

namespace ToolBox.SettingsDefComp
{
    public class ThingProp_Beauty : ThingPropInput
    {
        /// <summary>
        /// Default beauty is incremented to 1 to fit with the input numbers.
        /// Original values from startup and live changes will follow the value rule of ToolBox
        /// instead of the Rimworld default (XMLval - 1 = beauty).
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref numSavedInt, "beauty");
        }

        public override void Preset(string defName)
        {
            if (numIntDefault.Count > 1)
            {
                numIntDefault[0] = numIntDefault[1];
                numInt = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
                if (numIntDefault.Count == 3)
                {
                    numInt = numIntDefault[2];
                }
            }
            else
            {
                numInt = numIntDefault[0] = Convert.ToInt32(ThingDef.Named(defName).GetStatValueAbstract(StatDefOf.Beauty));
            }
            base.Preset(defName);
        }

        public void Widget(string defName, float x, float y, float width, float min, float max)
        {
            if (load && draw)
            {
                Preset(defName);
            }
            if (!load && draw)
            {
                Widgets.TextFieldNumeric(new Rect(x, y, width, 22f), ref numInt, ref numBuffer, min, max);
                if (numInt == numIntDefault[0])
                {
                    config = '0';
                    numSavedInt = 0;
                }
                else
                {
                    config = '1';
                    numSavedInt = numInt;
                }
                ThingDef.Named(defName).SetStatBaseValue(StatDefOf.Beauty, numInt + 1);
            }
        }
    }
}
