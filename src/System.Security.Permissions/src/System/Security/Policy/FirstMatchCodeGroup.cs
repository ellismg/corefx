﻿namespace System.Security.Policy
{
    public sealed partial class FirstMatchCodeGroup : System.Security.Policy.CodeGroup
    {
        public FirstMatchCodeGroup(System.Security.Policy.IMembershipCondition membershipCondition, System.Security.Policy.PolicyStatement policy) : base(default(System.Security.Policy.IMembershipCondition), default(System.Security.Policy.PolicyStatement)) { }
        public override string MergeLogic { get { return default(string); } }
        public override System.Security.Policy.CodeGroup Copy() { return default(System.Security.Policy.CodeGroup); }
        public override System.Security.Policy.PolicyStatement Resolve(System.Security.Policy.Evidence evidence) { return default(System.Security.Policy.PolicyStatement); }
        public override System.Security.Policy.CodeGroup ResolveMatchingCodeGroups(System.Security.Policy.Evidence evidence) { return default(System.Security.Policy.CodeGroup); }
    }
}
