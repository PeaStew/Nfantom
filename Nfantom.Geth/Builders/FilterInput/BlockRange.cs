﻿using Nfantom.Hex.HexTypes;
using System;
using System.Numerics;

namespace Nfantom.Opera.Builders.FilterInput
{
    public struct BlockRange :
        IEquatable<BlockRange>
    {
        private readonly int _hashCode;

        public BlockRange(ulong from, ulong to) :
            this(new BigInteger(from), new BigInteger(to))
        {
        }

        public BlockRange(BigInteger from, BigInteger to) :
            this(new HexBigInteger(from), new HexBigInteger(to))
        {
        }

        public BlockRange(HexBigInteger from, HexBigInteger to)
        {
            From = from ?? throw new ArgumentNullException(nameof(from));
            To = to ?? throw new ArgumentNullException(nameof(to));
            BlockCount = To.Value - From.Value + 1;
            _hashCode = new { From, To }.GetHashCode();
        }


        public HexBigInteger From { get; }
        public HexBigInteger To { get; }
        public BigInteger BlockCount { get; }

        public bool Equals(BlockRange other)
        {
            return From.Value.Equals(other.From.Value) &&
                To.Value.Equals(other.To.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is BlockRange other)
            {
                return Equals(other);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _hashCode;
        }
    }
}