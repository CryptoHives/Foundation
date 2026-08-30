// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;

/// <summary>
/// Defines a short Weierstrass elliptic curve: y² = x³ + ax + b (mod p).
/// </summary>
/// <remarks>
/// All byte arrays are big-endian, matching standard key encoding formats.
/// </remarks>
internal sealed class WeierstrassCurve
{
    /// <summary>
    /// Gets the human-readable curve name (e.g., "P-256").
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the field prime p (big-endian).
    /// </summary>
    public byte[] P { get; }

    /// <summary>
    /// Gets the curve coefficient a (big-endian).
    /// </summary>
    public byte[] A { get; }

    /// <summary>
    /// Gets the curve coefficient b (big-endian).
    /// </summary>
    public byte[] B { get; }

    /// <summary>
    /// Gets the base point (generator) x-coordinate (big-endian).
    /// </summary>
    public byte[] Gx { get; }

    /// <summary>
    /// Gets the base point (generator) y-coordinate (big-endian).
    /// </summary>
    public byte[] Gy { get; }

    /// <summary>
    /// Gets the order of the base point n (big-endian).
    /// </summary>
    public byte[] N { get; }

    /// <summary>
    /// Gets the cofactor h (typically 1 for NIST curves).
    /// </summary>
    public int H { get; }

    /// <summary>
    /// Gets the field size in bits.
    /// </summary>
    public int FieldBits { get; }

    /// <summary>
    /// Gets the field size in bytes.
    /// </summary>
    public int FieldSize => (FieldBits + 7) / 8;

    /// <summary>
    /// Gets the number of <see cref="ulong"/> limbs needed for field elements.
    /// </summary>
    public int LimbCount => (FieldSize + 7) / 8;

    private WeierstrassCurve(
        string name, int fieldBits, byte[] p, byte[] a, byte[] b,
        byte[] gx, byte[] gy, byte[] n, int h)
    {
        Name = name;
        FieldBits = fieldBits;
        P = p;
        A = a;
        B = b;
        Gx = gx;
        Gy = gy;
        N = n;
        H = h;
    }

    /// <summary>
    /// Gets the NIST P-256 curve (secp256r1, prime256v1).
    /// </summary>
    public static WeierstrassCurve P256 { get; } = CreateP256();

    /// <summary>
    /// Gets the NIST P-384 curve (secp384r1).
    /// </summary>
    public static WeierstrassCurve P384 { get; } = CreateP384();

    /// <summary>
    /// Gets the NIST P-521 curve (secp521r1).
    /// </summary>
    public static WeierstrassCurve P521 { get; } = CreateP521();

    /// <summary>
    /// Gets the secp256k1 curve (used in Bitcoin/Ethereum).
    /// </summary>
    public static WeierstrassCurve Secp256k1 { get; } = CreateSecp256k1();

    /// <summary>
    /// Gets the Brainpool P256r1 curve (RFC 5639).
    /// </summary>
    public static WeierstrassCurve BrainpoolP256r1 { get; } = CreateBrainpoolP256r1();

    /// <summary>
    /// Gets the Brainpool P384r1 curve (RFC 5639).
    /// </summary>
    public static WeierstrassCurve BrainpoolP384r1 { get; } = CreateBrainpoolP384r1();

    /// <summary>
    /// Gets the Brainpool P512r1 curve (RFC 5639).
    /// </summary>
    public static WeierstrassCurve BrainpoolP512r1 { get; } = CreateBrainpoolP512r1();

    private static WeierstrassCurve CreateP256()=> new(
        "P-256", 256,
        p: HexToBytes("FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFF"),
        a: HexToBytes("FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFC"),
        b: HexToBytes("5AC635D8AA3A93E7B3EBBD55769886BC651D06B0CC53B0F63BCE3C3E27D2604B"),
        gx: HexToBytes("6B17D1F2E12C4247F8BCE6E563A440F277037D812DEB33A0F4A13945D898C296"),
        gy: HexToBytes("4FE342E2FE1A7F9B8EE7EB4A7C0F9E162BCE33576B315ECECBB6406837BF51F5"),
        n: HexToBytes("FFFFFFFF00000000FFFFFFFFFFFFFFFFBCE6FAADA7179E84F3B9CAC2FC632551"),
        h: 1);

    private static WeierstrassCurve CreateP384() => new(
        "P-384", 384,
        p: HexToBytes("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFF0000000000000000FFFFFFFF"),
        a: HexToBytes("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFF0000000000000000FFFFFFFC"),
        b: HexToBytes("B3312FA7E23EE7E4988E056BE3F82D19181D9C6EFE8141120314088F5013875AC656398D8A2ED19D2A85C8EDD3EC2AEF"),
        gx: HexToBytes("AA87CA22BE8B05378EB1C71EF320AD746E1D3B628BA79B9859F741E082542A385502F25DBF55296C3A545E3872760AB7"),
        gy: HexToBytes("3617DE4A96262C6F5D9E98BF9292DC29F8F41DBD289A147CE9DA3113B5F0B8C00A60B1CE1D7E819D7A431D7C90EA0E5F"),
        n: HexToBytes("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC7634D81F4372DDF581A0DB248B0A77AECEC196ACCC52973"),
        h: 1);

    private static WeierstrassCurve CreateP521() => new(
        "P-521", 521,
        p: HexToBytes("01FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"),
        a: HexToBytes("01FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC"),
        b: HexToBytes("0051953EB9618E1C9A1F929A21A0B68540EEA2DA725B99B315F3B8B489918EF109E156193951EC7E937B1652C0BD3BB1BF073573DF883D2C34F1EF451FD46B503F00"),
        gx: HexToBytes("00C6858E06B70404E9CD9E3ECB662395B4429C648139053FB521F828AF606B4D3DBAA14B5E77EFE75928FE1DC127A2FFA8DE3348B3C1856A429BF97E7E31C2E5BD66"),
        gy: HexToBytes("011839296A789A3BC0045C8A5FB42C7D1BD998F54449579B446817AFBD17273E662C97EE72995EF42640C550B9013FAD0761353C7086A272C24088BE94769FD16650"),
        n: HexToBytes("01FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA51868783BF2F966B7FCC0148F709A5D03BB5C9B8899C47AEBB6FB71E91386409"),
        h: 1);

    private static WeierstrassCurve CreateSecp256k1() => new(
        "secp256k1", 256,
        p: HexToBytes("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F"),
        a: new byte[32], // a = 0
        b: HexToBytes("0000000000000000000000000000000000000000000000000000000000000007"),
        gx: HexToBytes("79BE667EF9DCBBAC55A06295CE870B07029BFCDB2DCE28D959F2815B16F81798"),
        gy: HexToBytes("483ADA7726A3C4655DA4FBFC0E1108A8FD17B448A68554199C47D08FFB10D4B8"),
        n: HexToBytes("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141"),
        h: 1);

    private static WeierstrassCurve CreateBrainpoolP256r1() => new(
        "brainpoolP256r1", 256,
        p: HexToBytes("A9FB57DBA1EEA9BC3E660A909D838D726E3BF623D52620282013481D1F6E5377"),
        a: HexToBytes("7D5A0975FC2C3057EEF67530417AFFE7FB8055C126DC5C6CE94A4B44F330B5D9"),
        b: HexToBytes("26DC5C6CE94A4B44F330B5D9BBD77CBF958416295CF7E1CE6BCCDC18FF8C07B6"),
        gx: HexToBytes("8BD2AEB9CB7E57CB2C4B482FFC81B7AFB9DE27E1E3BD23C23A4453BD9ACE3262"),
        gy: HexToBytes("547EF835C3DAC4FD97F8461A14611DC9C27745132DED8E545C1D54C72F046997"),
        n: HexToBytes("A9FB57DBA1EEA9BC3E660A909D838D718C397AA3B561A6F7901E0E82974856A7"),
        h: 1);

    private static WeierstrassCurve CreateBrainpoolP384r1() => new(
        "brainpoolP384r1", 384,
        p: HexToBytes("8CB91E82A3386D280F5D6F7E50E641DF152F7109ED5456B412B1DA197FB71123ACD3A729901D1A71874700133107EC53"),
        a: HexToBytes("7BC382C63D8C150C3C72080ACE05AFA0C2BEA28E4FB22787139165EFBA91F90F8AA5814A503AD4EB04A8C7DD22CE2826"),
        b: HexToBytes("04A8C7DD22CE28268B39B55416F0447C2FB77DE107DCD2A62E880EA53EEB62D57CB4390295DBC9943AB78696FA504C11"),
        gx: HexToBytes("1D1C64F068CF45FFA2A63A81B7C13F6B8847A3E77EF14FE3DB7FCAFE0CBD10E8E826E03436D646AAEF87B2E247D4AF1E"),
        gy: HexToBytes("8ABE1D7520F9C2A45CB1EB8E95CFD55262B70B29FEEC5864E19C054FF99129280E4646217791811142820341263C5315"),
        n: HexToBytes("8CB91E82A3386D280F5D6F7E50E641DF152F7109ED5456B31F166E6CAC0425A7CF3AB6AF6B7FC3103B883202E9046565"),
        h: 1);

    private static WeierstrassCurve CreateBrainpoolP512r1() => new(
        "brainpoolP512r1", 512,
        p: HexToBytes("AADD9DB8DBE9C48B3FD4E6AE33C9FC07CB308DB3B3C9D20ED6639CCA703308717D4D9B009BC66842AECDA12AE6A380E62881FF2F2D82C68528AA6056583A48F3"),
        a: HexToBytes("7830A3318B603B89E2327145AC234CC594CBDD8D3DF91610A83441CAEA9863BC2DED5D5AA8253AA10A2EF1C98B9AC8B57F1117A72BF2C7B9E7C1AC4D77FC94CA"),
        b: HexToBytes("3DF91610A83441CAEA9863BC2DED5D5AA8253AA10A2EF1C98B9AC8B57F1117A72BF2C7B9E7C1AC4D77FC94CADC083E67984050B75EBAE5DD2809BD638016F723"),
        gx: HexToBytes("81AEE4BDD82ED9645A21322E9C4C6A9385ED9F70B5D916C1B43B62EEF4D0098EFF3B1F78E2D0D48D50D1687B93B97D5F7C6D5047406A5E688B352209BCB9F822"),
        gy: HexToBytes("7DDE385D566332ECC0EABFA9CF7822FDF209F70024A57B1AA000C55B881F8111B2DCDE494A5F485E5BCA4BD88A2763AED1CA2B2FA8F0540678CD1E0F3AD80892"),
        n: HexToBytes("AADD9DB8DBE9C48B3FD4E6AE33C9FC07CB308DB3B3C9D20ED6639CCA70330870553E5C414CA92619418661197FAC10471DB1D381085DDADDB58796829CA90069"),
        h: 1);

    private static byte[] HexToBytes(string hex)
    {
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = (byte)((HexVal(hex[i * 2]) << 4) | HexVal(hex[i * 2 + 1]));
        }

        return bytes;
    }

    private static int HexVal(char c) => c switch
    {
        >= '0' and <= '9' => c - '0',
        >= 'A' and <= 'F' => c - 'A' + 10,
        >= 'a' and <= 'f' => c - 'a' + 10,
        _ => throw new ArgumentException($"Invalid hex character: {c}")
    };
}
