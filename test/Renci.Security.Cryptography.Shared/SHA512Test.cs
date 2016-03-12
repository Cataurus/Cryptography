﻿using System.Text;
using Renci.Common.Tests;
using Renci.Security.Cryptography;
using Xunit;

namespace Renci.SshNet.Tests.Classes.Security.Cryptography.Hashes
{
    /// <summary>
    /// Test cases are from http://csrc.nist.gov/groups/ST/toolkit/documents/Examples/SHA_All.pdf
    /// </summary>
    public class SHA512Test
    {
        private readonly SHA512 _hashAlgorithm;

        public SHA512Test()
        {
            _hashAlgorithm = new SHA512();
        }

        [Fact]
        public void Fips180_1()
        {
            var data = Encoding.ASCII.GetBytes("abc");
            var expectedHash = ByteExtensions.HexToByteArray("ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f");

            var actualHash = _hashAlgorithm.ComputeHash(data);

            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void Fips180_2()
        {
            var data = Encoding.ASCII.GetBytes("abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu");
            var expectedHash = ByteExtensions.HexToByteArray("8e959b75dae313da8cf4f72814fc143f8f7779c6eb9f7fa17299aeadb6889018501d289e4900f7e4331b99dec4b5433ac7d329eeb6dd26545e96e55b874be909");

            var actualHash = _hashAlgorithm.ComputeHash(data);

            Assert.Equal(expectedHash, actualHash);
        }

        [Fact]
        public void Fips180_3()
        {
            var data = Encoding.ASCII.GetBytes(new string('a', 1000000));
            var expectedHash = ByteExtensions.HexToByteArray("e718483d0ce769644e2e42c7bc15b4638e1f98b13b2044285632a803afa973ebde0ff244877ea60a4cb0432ce577c31beb009c5c2c49aa2e4eadb217ad8cc09b");

            var actualHash = _hashAlgorithm.ComputeHash(data);

            Assert.Equal(expectedHash, actualHash);
        }
    }
}
