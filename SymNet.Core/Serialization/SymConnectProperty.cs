using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.Serialization
{
    /// <summary>
    /// Member Level Serialization of SymConnect Properties
    /// </summary>
    public class SymConnectProperty : System.Attribute
    {
        internal string _propertyName;

        /// <summary>
        /// Whether or not a subclass is serialized directly or its members are serialized
        /// </summary>
        internal bool _isSubRecord;

        /// <summary>
        /// Whether or not this represents a SymConnect Array Type
        /// </summary>
        internal bool _isArray;

        /// <summary>
        /// Whether or not this is a template property, aka, warnings
        /// </summary>
        internal bool _isTemplate;

        /// <summary>
        /// Number of repeated elements
        /// </summary>
        internal int _arraySize;

        /// <summary>
        /// Whether we should use the property name instead of our override
        /// </summary>
        public bool UseDefault
        {
            get { return _propertyName == String.Empty; }
        }


        /// <summary>
        /// SymConnectSerializationProperty 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="isSubRecord"></param>
        public SymConnectProperty(string propertyName = "", int arraySize = 1, bool isSubRecord = false, bool isTemplate = false)
        {
            _propertyName = propertyName;
            _isSubRecord = isSubRecord;
            _isArray = arraySize > 1;
            _arraySize = arraySize;
            _isTemplate = isTemplate;

        }


    }
}
