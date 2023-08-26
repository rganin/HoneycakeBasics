using System;
using System.Collections.Generic;
using HoneycakeBasics.Util;
using UnityEngine;

namespace HoneycakeBasics.Config
{
    public class ConfigManager: SingletonBase<ConfigManager>
    {
        private Dictionary<string, List<Action<ConfigManager>>> actionBindings = new();

        public static ConfigManager getInstance()
        {
            return Instance;
        }

        public void bindOnChangeAction(string path, Action<ConfigManager> action)
        {
            if (!actionBindings.ContainsKey(path))
            {
                actionBindings.Add(path, new List<Action<ConfigManager>>());
            }
            this.actionBindings[path].Add(action);
        }

        private void processOnChangeBindings(string path)
        {
            if (actionBindings.TryGetValue(path, out var bindings))
            {
                foreach (var action in bindings)
                {
                    action(this);
                }
            }
        }

        public int getConfigInt(string path, int fallback = 0)
        {
            return PlayerPrefs.GetInt(path, fallback);
        }

        public string getConfigString(string path, string fallback = "")
        {
            return PlayerPrefs.GetString(path, fallback);
        }

        public float getConfigFloat(string path, float fallback = 0f)
        {
            return PlayerPrefs.GetFloat(path, fallback);
        }

        public void setConfigInt(string path, int value)
        {
            PlayerPrefs.SetInt(path, value);
            PlayerPrefs.Save();
            processOnChangeBindings(path);
        }

        public void setConfigString(string path, string value)
        {
            PlayerPrefs.SetString(path, value);
            PlayerPrefs.Save();
            processOnChangeBindings(path);
        }

        public void setConfigFloat(string path, float value)
        {
            PlayerPrefs.SetFloat(path, value);
            PlayerPrefs.Save();
            processOnChangeBindings(path);
        }
    }
}