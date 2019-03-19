﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Scripts.BingMapClassesLocator
{

    [System.Serializable]
    public class BingMapsClassesLocator : MonoBehaviour
    {

        private string addressStreet;
        public static T[] getJsonArray<T>(string JSONString)
        {
            string newJsonStringA = "{\"array\": " + JSONString + "}";
            WrapperA<T> wrapperA = JsonUtility.FromJson<WrapperA<T>>(newJsonStringA);
            return wrapperA.array;
        }

        public static RootObjectAddress getRootObjectAddress(string JSONString)
        {
            return JsonUtility.FromJson<RootObjectAddress>(JSONString);
        }

        private class WrapperA<T>
        {
            public T[] array;
        }

        [System.Serializable]
        public class RootObjectAddress
        {
            public List<resourceSets> resourceSets;
        }

        [System.Serializable]
        public class resourceSets
        {
            public List<resources> resources;

        }

        [System.Serializable]
        public class resources
        {
            public address address;

        }

        [System.Serializable]
        public class address
        {
            public string addressLine;

        }

        public string requestAddressFromBingMaps(string latLong)
        {
            string obtainedAddress = "";
            string bingMapsApiKeyA = "Aul2Lj8luxSAtsuBPTb0qlqhXc6kwdTZvQGvGkOc_h_Jg3HI_2F-V6BeeHwHZZ4E";
            string queryAddressURL = generateAddressQueryUrl(latLong, bingMapsApiKeyA);
            WWW requestAddress = new WWW(queryAddressURL);
            float startTimeB = Time.time;
            while (requestAddress.isDone == false)
            {
                if (Time.time - startTimeB > 10)
                {
                    Debug.Log("API TIMEOUT");
                    break;
                }
            }

            if (requestAddress.isDone)
            {
                string jsonAddress = System.Text.Encoding.UTF8.GetString(requestAddress.bytes, 0, requestAddress.bytes.Length);
                Debug.Log(jsonAddress);
                BingMapsClassesLocator.RootObjectAddress rootObjectAddress = BingMapsClassesLocator.getRootObjectAddress(jsonAddress);
                obtainedAddress = rootObjectAddress.resourceSets[0].resources[0].address.addressLine;
                Debug.Log(obtainedAddress);
                this.addressStreet = obtainedAddress;
                Debug.Log(obtainedAddress);
                return obtainedAddress;
            }
            return obtainedAddress;
        }

        public void requestAddressTest()
        {
            string latLong = "51.52468,-0.133656";
            string q = requestAddressFromBingMaps(latLong);
        }

        public string generateAddressQueryUrl(string latLong, string apiKey)
        {
            string staticAddresspoint = "http://dev.virtualearth.net/REST/v1/Locations";
            string queryAddressURL = (string.Format("{0}/{1}?includeEntityTypes=Address&o=json&key={2}", staticAddresspoint, latLong, apiKey));
            Debug.Log(queryAddressURL);
            return queryAddressURL;
        }
    }
}