using System.Collections.Concurrent;

namespace Lumel.Services
{
    public class Identity
    {
        public int identityId { get; set; }
        public string displayName { get; set; }
        public int IdentityType { get; set; }
        public Identity(int identityId,string displayName)
        {
            this.identityId = identityId;
            this.displayName = displayName;
        }
    }
    public class IdentityService
    {
        public static ConcurrentDictionary<int, Identity> data = new ConcurrentDictionary<int, Identity>()
        {
            [1] = new Identity(1,"alex"),
            [2] = new Identity(1,"bob"),
        };
        public static Identity GetIdentityObject(int identity)
        {
            if (data.ContainsKey(identity) == false) throw new Exception("Identity not found");
            return data[identity];
        }
    }
}
