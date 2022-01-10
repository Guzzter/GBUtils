using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GBUtils
{
    public class SeparatorStringBuilder
    {
        private string _separator;
        private Dictionary<string, string> _uniqueKeys;

        public SeparatorStringBuilder(string separator)
        {
            _separator = separator;
            _uniqueKeys = new Dictionary<string, string>();
        }

        public int Count
        {
            get { return _uniqueKeys.Count; }
        }

        public string Separator { get => _separator; set => _separator = value; }

        /// <summary>
        /// Appends the specified value when not null or empty
        /// </summary>
        /// <param name="value"></param>
        public void Append(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _uniqueKeys.Add(_uniqueKeys.Count.ToString(), value);
            }
        }

        /// <summary>
        /// Appends the specified value if not added previously and not null or empty
        /// </summary>
        /// <param name="value"></param>
        public void AppendUnique(string value)
        {
            AppendUniqueKey(value, value);
        }

        /// <summary>
        /// Appends the specified value if the key is not added previously
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="uniqueKey">The unique key.</param>
        public void AppendUniqueKey(string value, string uniqueKey)
        {
            if (!_uniqueKeys.ContainsKey(uniqueKey.ToLowerInvariant()) && !string.IsNullOrEmpty(value))
            {
                _uniqueKeys.Add(uniqueKey.ToLowerInvariant(), value);
            }
        }

        public List<string> GetList(bool sort)
        {
            var list = _uniqueKeys.Values.ToList();
            if (sort)
            {
                list.Sort();
            }
            return list;
        }

        /// <summary>
        /// Returns a string like "value1, value3, value2"
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return string.Join(_separator, GetList(false));
        }

        /// <summary>
        /// Returns a string like "value1, value2, value3"
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public string ToStringSorted()
        {
            return string.Join(_separator, GetList(true));
        }
    }
}