﻿using Xunit;

namespace System.Security.Permissions.Tests
{
    public class MembershipConditionTests
    {
        [Fact]
        public static void AllMembershipConditionCallMethods()
        {
            Policy.AllMembershipCondition amc = new Policy.AllMembershipCondition();
            bool check = amc.Check(new Policy.Evidence());
            Policy.IMembershipCondition imc = amc.Copy();
            check = amc.Equals(new object());
            int hash = amc.GetHashCode();
            string str = amc.ToString();
        }
        [Fact]
        public static void ApplicationDirectoryMembershipConditionCallMethods()
        {
            Policy.ApplicationDirectoryMembershipCondition admc = new Policy.ApplicationDirectoryMembershipCondition();
            bool check = admc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = admc.Copy();
            check = admc.Equals(new object());
            int hash = admc.GetHashCode();
            string str = admc.ToString();
        }
        [Fact]
        public static void GacMembershipConditionCallMethods()
        {
            Policy.GacMembershipCondition gmc = new Policy.GacMembershipCondition();
            bool check = gmc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = gmc.Copy();
            check = gmc.Equals(new object());
            int hash = gmc.GetHashCode();
            string str = gmc.ToString();
        }
        [Fact]
        public static void HashMembershipConditionCallMethods()
        {
            Policy.HashMembershipCondition hmc = new Policy.HashMembershipCondition(Cryptography.SHA1.Create(), new byte[1]);
            bool check = hmc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = hmc.Copy();
            check = hmc.Equals(new object());
            int hash = hmc.GetHashCode();
            string str = hmc.ToString();
        }
        [Fact]
        public static void PublisherMembershipConditionCallMethods()
        {
            Policy.PublisherMembershipCondition pmc = new Policy.PublisherMembershipCondition(new System.Security.Cryptography.X509Certificates.X509Certificate());
            bool check = pmc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = pmc.Copy();
            check = pmc.Equals(new object());
            int hash = pmc.GetHashCode();
            string str = pmc.ToString();
        }
        [Fact]
        public static void SiteMembershipConditionCallMethods()
        {
            Policy.SiteMembershipCondition smc = new Policy.SiteMembershipCondition("test");
            bool check = smc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = smc.Copy();
            check = smc.Equals(new object());
            int hash = smc.GetHashCode();
            string str = smc.ToString();
        }
        [Fact]
        public static void StrongNameMembershipConditionCallMethods()
        {
            Policy.StrongNameMembershipCondition snmc = new Policy.StrongNameMembershipCondition(new StrongNamePublicKeyBlob(new byte[1]), "test", new System.Version(0,1));
            bool check = snmc.Check(new Policy.Evidence());
            Policy.IMembershipCondition obj = snmc.Copy();
            check = snmc.Equals(new object());
            int hash = snmc.GetHashCode();
            string str = snmc.ToString();
        }
    }
}
