using System;
using System.Runtime.CompilerServices;
using HoneycakeBasics.Config;
using UnityEngine;

namespace HoneycakeBasics.Ui
{
    public class ConfigToggleButton: ToggleButton
    {
        public string configPath;

        public bool onByDefault = false;

        protected new void Awake()
        {
            if (this.configPath.Length < 1)
            {
                return;
            }
            var value = ConfigManager.getInstance().getConfigInt(this.configPath, onByDefault ? 1 : 0) > 0
                ? true
                : false;
            this.GetComponent<ToggleButton>().setIsOn(value);
            ConfigManager.getInstance().bindOnChangeAction(configPath, manager =>
            {
                this.setIsOn(manager.getConfigInt(this.configPath, onByDefault ? 1 : 0) > 0);
            });
            base.Awake();
        }

        public new void toggle()
        {
            setIsOn(!getIsOn());
            ConfigManager.getInstance().setConfigInt(configPath, getIsOn() ? 1 : 0);
        }
    }
}