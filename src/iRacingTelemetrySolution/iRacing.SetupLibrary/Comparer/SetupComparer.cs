using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrackSession.Controls
{
    public class SetupViewBase
    {
        public class SetupValues
        {
            public IDictionary<string, IDictionary<string, string>> SetupGroups { get; set; }

            public SetupValues()
            {
                SetupGroups = new Dictionary<string, IDictionary<string, string>>();
            }
        }     
        public static SetupValues GetProperties(object src)
        {
            var setupVals = new SetupValues();

            foreach (var setupTypePath in iRacing.Constants.SetupGroupList)
            {
                var valueDictionary = new Dictionary<string, string>();

                var setupTypeInstance = GetPropertyValue(src, setupTypePath);
                PropertyInfo[] propertyInfos;
                var setupType = setupTypeInstance.GetType();
                propertyInfos = setupType.GetProperties();
                // sort properties by name
                Array.Sort(propertyInfos,
                        delegate (PropertyInfo propertyInfo1, PropertyInfo propertyInfo2)
                        { return propertyInfo1.Name.CompareTo(propertyInfo2.Name); });

                // write property names
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    var value = propertyInfo.GetValue(setupTypeInstance);
                    //Console.WriteLine("TypeName:{0};  Property:{1};  Value:{2}", setupType.Name, propertyInfo.Name, value);
                    valueDictionary.Add(propertyInfo.Name, value.ToString());
                }

                if (valueDictionary.Count > 0)
                    setupVals.SetupGroups.Add(setupTypePath, valueDictionary);
            }
            return setupVals;
        }
        public static object GetPropertyValue(object srcobj, string propertyName)
        {
            if (srcobj == null)
                return null;

            object obj = srcobj;

            // Split property name to parts (propertyName could be hierarchical, like obj.subobj.subobj.property
            string[] propertyNameParts = propertyName.Split('.');

            foreach (string propertyNamePart in propertyNameParts)
            {
                if (obj == null) return null;

                // propertyNamePart could contain reference to specific 
                // element (by index) inside a collection
                if (!propertyNamePart.Contains("["))
                {
                    PropertyInfo pi = obj.GetType().GetProperty(propertyNamePart);
                    if (pi == null) return null;
                    obj = pi.GetValue(obj, null);
                }
                else
                {   // propertyNamePart is areference to specific element 
                    // (by index) inside a collection
                    // like AggregatedCollection[123]
                    //   get collection name and element index
                    int indexStart = propertyNamePart.IndexOf("[") + 1;
                    string collectionPropertyName = propertyNamePart.Substring(0, indexStart - 1);
                    int collectionElementIndex = Int32.Parse(propertyNamePart.Substring(indexStart, propertyNamePart.Length - indexStart - 1));
                    //   get collection object
                    PropertyInfo pi = obj.GetType().GetProperty(collectionPropertyName);
                    if (pi == null) return null;
                    object unknownCollection = pi.GetValue(obj, null);
                    //   try to process the collection as array
                    if (unknownCollection.GetType().IsArray)
                    {
                        object[] collectionAsArray = unknownCollection as Array[];
                        obj = collectionAsArray[collectionElementIndex];
                    }
                    else
                    {
                        //   try to process the collection as IList
                        System.Collections.IList collectionAsList = unknownCollection as System.Collections.IList;
                        if (collectionAsList != null)
                        {
                            obj = collectionAsList[collectionElementIndex];
                        }
                        else
                        {
                            // ??? Unsupported collection type
                        }
                    }
                }
            }

            return obj;
        }
    }
}
