using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFoundations
{
    public static class Utility
    {
        #region Methods
        
        public static bool IsObsolete(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (ObsoleteAttribute[])
                fi.GetCustomAttributes(typeof(ObsoleteAttribute), false);
            return (attributes != null && attributes.Length > 0);
        }

        public static List<T> MaskToList<T>(List<T> _list, int _mask)
        {
            List<T> returnValues = new List<T>(); ;
            for (int i = 0; i < _list.Count; i++)
                if ((_mask & (1 << i)) == (1 << i)) returnValues.Add(_list[i]);
            return returnValues;
        }

        public static int ListToMask<T>(List<T> _list, List<T> _listSelected)
        {
            int returnValue = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                if (_listSelected.Contains(_list[i]))
                    returnValue |= 1 << i;
            }
            return returnValue;
        }

        #endregion
    }
}