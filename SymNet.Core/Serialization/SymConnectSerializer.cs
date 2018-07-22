using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SymNet.Core.SymConnectMessage;

namespace SymNet.Core.Serialization
{
    public class SymConnectSerializer
    {
        #region PrivateMember
        private int _symConnectStringSize;

        private bool _forceIQSerialization;

        private int _unitNumber;

        private string _vendorName;

        private string _cardNumber;
        #endregion

        #region Constructors
        /// <summary>
        /// SymConnect Serializer - symConnectStringSize determines the max string size sent over 
        /// </summary>
        /// <param name="symConnectStringSize"></param>
        /// <param name="forceIQSerialization"></param>
        public SymConnectSerializer(int symConnectStringSize, bool forceIQSerialization, int unitNumber, string vendorName, string cardNumber)
        {
            _symConnectStringSize = symConnectStringSize;
            _forceIQSerialization = forceIQSerialization;
            _unitNumber = unitNumber;
            _vendorName = vendorName;
            _cardNumber = cardNumber;

        }
        #endregion

        #region Helpers
        /// <summary>
        /// Generic helper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodName"></param>
        /// <param name="genericType"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static object InvokeGenericMethod<T>(string methodName, Type genericType, object obj)
        {
            MethodInfo method = typeof(T).GetMethod(methodName);
            MethodInfo generic = method.MakeGenericMethod(genericType);
            var result = generic.Invoke(obj, null);
            return result;
        }

        /// <summary>
        /// Gets the SymConnectProperty attribute on a property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static SymConnectProperty GetSymConnectProperty(PropertyInfo property)
        {
            var attributes = Attribute.GetCustomAttributes(property);
            return (SymConnectProperty)attributes.SingleOrDefault(element => element is SymConnectProperty);
        }

        private static SymConnectObject GetSymConnectObject(object obj)
        {
            Type type = obj.GetType();
            var mainAttributes = Attribute.GetCustomAttributes(type);
            var objectAttribute = mainAttributes.SingleOrDefault(attr => attr is SymConnectObject) as SymConnectObject;

            return objectAttribute;

        }

        /// <summary>
        /// Helper/Constructor
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static KeyValuePair<SymConnectProperty, PropertyInfo> GetSymConnectLookup(PropertyInfo property)
        {
            return new KeyValuePair<SymConnectProperty, PropertyInfo>(GetSymConnectProperty(property), property);
        }

        #endregion

        private static IEnumerable<KeyValuePair<SymConnectProperty, System.Reflection.PropertyInfo>> GetAllSymConnectProperties<T>(T obj)
        {
            //get all properties by recursively walking the class' type relationships
            Type type = obj.GetType();
            var objectAttribute = GetSymConnectObject(obj);

            //we need the symconnect level property information as well as the property for proper serialization
            var propertyInformation = new List<KeyValuePair<SymConnectProperty, System.Reflection.PropertyInfo>>();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var subType = property.GetType();

                //get attributes
                var attributes = Attribute.GetCustomAttributes(property);

                //if its decorated as a symconnect property, its a leaf or its children are leaves
                if (attributes.Any(element => element is SymConnectProperty))
                {
                    var attr = attributes.Single(element => element is SymConnectProperty) as SymConnectProperty;
                    //if its a symconnect subrecord , take its subtypes as a leaf.  
                    if (attr._isSubRecord)
                    {
                        //children are terminal nodes
                        var subProperties = subType.GetProperties();
                        propertyInformation.AddRange(subProperties.Select(GetSymConnectLookup));
                    }
                    else
                    {
                        //terminal node
                        propertyInformation.Add(GetSymConnectLookup(property));
                    }
                }
                else if (attributes.Any(element => element is SymConnectObject))
                {
                    //if its a SymConnect Object, then we have to walk this record recursively to get the next layer of calls... 
                    var attr = attributes.Single(element => element is SymConnectObject) as SymConnectObject;
                    var propertyValue = property.GetValue(obj, null);

                    //get and invoke generic method on this property type
                    var subPropertyType = propertyValue.GetType();

                    //Get all symconnect properties of the sub proeprty
                    propertyInformation.AddRange((KeyValuePair<SymConnectProperty, PropertyInfo>[])InvokeGenericMethod<SymConnectSerializer>("GetAllSymConnectProperties", subPropertyType, null));
                }
                else
                {
                    //check if we have implicit or explicit serialization, then add this property if implicit
                    if (objectAttribute._serializationType == SymConnectObjectSerialization.Implicit)
                    {
                        propertyInformation.Add(GetSymConnectLookup(property));
                    }

                }
            }
            return propertyInformation;
        }

        private SymConnectObject ValidateSymConnectSerializable<T>(T obj)
        {
            var symObj = GetSymConnectObject(obj);
            if (symObj == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                        "Cannot serialize an object of type {0} as a SymConnect IQ string. Not a valid SymConnectObject",
                        typeof(T).FullName));
            }

            return symObj;
        }


        /// <summary>
        /// Convert to symconnect get returns a function (taking our account / record lookup) that returns a formatted symconnect string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Func<SymConnectMessage.SymConnectRequestMessage.RecordDesignation, string> ConvertToSymConnectGet<T>(T obj)
        {
            var symObj = ValidateSymConnectSerializable(obj);

            bool RunAsRG = !_forceIQSerialization && !String.IsNullOrEmpty(symObj._repgenName);

            if (RunAsRG)
            {
                return ((designation) =>
                {
                    return new SymConnectRequestMessage(_unitNumber, SymConnectMessageType.RG, _vendorName, _cardNumber,
                        designation.Locator,
                        new SymConnectRequestMessage.RepgenInfo(symObj._repgenName, 0, new Dictionary<string, string>() { { "RGUSERCHR1", designation.Locator } }))
                        .ToString();
                });
            }
            else
            {
                //get fields to retrieve by walking our record structure
                var nodes = GetAllSymConnectProperties(obj);
                var fields = nodes.Select(kvp => kvp.Key._propertyName ?? kvp.Value.Name);
                return ((designation) =>
                {
                    return
                        new SymConnectRequestMessage(_unitNumber, SymConnectMessageType.IQ, _vendorName, _cardNumber,
                            designation.Locator, new List<SymConnectRequestMessage.RecordDesignation>() { designation },
                            fields)
                            .ToString();

                });
            }
        }

        /// <summary>
        /// Creates or revises a symconnect record from our object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fmType"></param>
        /// <returns></returns>
        public Func<SymConnectMessage.SymConnectRequestMessage.RecordDesignation, string> ConvertToSymConnectPost<T>(T obj, SymConnectFMType fmType)
        {
            var symObj = ValidateSymConnectSerializable(obj);

            //get all the changed fields via our model
            var nodes = GetAllSymConnectProperties(obj);
            var changes = nodes.ToDictionary((kvp) => kvp.Key._propertyName ?? kvp.Value.Name, (kvp2) => kvp2.Value.GetValue(obj, null).ToString());

            return ((designation) =>
            {
                return new SymConnectRequestMessage(_unitNumber, SymConnectMessageType.FM, _vendorName,
                    designation.Locator, _cardNumber,
                    new List<SymConnectRequestMessage.RecordDesignation>() { designation }, changes, fmType).ToString();
            });
        }

        public T ConvertFromSymConnectGet<T>(string symConnectString) where T : new()
        {
            var symConnectResponse = new SymConnectResponseMessage(symConnectString);

            if (symConnectResponse.MessageType == SymConnectMessageType.RG)
            {
                //aggregate lines and deserialize our response object
                string fullContent = symConnectResponse.Fields.Aggregate(String.Empty, (str, kvp) => str + kvp.Value);

                T symconnectObject = JsonConvert.DeserializeObject<T>(fullContent);

                return symconnectObject;

            }
            else if (symConnectResponse.MessageType == SymConnectMessageType.IQ)
            {
                T symconnectObject = new T();
                //new up the object with the default constructor 
                //use reflection and returned fields to inject properties
                foreach (var returnedField in symConnectResponse.Fields)
                {
                    var property = typeof(T).GetProperty(returnedField.Key);
                    property.SetValue(symconnectObject, returnedField.Value, null);

                }

                return symconnectObject;
            }
            else
            {
                //we are trying to deserialize from an invalid symconnect message. 
                throw new InvalidOperationException(
                    String.Format("Cannot deserialize symconnect string of message type {0} to object of type {1}.",
                        symConnectResponse.MessageType, typeof(T).Name));
            }
        }
    }
}
