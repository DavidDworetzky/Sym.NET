using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymNet.Core.SymConnectMessage
{
    public class SymConnectResponseMessage
    {
        private string _id;

        public string Id
        {
            get { return _id; }
        }

        private ResponseCode _responseCode;

        public ResponseCode ResponseCode
        {
            get { return _responseCode; }
        }

        private SymConnectMessageType _messageType;

        public SymConnectMessageType MessageType
        {
            get { return _messageType; }
        }

        private IEnumerable<KeyValuePair<string, string>> _fields;

        public IEnumerable<KeyValuePair<string, string>> Fields
        {
            get { return _fields; }
        }

        public string RawContent { get; }

        public SymConnectResponseMessage(string responseString)
        {
            try
            {
                RawContent = responseString;
                //split on tildas
                List<string> raw = responseString.Split('~').ToList();

                //parse message type
                SymConnectMessageType messageType;
                if (!SymConnectMessageType.TryParse(raw[0].Substring(2), out messageType))
                {
                    throw new Exception($"{raw[0].Substring(2)} is an invalid Message Type");
                }
                _messageType = messageType;

                string responseCode = raw.Single(slice => slice.StartsWith("K"));
                string responseCodeValue = responseCode.Substring(1).Split(':')[0];
                //parse out response code
                ResponseCode code;
                if (!ResponseCode.TryParse(responseCodeValue, out code))
                {
                    throw new Exception($"{responseCodeValue} is not contained in list of response codes");
                }
                _responseCode = code;

                //parse out Id
                //the ID is the first message element after the RS response component
                string preMessagePart = raw.First(element => element.StartsWith("RS"));
                int preMessagePartIndex = raw.ToList().IndexOf(preMessagePart);

                string idValue = raw[preMessagePartIndex + 1];
                _id = idValue;


                //now parse out J fields, or all response variables 
                _fields = raw.Where(element => element.StartsWith("J"))
                    .Select(
                        fragment =>
                            //each J Value is split by an equal sign to denote a key value pair relationship.
                            new KeyValuePair<string, string>(fragment.Split('=').First(), fragment.Split('=').Last()));

            }
            catch (Exception ex)
            {
                throw new Exception($"{responseString} is an invalid SymConnectResponseMessage", ex);
            }

        }
    }
}
