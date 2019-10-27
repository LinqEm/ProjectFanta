using Newtonsoft.Json;

namespace ProjectFanta.Models
{

    public class CreateGroupModel
    {

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

    }

}
